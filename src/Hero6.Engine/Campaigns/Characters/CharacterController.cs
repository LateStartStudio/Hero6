// <copyright file="CharacterController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Characters
{
    using System.Collections.Generic;
    using LateStartStudio.Hero6.Engine.Campaigns.Animations;
    using LateStartStudio.Hero6.Engine.Campaigns.Characters.Stats;
    using LateStartStudio.Hero6.Engine.Campaigns.InventoryItems;
    using LateStartStudio.Hero6.Engine.Campaigns.Rooms;

    /// <summary>
    /// API for the character controller.
    /// </summary>
    public abstract class CharacterController : GameController<CharacterController, CharacterModule>
    {
        /// <summary>
        /// Makes a new instance of the <see cref="CharacterController"/> class.
        /// </summary>
        /// <param name="module">The module corresponding to this character.</param>
        protected CharacterController(CharacterModule module)
            : base(module)
        {
        }

        /// <summary>
        /// Gets a value indicating whether this character is the player character or not.
        /// </summary>
        public abstract bool IsPlayer { get; }

        /// <summary>
        /// Gets or sets a value indicating the movement speed of this character.
        /// </summary>
        public abstract int Speed { get; set; }

        /// <summary>
        /// Gets the room this character is in.
        /// </summary>
        public abstract RoomController Room { get; }

        /// <summary>
        /// Gets the stats for this character.
        /// </summary>
        public abstract StatsController Stats { get; }

        /// <summary>
        /// Gets or sets the idle animation of this character.
        /// </summary>
        public abstract CharacterAnimationController IdleAnimation { get; set; }

        /// <summary>
        /// Gets or sets the movement animation of this character.
        /// </summary>
        public abstract CharacterAnimationController MoveAnimation { get; set; }

        /// <summary>
        /// Gets the inventory of this character.
        /// </summary>
        public abstract IEnumerable<InventoryItemController> Inventory { get; }

        /// <summary>
        /// Adds inventory item to this character's inventory.
        /// </summary>
        /// <typeparam name="T">The inventory item.</typeparam>
        public abstract void AddInventoryItem<T>() where T : InventoryItemModule;

        /// <summary>
        /// Removes inventory item to this character's inventory.
        /// </summary>
        /// <typeparam name="T">the inventory item.</typeparam>
        public abstract void RemoveInventoryItem<T>() where T : InventoryItemModule;

        /// <summary>
        /// Checks if the character has inventory item.
        /// </summary>
        /// <typeparam name="T">The inventory item.</typeparam>
        /// <returns>True if the character has the inventory item. False if not.</returns>
        public abstract bool HasInventoryItem<T>() where T : InventoryItemModule;

        /// <summary>
        /// Make the character walk to the input coordinates.
        /// </summary>
        /// <param name="x">The x coordinate to walk to.</param>
        /// <param name="y">The y coordinate to walk to.</param>
        public abstract void Walk(int x, int y);

        /// <summary>
        /// Face towards the specified direciton.
        /// </summary>
        /// <param name="direction">The direction to face.</param>
        public abstract void Face(CharacterDirection direction);

        /// <summary>
        /// Face towards the coordinate.
        /// </summary>
        /// <param name="locationX">The x coordinate to face.</param>
        /// <param name="locationY">The y coordiante to face.</param>
        public abstract void Face(int locationX, int locationY);

        /// <summary>
        /// Change the room for this character.
        /// </summary>
        /// <typeparam name="T">The room.</typeparam>
        /// <param name="x">The x coordinate the character should spawn on.</param>
        /// <param name="y">The y coordinate the character should spawn on.</param>
        /// <param name="direction">The direction the character should be facing on spwan.</param>
        public abstract void ChangeRoom<T>(int x = 0, int y = 0, CharacterDirection direction = CharacterDirection.CenterDown) where T : RoomModule;

        /// <summary>
        /// Set this character as the player character of the campaign.
        /// </summary>
        public abstract void SetAsPlayer();
    }
}
