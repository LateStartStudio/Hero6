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

    public abstract class CharacterController : GameController<CharacterController, CharacterModule>
    {
        protected CharacterController(CharacterModule module)
            : base(module)
        {
        }

        public abstract bool IsPlayer { get; }

        public abstract int Speed { get; set; }

        public abstract RoomController Room { get; }

        public abstract StatsController Stats { get; }

        public abstract CharacterAnimationController IdleAnimation { get; set; }

        public abstract CharacterAnimationController MoveAnimation { get; set; }

        public abstract IEnumerable<InventoryItemController> Inventory { get; }

        public abstract void AddInventoryItem<T>() where T : InventoryItemModule;

        public abstract void RemoveInventoryItem<T>() where T : InventoryItemModule;

        public abstract bool HasInventoryItem<T>() where T : InventoryItemModule;

        public abstract void Walk(int x, int y);

        public abstract void Face(CharacterDirection direction);

        public abstract void Face(int locationX, int locationY);

        public abstract void ChangeRoom<T>(int x = 0, int y = 0, CharacterDirection direction = CharacterDirection.CenterDown) where T : RoomModule;

        public abstract void SetAsPlayer();
    }
}
