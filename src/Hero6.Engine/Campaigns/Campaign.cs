// <copyright file="Campaign.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using System;
    using System.Collections.Generic;
    using Assets;
    using GameLoop;
    using UserInterfaces;
    using Utilities;

    /// <summary>
    /// A class that represents a campaign, scenario or story of a game. One game might have
    /// multiple stories, a role playing game for example can have mutiple unrelated scenarios.
    /// </summary>
    public abstract class Campaign : IGameLoop
    {
        private readonly IDictionary<string, Character> characters;
        private readonly IDictionary<string, Item> items;
        private readonly IDictionary<string, InventoryItem> inventoryItems;
        private readonly IDictionary<string, Room> rooms;

        /// <summary>
        /// Initializes a new instance of the <see cref="Campaign"/> class.
        /// </summary>
        /// <param name="name">The name of the campaign.</param>
        /// <param name="statCap">The stat cap of this campaign instance.</param>
        /// <param name="assets">The assets manager that will load campaign assets.</param>
        /// <param name="userInterface">The user interface that this campaign will use.</param>
        protected Campaign(string name, int statCap, AssetManager assets, UserInterface userInterface)
        {
            Util.Logger?.Info($"Creating Campaign instance. - {name}");

            this.Name = name;
            this.StatCap = statCap;
            this.Assets = assets;

            this.UserInterface = userInterface;
            this.UserInterface.GameInteraction += this.OnUserInteraction;

            this.characters = new Dictionary<string, Character>();
            this.items = new Dictionary<string, Item>();
            this.inventoryItems = new Dictionary<string, InventoryItem>();
            this.rooms = new Dictionary<string, Room>();

            Util.Logger?.Info("Campaign instance created. - " + name);
        }

        /// <inheritdoc />
        public event EventHandler<LoadEventArgs> PreLoad;

        /// <inheritdoc />
        public event EventHandler<LoadEventArgs> PostLoad;

        /// <inheritdoc />
        public event EventHandler<UnloadEventArgs> PreUnload;

        /// <inheritdoc />
        public event EventHandler<UnloadEventArgs> PostUnload;

        /// <inheritdoc />
        public event EventHandler<UpdateEventArgs> PreUpdate;

        /// <inheritdoc />
        public event EventHandler<UpdateEventArgs> PostUpdate;

        /// <inheritdoc />
        public event EventHandler<DrawEventArgs> PreDraw;

        /// <inheritdoc />
        public event EventHandler<DrawEventArgs> PostDraw;

        /// <summary>
        /// Gets or sets the renderer of the campaign.
        /// </summary>
        public static Renderer Renderer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the campaign is paused or not.
        /// </summary>
        /// <value>
        /// A value indicating whether the campaign is paused or not.
        /// </value>
        public static bool IsPaused
        {
            get { return Renderer.IsPaused; }
            set { Renderer.IsPaused = value; }
        }

        /// <summary>
        /// Gets the name of the campaign.
        /// </summary>
        /// <value>
        /// The name of the campaign.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets the stat cap of this campaign instance.
        /// </summary>
        /// <value>
        /// The stat cap of this campaign instance.
        /// </value>
        public int StatCap { get; }

        /// <summary>
        /// Gets the <see cref="AssetManager"/> of the <see cref="Campaign"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="AssetManager"/> of the <see cref="Campaign"/> instance.
        /// </value>
        public AssetManager Assets { get; }

        /// <summary>
        /// Gets or sets the user interface of this campaign.
        /// </summary>
        /// <value>
        /// The user interface of the campaign.
        /// </value>
        public UserInterface UserInterface
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the currently active room of the campaign.
        /// </summary>
        /// <value>
        /// The currently active room of the campaign.
        /// </value>
        public Room CurrentRoom
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the currently active player character of the campaign.
        /// </summary>
        /// <value>
        /// The currently active player character of the campaign.
        /// </value>
        public PlayerCharacter Player
        {
            get; set;
        }

        /// <summary>
        /// Gets the character from the ID.
        /// </summary>
        /// <param name="id">The character ID.</param>
        /// <returns>The character object.</returns>
        public Character GetCharacter(string id)
        {
            return this.characters[id];
        }

        /// <summary>
        /// Gets the item from the ID.
        /// </summary>
        /// <param name="id">The item ID.</param>
        /// <returns>The item object.</returns>
        public Item GetItem(string id)
        {
            return this.items[id];
        }

        /// <summary>
        /// Gets the inventory item from the ID.
        /// </summary>
        /// <param name="id">The inventory item ID.</param>
        /// <returns>The inventory item object.</returns>
        public InventoryItem GetInventoryItem(string id)
        {
            return this.inventoryItems[id];
        }

        /// <summary>
        /// Gets the room from the ID.
        /// </summary>
        /// <param name="id">The room ID.</param>
        /// <returns>The room object.</returns>
        public Room GetRoom(string id)
        {
            return this.rooms[id];
        }

        /// <summary>
        /// Moves a character to another room. If the character is the palyer this will also change
        /// the currently active room of the campaign.
        /// </summary>
        /// <param name="character">The character object.</param>
        /// <param name="room">The room ID.</param>
        public void ChangeRoom(Character character, string room)
        {
            foreach (KeyValuePair<string, Room> currentRoom in this.rooms)
            {
                if (currentRoom.Value.Characters.Contains(character))
                {
                    currentRoom.Value.Characters.Remove(character);
                }
            }

            this.rooms[room].Characters.Add(character);

            if (!character.IsPlayer)
            {
                return;
            }

            this.CurrentRoom = this.rooms[room];
        }

        /// <inheritdoc />
        public void Load()
        {
            this.PreLoad?.Invoke(this, new LoadEventArgs(this.Assets));
            Util.Logger?.Info("Loading campaign.");

            foreach (KeyValuePair<string, Character> keyValuePair in this.characters)
            {
                keyValuePair.Value.Load();
            }

            foreach (KeyValuePair<string, Item> keyValuePair in this.items)
            {
                keyValuePair.Value.Load();
            }

            foreach (KeyValuePair<string, InventoryItem> keyValuePair in this.inventoryItems)
            {
                keyValuePair.Value.Load();
            }

            foreach (KeyValuePair<string, Room> keyValuePair in this.rooms)
            {
                keyValuePair.Value.Load();
            }

            Util.Logger?.Info("Campaign Loaded.");
            this.PostLoad?.Invoke(this, new LoadEventArgs(this.Assets));
        }

        /// <inheritdoc />
        public void Unload()
        {
            this.PreUnload?.Invoke(this, new UnloadEventArgs());
            Util.Logger?.Info("Unloading campaign.");

            Util.Logger?.Info("Campaign unloaded.");
            this.PostUnload?.Invoke(this, new UnloadEventArgs());
        }

        /// <inheritdoc />
        public void Update(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            this.PreUpdate?.Invoke(this, new UpdateEventArgs(total, elapsed, isRunningSlowly));

            if (IsPaused)
            {
                return;
            }

            this.CurrentRoom.Update(total, elapsed, isRunningSlowly);

            this.PostUpdate?.Invoke(this, new UpdateEventArgs(total, elapsed, isRunningSlowly));
        }

        /// <inheritdoc />
        public void Draw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            this.PreDraw?.Invoke(this, new DrawEventArgs(total, elapsed, isRunningSlowly, Renderer));

            this.CurrentRoom.Draw(total, elapsed, isRunningSlowly);

            this.PostDraw?.Invoke(this, new DrawEventArgs(total, elapsed, isRunningSlowly, Renderer));
        }

        /// <summary>
        /// Adds a character to the campaign.
        /// </summary>
        /// <param name="id">The character ID.</param>
        /// <param name="character">The character.</param>
        protected void AddCharacter(string id, Character character)
        {
            this.characters.Add(id, character);
        }

        /// <summary>
        /// Adds an item to the campaign.
        /// </summary>
        /// <param name="id">The item ID.</param>
        /// <param name="item">The item object.</param>
        protected void AddItem(string id, Item item)
        {
            this.items.Add(id, item);
        }

        /// <summary>
        /// Adds an inventory item to the campaign.
        /// </summary>
        /// <param name="id">The inventory item ID.</param>
        /// <param name="inventoryItem">The inventory item.</param>
        protected void AddInventoryItem(string id, InventoryItem inventoryItem)
        {
            this.inventoryItems.Add(id, inventoryItem);
        }

        /// <summary>
        /// Adds a room to the campaign.
        /// </summary>
        /// <param name="id">The room ID.</param>
        /// <param name="room">The room object.</param>
        protected void AddRoom(string id, Room room)
        {
            this.rooms.Add(id, room);
        }

        private void OnUserInteraction(object sender, GameInteractionEventArgs e)
        {
            this.CurrentRoom.Interact(e.X, e.Y, e.Interaction);
        }
    }
}
