// <copyright file="Room.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using System;
    using System.Collections.Generic;
    using Assets.Graphics;
    using GameLoop;
    using Regions;
    using Search.Pathfinder;

    /// <summary>
    /// A class that represents a room in a game.
    /// </summary>
    public abstract class Room : AdventureGameElement
    {
        private readonly string backgroundID;
        private readonly string walkAreasID;
        private readonly string hotSpotMaskID;

        private Texture2D background;
        private WalkAreas walkAreas;
        private Texture2D hotspotsMask;
        private Color[,] hotspotMaskBuffer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="campaign">The campaign this item belongs to.</param>
        /// <param name="backgroundID">The ID of the room background.</param>
        /// <param name="walkAreasID">The ID of the room walk area.</param>
        /// <param name="hotSpotMaskID">The ID of the room hot spot mask.</param>
        protected Room(
            Campaign campaign,
            string backgroundID,
            string walkAreasID,
            string hotSpotMaskID)
            : base(campaign)
        {
            this.backgroundID = backgroundID;
            this.walkAreasID = walkAreasID;
            this.hotSpotMaskID = hotSpotMaskID;
            this.Characters = new List<Character>();
            this.Items = new List<Item>();
            this.Hotspots = new Dictionary<Color, Hotspot>();
        }

        /// <summary>
        /// Gets a list of all characters contained in this room.
        /// </summary>
        /// <value>
        /// A list of all characters conatined in this room.
        /// </value>
        public IList<Character> Characters { get; }

        /// <summary>
        /// Gets a list of all items contained in this room.
        /// </summary>
        /// <value>
        /// A list of all items contained in this room.
        /// </value>
        public IList<Item> Items { get; }

        /// <summary>
        /// Gets a dictionary of all hotspots contained in this room.
        /// </summary>
        /// <value>
        /// A dictionary of all hotspots contained in this room.
        /// </value>
        public IDictionary<Color, Hotspot> Hotspots { get; }

        /// <inheritdoc />
        public sealed override int Width => this.background.Width;

        /// <inheritdoc />
        public sealed override int Height => this.background.Height;

        /// <inheritdoc />
        public sealed override bool Interact(int x, int y, Interaction interaction)
        {
            if (interaction == Interaction.Move)
            {
                return this.Walk(x, y, Campaign.Player);
            }

            foreach (Character character in this.Characters)
            {
                if (character.Interact(x, y, interaction))
                {
                    return true;
                }
            }

            foreach (Item item in this.Items)
            {
                if (item.Interact(x, y, interaction))
                {
                    return true;
                }
            }

            Color pixel = this.hotspotMaskBuffer[y, x];

            if (interaction == Interaction.Eye)
            {
                this.Hotspots[pixel].InvokeLook(EventArgs.Empty);
            }
            else if (interaction == Interaction.Hand)
            {
                this.Hotspots[pixel].InvokeGrab(EventArgs.Empty);
            }
            else if (interaction == Interaction.Mouth)
            {
                this.Hotspots[pixel].InvokeTalk(EventArgs.Empty);
            }
            else
            {
                return false;
            }

            return true;
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
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return false;
            }

            IEnumerable<Point> path = walkAreas?.GetPath(character.Location, new Point(x, y));

            if (path == null)
            {
                return false;
            }

            character.MovementPath = new Queue<Point>(path);

            return true;
        }

        /// <inheritdoc />
        protected sealed override void InternalLoad()
        {
            this.background = Assets.LoadTexture2D(backgroundID);
            this.walkAreas = Assets.LoadWalkAreas(walkAreasID);

            this.hotspotsMask = this.Assets.LoadTexture2D(this.hotSpotMaskID);
            this.hotspotMaskBuffer = this.FindHotspots(this.hotspotsMask);

            this.InitializeEvents();
        }

        /// <inheritdoc />
        protected sealed override void InternalUnload()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected sealed override void InternalUpdate(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            foreach (Item item in this.Items)
            {
                item.Update(total, elapsed, isRunningSlowly);
            }

            foreach (Character character in this.Characters)
            {
                character.Update(total, elapsed, isRunningSlowly);
            }

            Color pixel = this.hotspotMaskBuffer[this.Campaign.Player.Location.Y, this.Campaign.Player.Location.X];
            this.Hotspots[pixel].InvokeWhileStandingIn(new HotspotWalkingEventArgs(Campaign.Player));
        }

        /// <inheritdoc />
        protected sealed override void InternalDraw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            if (this.IsVisible)
            {
                this.Campaign.Renderer.Draw(this.background, this.Location);
            }

            foreach (Item item in this.Items)
            {
                item.Draw(total, elapsed, isRunningSlowly);
            }

            foreach (Character character in this.Characters)
            {
                character.Draw(total, elapsed, isRunningSlowly);
            }
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
    }
}
