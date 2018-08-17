// <copyright file="CharacterModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Characters
{
    using System.Collections.Generic;
    using System.Linq;
    using LateStartStudio.Hero6.Engine.Campaigns.Animations;
    using LateStartStudio.Hero6.Engine.Campaigns.Characters.Stats;
    using LateStartStudio.Hero6.Engine.Campaigns.InventoryItems;
    using LateStartStudio.Hero6.Engine.Campaigns.Rooms;

    public abstract class CharacterModule : GameModule<CharacterController>
    {
        public bool IsPlayer => Controller.IsPlayer;

        public int Speed
        {
            get { return Controller.Speed; }
            set { Controller.Speed = value; }
        }

        public RoomModule Room => Controller.Room;

        public StatsModule Stats => Controller.Stats;

        public CharacterAnimationModule IdleAnimation
        {
            get { return Controller.IdleAnimation; }
            set { Controller.IdleAnimation = value.Controller; }
        }

        public CharacterAnimationModule MoveAnimation
        {
            get { return Controller.MoveAnimation; }
            set { Controller.MoveAnimation = value.Controller; }
        }

        public IEnumerable<InventoryItemModule> Inventory => Controller.Inventory.Select(i => i.Module);

        public void AddInventoryItem<T>() where T : InventoryItemModule => Controller.AddInventoryItem<T>();

        public void RemoveInventoryItem<T>() where T : InventoryItemModule => Controller.RemoveInventoryItem<T>();

        public bool HasInventoryItem<T>() where T : InventoryItemModule => Controller.HasInventoryItem<T>();

        public void Walk(int x, int y) => Controller.Walk(x, y);

        public void Face(CharacterDirection direction) => Controller.Face(direction);

        public void Face(int locationX, int locationY) => Controller.Face(locationX, locationY);

        public void ChangeRoom<T>(int x = 0, int y = 0, CharacterDirection direction = CharacterDirection.CenterDown) where T : RoomModule
        {
            Controller.ChangeRoom<T>(x, y, direction);
        }

        public void SetAsPlayer() => Controller.SetAsPlayer();
    }
}
