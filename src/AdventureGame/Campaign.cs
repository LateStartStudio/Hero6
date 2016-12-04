// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Campaign.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the Campaign type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame
{
    using System;
    using System.Collections.Generic;
    using Engine;
    using Game;
    using UI;

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
        /// <param name="engine">The engine that will run the campaign.</param>
        /// <param name="content">The content manager that will load campaign assets.</param>
        /// <param name="userInterface">The user interface that this campaign will use.</param>
        protected Campaign(
            string name,
            Engine.Engine engine,
            ContentManager content,
            UserInterface userInterface)
        {
            this.Name = name;
            this.Engine = engine;
            this.Content = content;
            this.UserInterface = userInterface;
            this.characters = new Dictionary<string, Character>();
            this.items = new Dictionary<string, Item>();
            this.inventoryItems = new Dictionary<string, InventoryItem>();
            this.rooms = new Dictionary<string, Room>();
        }

        /// <summary>
        /// Gets the name of the campaign.
        /// </summary>
        /// <value>
        /// The name of the campaign.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets the engine of the campaign.
        /// </summary>
        /// <value>
        /// The engine of the campaign.
        /// </value>
        public Engine.Engine Engine { get; }

        /// <summary>
        /// Gets the <see cref="ContentManager"/> of the <see cref="Campaign"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="ContentManager"/> of the <see cref="Campaign"/> instance.
        /// </value>
        public ContentManager Content { get; }

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
        public Character Player
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
        }

        /// <inheritdoc />
        public void Unload()
        {
        }

        /// <inheritdoc />
        public void Update(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly)
        {
            this.CurrentRoom.Update(totalTime, elapsedTime, isRunningSlowly);
        }

        /// <inheritdoc />
        public void Draw(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly)
        {
            this.CurrentRoom.Draw(totalTime, elapsedTime, isRunningSlowly);
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
    }
}
