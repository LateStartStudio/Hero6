// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Room.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the Room type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Game
{
    using System;
    using System.Collections.Generic;
    using AdventureGame;
    using Engine.Graphics;
    using Search.Pathfinder;

    /// <summary>
    /// A class that represents a room in a game.
    /// </summary>
    public abstract class Room : AdventureGameElement
    {
        private static readonly int[,] DirectionVectors =
        {
            { -1, -1 },
            { 0, -1 },
            { 1, -1 },
            { -1, 0 },
            { 1, 0 },
            { -1, 1 },
            { 0, 1 },
            { 1, 1 }
        };

        private readonly IPathfinder pathfinder;
        private readonly string backgroundID;
        private readonly string walkAreaID;
        private readonly string hotSpotMaskID;
        private readonly IList<Character> characters;
        private readonly IList<Item> items;
        private readonly IDictionary<Color, Hotspot> hotspots;

        private Texture2D background;
        private Texture2D walkAreaMask;
        private Texture2D hotspotsMask;
        private Color[,] walkAreaBuffer;
        private Node[,] walkAreaNodes;
        private Color[,] hotspotMaskBuffer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="campaign">The campaign this item belongs to.</param>
        /// <param name="backgroundID">The ID of the room background.</param>
        /// <param name="walkAreaID">The ID of the room walk area.</param>
        /// <param name="hotSpotMaskID">The ID of the room hot spot mask.</param>
        protected Room(
            Campaign campaign,
            string backgroundID,
            string walkAreaID,
            string hotSpotMaskID)
            : base(campaign)
        {
            this.pathfinder = new AStar(2500, (node, neighbor) => 1, this.CalculateOctileHeuristic);
            this.backgroundID = backgroundID;
            this.walkAreaID = walkAreaID;
            this.hotSpotMaskID = hotSpotMaskID;
            this.characters = new List<Character>();
            this.items = new List<Item>();
            this.hotspots = new Dictionary<Color, Hotspot>();
        }

        /// <summary>
        /// Gets a list of all characters contained in this room.
        /// </summary>
        /// <value>
        /// A list of all characters conatined in this room.
        /// </value>
        public IList<Character> Characters
        {
            get { return this.characters; }
        }

        /// <summary>
        /// Gets a list of all items contained in this room.
        /// </summary>
        /// <value>
        /// A list of all items contained in this room.
        /// </value>
        public IList<Item> Items
        {
            get { return this.items; }
        }

        /// <summary>
        /// Gets a dictionary of all hotspots contained in this room.
        /// </summary>
        /// <value>
        /// A dictionary of all hotspots contained in this room.
        /// </value>
        public IDictionary<Color, Hotspot> Hotspots
        {
            get { return this.hotspots; }
        }

        /// <inheritdoc />
        public override sealed int Width
        {
            get { return this.background.Width; }
        }

        /// <inheritdoc />
        public override sealed int Height
        {
            get { return this.background.Height; }
        }

        /// <inheritdoc />
        public override sealed bool Interact(int x, int y)
        {
            foreach (Character character in this.characters)
            {
                if (character.Interact(x, y))
                {
                    return true;
                }
            }

            foreach (Item item in this.items)
            {
                if (item.Interact(x, y))
                {
                    return true;
                }
            }

            return this.Walk(x, y, Campaign.Player);
        }

        /// <inheritdoc />
        public override sealed void Load()
        {
            this.background = this.Content.LoadTexture2D(this.backgroundID);

            this.walkAreaMask = this.Content.LoadTexture2D(this.walkAreaID);
            this.walkAreaBuffer = CopyTextureData(this.walkAreaMask);
            this.walkAreaNodes = this.CreateWalkNodes();

            foreach (Node walkAreaNode in this.walkAreaNodes)
            {
                walkAreaNode.Children = this.FindNeighbors(walkAreaNode);
            }

            this.hotspotsMask = this.Content.LoadTexture2D(this.hotSpotMaskID);
            this.hotspotMaskBuffer = this.FindHotspots(this.hotspotsMask);

            this.InitializeEvents();
        }

        /// <inheritdoc />
        public override sealed void Unload()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override sealed void Update(
            TimeSpan totalTime,
            TimeSpan elapsedTime,
            bool isRunningSlowly)
        {
            foreach (Item item in this.Items)
            {
                item.Update(totalTime, elapsedTime, isRunningSlowly);
            }

            foreach (Character character in this.Characters)
            {
                character.Update(totalTime, elapsedTime, isRunningSlowly);
            }

            Color pixel = this.hotspotMaskBuffer[this.Campaign.Player.Location.Y, this.Campaign.Player.Location.X];
            this.Hotspots[pixel].InvokeWhileStandingIn(Campaign.Player);
        }

        /// <inheritdoc />
        public override sealed void Draw(
            TimeSpan totalTime,
            TimeSpan elapsedTime,
            bool isRunningSlowly)
        {
            if (this.IsVisible)
            {
                this.Campaign.Engine.Graphics.Draw(this.background, this.Location);
            }

            foreach (Item pickUpItem in this.items)
            {
                pickUpItem.Draw(totalTime, elapsedTime, isRunningSlowly);
            }

            foreach (Character character in this.characters)
            {
                character.Draw(totalTime, elapsedTime, isRunningSlowly);
            }
        }

        /// <summary>
        /// Make a character walk to the input destination.
        /// </summary>
        /// <param name="x">The x coordinate the character should walk to.</param>
        /// <param name="y">The y coordinate the character should walk to.</param>
        /// <param name="character">The character that should walk to the destination.</param>
        /// <returns>True if the destination could be reached; false otherwise.</returns>
        public bool Walk(int x, int y, Character character)
        {
            if (this.walkAreaMask == null)
            {
                return false;
            }

            if (x < 0 || x >= this.walkAreaMask.Width || y < 0 || y >= this.walkAreaMask.Height)
            {
                return false;
            }

            if (this.walkAreaBuffer[y, x] != Color.White)
            {
                return false;
            }

            Node start = this.walkAreaNodes[character.Location.Y, character.Location.X];
            Node end = this.walkAreaNodes[y, x];

            character.MovementPath = new Queue<Vector2>(
                this.ConvertSearchNodeToVector(this.pathfinder.FindPath(start, end)));

            return true;
        }

        /// <summary>
        /// Initializes the events associated with this room.
        /// </summary>
        protected abstract void InitializeEvents();

        private static Color[,] CopyTextureData(Texture2D texture)
        {
            Color[] data = new Color[texture.Width * texture.Height];
            texture.GetData(data);

            Color[,] result = new Color[texture.Height, texture.Width];

            for (int y = 0; y < texture.Height; y++)
            {
                for (int x = 0; x < texture.Width; x++)
                {
                    result[y, x] = data[(y * texture.Width) + x];
                }
            }

            return result;
        }

        private Node[,] CreateWalkNodes()
        {
            Node[,] nodes = new Node[this.Height, this.Width];

            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    nodes[y, x] = new Node(
                        (y * this.Width) + x,
                        this.walkAreaBuffer[y, x].Equals(Color.Transparent));
                }
            }

            return nodes;
        }

        private Color[,] FindHotspots(Texture2D texture)
        {
            Color[,] data = CopyTextureData(texture);

            foreach (Color pixel in data)
            {
                if (!this.Hotspots.ContainsKey(pixel))
                {
                    this.Hotspots.Add(pixel, new Hotspot());
                }
            }

            return data;
        }

        private int CalculateOctileHeuristic(Node from, Node to)
        {
            int fromX = from.ID % this.Width;
            int fromY = from.ID / this.Width;
            int toX = to.ID % this.Width;
            int toY = to.ID / this.Width;

            return (int)(Math.Min(Math.Abs(fromX - toX), Math.Abs(fromY - toY)) + (1.5 * Math.Max(Math.Abs(fromX - toX), Math.Abs(fromY - toY))));
        }

        private IList<Node> FindNeighbors(Node searchNode)
        {
            IList<Node> neighbors = new List<Node>();

            for (int i = 0; i < DirectionVectors.GetLength(0); i++)
            {
                int x = (searchNode.ID % this.Width) + DirectionVectors[i, 0];
                int y = (searchNode.ID / this.Width) + DirectionVectors[i, 1];

                if (x < 0 || x >= this.Width || y < 0 || y >= this.Height)
                {
                    continue;
                }

                neighbors.Add(this.walkAreaNodes[y, x]);
            }

            return neighbors;
        }

        private IEnumerable<Vector2> ConvertSearchNodeToVector(IList<Node> searchNodes)
        {
            if (searchNodes == null || searchNodes.Count == 0)
            {
                return null;
            }

            IList<Vector2> result = new List<Vector2>();

            foreach (Node searchNode in searchNodes)
            {
                result.Add(new Vector2(searchNode.ID % this.Width, searchNode.ID / this.Width));
            }

            return result;
        }
    }
}
