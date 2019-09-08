﻿// <copyright file="ICharacterModule.cs" company="Late Start Studio">
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

    public interface ICharacterModule : IGameModule
    {
        bool IsPlayer { get; }

        int Speed { get; set; }

        RoomModule Room { get; }

        StatsModule Stats { get; }

        ICharacterAnimationModule IdleAnimation { get; set; }

        ICharacterAnimationModule MoveAnimation { get; set; }

        IEnumerable<InventoryItemModule> Inventory { get; }

        void AddInventoryItem<T>() where T : InventoryItemModule;

        void RemoveInventoryItem<T>() where T : InventoryItemModule;

        bool HasInventoryItem<T>() where T : InventoryItemModule;

        void Walk(int x, int y);

        void Face(CharacterDirection direction);

        void Face(int locationX, int locationY);

        void ChangeRoom<T>(int x = 0, int y = 0, CharacterDirection direction = CharacterDirection.CenterDown) where T : RoomModule;

        void SetAsPlayer();
    }
}
