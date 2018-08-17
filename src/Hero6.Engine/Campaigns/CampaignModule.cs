// <copyright file="CampaignModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using System;
    using System.Collections.Generic;
    using LateStartStudio.Hero6.Engine.Campaigns.Animations;
    using LateStartStudio.Hero6.Engine.Campaigns.Characters;
    using LateStartStudio.Hero6.Engine.Campaigns.InventoryItems;
    using LateStartStudio.Hero6.Engine.Campaigns.Items;
    using LateStartStudio.Hero6.Engine.Campaigns.Rooms;

    public abstract class CampaignModule : GameModule<CampaignController>
    {
        public abstract int StatCap { get; }

        public CharacterModule Player
        {
            get { return Controller.Player; }
            set { Controller.Player = value.Controller; }
        }

        public T GetAnimation<T>() where T : AnimationModule => (T)Controller.GetAnimation<T>();

        public T GetCharacterAnimation<T>() where T : CharacterAnimationModule => (T)Controller.GetCharacterAnimation<T>();

        public T GetCharacter<T>() where T : CharacterModule => (T)Controller.GetCharacter<T>();

        public T GetItem<T>() where T : ItemModule => (T)Controller.GetItem<T>();

        public T GetInventoryItem<T>() where T : InventoryItemModule => (T)Controller.GetInventoryItem<T>();

        public T GetRoom<T>() where T : RoomModule => (T)Controller.GetRoom<T>();

        public abstract IEnumerable<Type> GenerateAnimations();

        public abstract IEnumerable<Type> GenerateCharacterAnimations();

        public abstract IEnumerable<Type> GenerateRooms();

        public abstract IEnumerable<Type> GenerateCharacters();

        public abstract IEnumerable<Type> GenerateItems();

        public abstract IEnumerable<Type> GenerateInventoryItems();
    }
}
