// <copyright file="RoomController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Rooms
{
    using System.Collections.Generic;
    using LateStartStudio.Hero6.Engine.Campaigns.Characters;
    using LateStartStudio.Hero6.Engine.Campaigns.Items;
    using LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions;

    public abstract class RoomController : GameController<RoomController, RoomModule>
    {
        protected RoomController(RoomModule module)
            : base(module)
        {
        }

        public abstract IEnumerable<CharacterController> Characters { get; }

        public abstract WalkAreasController WalkAreas { get; }

        public abstract HotspotsController Hotspots { get; }

        public abstract void AddCharacter<T>() where T : CharacterModule;

        public abstract void AddItem<T>() where T : ItemModule;
    }
}
