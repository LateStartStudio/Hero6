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

    public abstract class CampaignController : GameController<CampaignController, CampaignModule>
    {
        protected CampaignController(CampaignModule module)
            : base(module)
        {
        }

        public abstract CharacterController Player { get; set; }

        public abstract AnimationController GetAnimation<T>() where T : AnimationModule;

        public abstract CharacterAnimationController GetCharacterAnimation<T>() where T : CharacterAnimationModule;

        public abstract CharacterController GetCharacter<T>() where T : CharacterModule;

        public abstract ItemController GetItem<T>() where T : ItemModule;

        public abstract InventoryItemController GetInventoryItem<T>() where T : InventoryItemModule;

        public abstract RoomController GetRoom<T>() where T : RoomModule;
    }
}
