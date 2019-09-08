// <copyright file="ICampaignModule.cs" company="Late Start Studio">
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
    using LateStartStudio.Hero6.Engine.ModuleController;

    public interface ICampaignModule : IGameModule
    {
        int StatCap { get; }

        ICharacterModule Player { get; set; }

        IAnimationModule GetAnimation<T>() where T : AnimationModule;

        ICharacterAnimationModule GetCharacterAnimation<T>() where T : CharacterAnimationModule;

        ICharacterModule GetCharacter<T>() where T : CharacterModule;

        IItemModule GetItem<T>() where T : ItemModule;

        IInventoryItemModule GetInventoryItem<T>() where T : InventoryItemModule;

        IRoomModule GetRoom<T>() where T : RoomModule;

        IEnumerable<Type> GenerateAnimations();

        IEnumerable<Type> GenerateCharacterAnimations();

        IEnumerable<Type> GenerateRooms();

        IEnumerable<Type> GenerateCharacters();

        IEnumerable<Type> GenerateItems();

        IEnumerable<Type> GenerateInventoryItems();
    }
}
