// <copyright file="ICampaignController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.ModuleController.Campaigns.Animations;
using LateStartStudio.Hero6.ModuleController.Campaigns.Characters;
using LateStartStudio.Hero6.ModuleController.Campaigns.InventoryItems;
using LateStartStudio.Hero6.ModuleController.Campaigns.Items;
using LateStartStudio.Hero6.ModuleController.Campaigns.Rooms;

namespace LateStartStudio.Hero6.ModuleController.Campaigns
{
    public interface ICampaignController : IGameController
    {
        /// <summary>
        /// Gets or sets the player character of this campaign.
        /// </summary>
        ICharacterController Player { get; set; }

        /// <summary>
        /// Gets any animation from this campaign.
        /// </summary>
        /// <typeparam name="T">The animation specified by type.</typeparam>
        /// <returns>The animation.</returns>
        AnimationController GetAnimation<T>() where T : AnimationModule;

        /// <summary>
        /// Gets any character animation from this campaign.
        /// </summary>
        /// <typeparam name="T">The character animation specified by type.</typeparam>
        /// <returns>The character animation.</returns>
        CharacterAnimationController GetCharacterAnimation<T>() where T : CharacterAnimationModule;

        /// <summary>
        /// Gets any character from this campaign.
        /// </summary>
        /// <typeparam name="T">The character specified by type.</typeparam>
        /// <returns>The character.</returns>
        CharacterController GetCharacter<T>() where T : CharacterModule;

        /// <summary>
        /// Gets any item from this campaign.
        /// </summary>
        /// <typeparam name="T">The item specified by type.</typeparam>
        /// <returns>The item.</returns>
        ItemController GetItem<T>() where T : ItemModule;

        /// <summary>
        /// Gets any inventory item from this campaign.
        /// </summary>
        /// <typeparam name="T">The inventory item specified by type.</typeparam>
        /// <returns>The inventory item.</returns>
        InventoryItemController GetInventoryItem<T>() where T : InventoryItemModule;

        /// <summary>
        /// Gets any room from this campaign.
        /// </summary>
        /// <typeparam name="T">The room specified by type.</typeparam>
        /// <returns>The room.</returns>
        RoomController GetRoom<T>() where T : RoomModule;
    }
}
