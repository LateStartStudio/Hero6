﻿// <copyright file="ICharacterController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;
using LateStartStudio.Hero6.ModuleController.Campaigns.Animations;
using LateStartStudio.Hero6.ModuleController.Campaigns.Characters.Stats;
using LateStartStudio.Hero6.ModuleController.Campaigns.InventoryItems;
using LateStartStudio.Hero6.ModuleController.Campaigns.Rooms;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Characters
{
    public interface ICharacterController : IGameController
    {
        ICharacterModule Module { get; }

        /// <summary>
        /// Gets a value indicating whether this character is the player character or not.
        /// </summary>
        bool IsPlayer { get; }

        /// <summary>
        /// Gets or sets a value indicating the movement speed of this character.
        /// </summary>
        int Speed { get; set; }

        /// <summary>
        /// Gets the room this character is in.
        /// </summary>
        IRoomController Room { get; }

        /// <summary>
        /// Gets the stats for this character.
        /// </summary>
        IStatsController Stats { get; }

        /// <summary>
        /// Gets or sets the idle animation of this character.
        /// </summary>
        ICharacterAnimationController IdleAnimation { get; set; }

        /// <summary>
        /// Gets or sets the movement animation of this character.
        /// </summary>
        ICharacterAnimationController MoveAnimation { get; set; }

        /// <summary>
        /// Gets the inventory of this character.
        /// </summary>
        IEnumerable<IInventoryItemController> Inventory { get; }

        /// <summary>
        /// Adds inventory item to this character's inventory.
        /// </summary>
        /// <typeparam name="T">The inventory item.</typeparam>
        void AddInventoryItem<T>() where T : IInventoryItemModule;

        /// <summary>
        /// Removes inventory item to this character's inventory.
        /// </summary>
        /// <typeparam name="T">the inventory item.</typeparam>
        void RemoveInventoryItem<T>() where T : IInventoryItemModule;

        /// <summary>
        /// Checks if the character has inventory item.
        /// </summary>
        /// <typeparam name="T">The inventory item.</typeparam>
        /// <returns>True if the character has the inventory item. False if not.</returns>
        bool HasInventoryItem<T>() where T : IInventoryItemModule;

        /// <summary>
        /// Make the character walk to the input coordinates.
        /// </summary>
        /// <param name="x">The x coordinate to walk to.</param>
        /// <param name="y">The y coordinate to walk to.</param>
        void Walk(int x, int y);

        /// <summary>
        /// Face towards the specified direciton.
        /// </summary>
        /// <param name="direction">The direction to face.</param>
        void Face(CharacterDirection direction);

        /// <summary>
        /// Face towards the coordinate.
        /// </summary>
        /// <param name="locationX">The x coordinate to face.</param>
        /// <param name="locationY">The y coordiante to face.</param>
        void Face(int locationX, int locationY);

        /// <summary>
        /// Change the room for this character.
        /// </summary>
        /// <typeparam name="T">The room.</typeparam>
        /// <param name="x">The x coordinate the character should spawn on.</param>
        /// <param name="y">The y coordinate the character should spawn on.</param>
        /// <param name="direction">The direction the character should be facing on spwan.</param>
        void ChangeRoom<T>(int x = 0, int y = 0, CharacterDirection direction = CharacterDirection.CenterDown) where T : IRoomModule;

        /// <summary>
        /// Set this character as the player character of the campaign.
        /// </summary>
        void SetAsPlayer();
    }
}
