// <copyright file="CampaignModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using System.Collections.Generic;
using LateStartStudio.Hero6.Engine.Campaigns.Animations;
using LateStartStudio.Hero6.Engine.Campaigns.Characters;
using LateStartStudio.Hero6.Engine.Campaigns.InventoryItems;
using LateStartStudio.Hero6.Engine.Campaigns.Items;
using LateStartStudio.Hero6.Engine.Campaigns.Rooms;

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    /// <summary>
    /// API for a campaign module.
    /// </summary>
    public abstract class CampaignModule : GameModule<CampaignController, CampaignModule>, ICampaignModule
    {
        /// <summary>
        /// Gets the stat cap for this campaign.
        /// </summary>
        public abstract int StatCap { get; }

        /// <summary>
        /// Gets or sets the player character of this campaign.
        /// </summary>
        public ICharacterModule Player
        {
            get { return Controller.Player.Module; }
            set { Controller.Player = ((CharacterModule)value).Controller; }
        }

        /// <summary>
        /// Gets any animation from this campaign.
        /// </summary>
        /// <typeparam name="T">The animation specified by type.</typeparam>
        /// <returns>The animation.</returns>
        public IAnimationModule GetAnimation<T>() where T : AnimationModule => Controller.GetAnimation<T>().Module;

        /// <summary>
        /// Gets any character animation from this campaign.
        /// </summary>
        /// <typeparam name="T">The character animation specified by type.</typeparam>
        /// <returns>The character animation.</returns>
        public ICharacterAnimationModule GetCharacterAnimation<T>() where T : CharacterAnimationModule => Controller.GetCharacterAnimation<T>().Module;

        /// <summary>
        /// Gets any character from this campaign.
        /// </summary>
        /// <typeparam name="T">The character specified by type.</typeparam>
        /// <returns>The character.</returns>
        public ICharacterModule GetCharacter<T>() where T : CharacterModule => Controller.GetCharacter<T>().Module;

        /// <summary>
        /// Gets any item from this campaign.
        /// </summary>
        /// <typeparam name="T">The item specified by type.</typeparam>
        /// <returns>The item.</returns>
        public IItemModule GetItem<T>() where T : ItemModule => Controller.GetItem<T>().Module;

        /// <summary>
        /// Gets any inventory item from this campaign.
        /// </summary>
        /// <typeparam name="T">The inventory item specified by type.</typeparam>
        /// <returns>The inventory item.</returns>
        public IInventoryItemModule GetInventoryItem<T>() where T : InventoryItemModule => Controller.GetInventoryItem<T>().Module;

        /// <summary>
        /// Gets any room from this campaign.
        /// </summary>
        /// <typeparam name="T">The room specified by type.</typeparam>
        /// <returns>The room.</returns>
        public IRoomModule GetRoom<T>() where T : RoomModule => Controller.GetRoom<T>().Module;

        /// <summary>
        /// Generate a list of animation types.
        /// </summary>
        /// <returns>A list of animation types.</returns>
        public abstract IEnumerable<Type> GenerateAnimations();

        /// <summary>
        /// Generate a list of characater animation types.
        /// </summary>
        /// <returns>A list of character animation types.</returns>
        public abstract IEnumerable<Type> GenerateCharacterAnimations();

        /// <summary>
        /// Generate a list of room types.
        /// </summary>
        /// <returns>A list of room types.</returns>
        public abstract IEnumerable<Type> GenerateRooms();

        /// <summary>
        /// Generate a list of character types.
        /// </summary>
        /// <returns>A list of character types.</returns>
        public abstract IEnumerable<Type> GenerateCharacters();

        /// <summary>
        /// Generate a list of item types.
        /// </summary>
        /// <returns>A list of item types.</returns>
        public abstract IEnumerable<Type> GenerateItems();

        /// <summary>
        /// Generate a list of inventory item types.
        /// </summary>
        /// <returns>A list of inventory item types.</returns>
        public abstract IEnumerable<Type> GenerateInventoryItems();
    }
}
