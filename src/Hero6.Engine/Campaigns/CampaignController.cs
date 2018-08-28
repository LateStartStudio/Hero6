// <copyright file="CampaignController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using LateStartStudio.Hero6.Engine.Campaigns.Animations;
    using LateStartStudio.Hero6.Engine.Campaigns.Characters;
    using LateStartStudio.Hero6.Engine.Campaigns.InventoryItems;
    using LateStartStudio.Hero6.Engine.Campaigns.Items;
    using LateStartStudio.Hero6.Engine.Campaigns.Rooms;

    /// <summary>
    /// API for a campaign controller.
    /// </summary>
    public abstract class CampaignController : GameController<CampaignController, CampaignModule>
    {
        /// <summary>
        /// Creates a new instance of the <see cref="CampaignController"/> instance.
        /// </summary>
        /// <param name="module">The module corresponding to this controller.</param>
        protected CampaignController(CampaignModule module)
            : base(module)
        {
        }

        /// <summary>
        /// Gets or sets the player character of this campaign.
        /// </summary>
        public abstract CharacterController Player { get; set; }

        /// <summary>
        /// Gets any animation from this campaign.
        /// </summary>
        /// <typeparam name="T">The animation specified by type.</typeparam>
        /// <returns>The animation.</returns>
        public abstract AnimationController GetAnimation<T>() where T : AnimationModule;

        /// <summary>
        /// Gets any character animation from this campaign.
        /// </summary>
        /// <typeparam name="T">The character animation specified by type.</typeparam>
        /// <returns>The character animation.</returns>
        public abstract CharacterAnimationController GetCharacterAnimation<T>() where T : CharacterAnimationModule;

        /// <summary>
        /// Gets any character from this campaign.
        /// </summary>
        /// <typeparam name="T">The character specified by type.</typeparam>
        /// <returns>The character.</returns>
        public abstract CharacterController GetCharacter<T>() where T : CharacterModule;

        /// <summary>
        /// Gets any item from this campaign.
        /// </summary>
        /// <typeparam name="T">The item specified by type.</typeparam>
        /// <returns>The item.</returns>
        public abstract ItemController GetItem<T>() where T : ItemModule;

        /// <summary>
        /// Gets any inventory item from this campaign.
        /// </summary>
        /// <typeparam name="T">The inventory item specified by type.</typeparam>
        /// <returns>The inventory item.</returns>
        public abstract InventoryItemController GetInventoryItem<T>() where T : InventoryItemModule;

        /// <summary>
        /// Gets any room from this campaign.
        /// </summary>
        /// <typeparam name="T">The room specified by type.</typeparam>
        /// <returns>The room.</returns>
        public abstract RoomController GetRoom<T>() where T : RoomModule;
    }
}
