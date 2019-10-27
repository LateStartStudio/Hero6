// <copyright file="ICharacterModule.cs" company="Late Start Studio">
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
    public interface ICharacterModule : IGameModule
    {
        bool IsPlayer { get; }

        int Speed { get; set; }

        IRoomModule Room { get; }

        IStatsModule Stats { get; }

        ICharacterAnimationModule IdleAnimation { get; set; }

        ICharacterAnimationModule MoveAnimation { get; set; }

        IEnumerable<IInventoryItemModule> Inventory { get; }

        void AddInventoryItem<T>() where T : IInventoryItemModule;

        void RemoveInventoryItem<T>() where T : IInventoryItemModule;

        bool HasInventoryItem<T>() where T : IInventoryItemModule;

        void Walk(int x, int y);

        void Face(CharacterDirection direction);

        void Face(int locationX, int locationY);

        void ChangeRoom<T>(int x = 0, int y = 0, CharacterDirection direction = CharacterDirection.CenterDown) where T : IRoomModule;

        void SetAsPlayer();
    }
}
