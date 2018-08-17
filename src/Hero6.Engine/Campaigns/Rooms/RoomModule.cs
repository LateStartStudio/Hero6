// <copyright file="RoomModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Rooms
{
    using System.Collections.Generic;
    using System.Linq;
    using LateStartStudio.Hero6.Engine.Campaigns.Characters;
    using LateStartStudio.Hero6.Engine.Campaigns.Items;
    using LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions;

    public abstract class RoomModule : GameModule<RoomController>
    {
        public abstract string Background { get; }

        public abstract string WalkAreasMask { get; }

        public abstract string HotspotsMask { get; }

        public IEnumerable<CharacterModule> Characters => Controller.Characters.Select(c => c.Module);

        public HotspotsModule Hotspots => Controller.Hotspots;

        public void AddCharacter<T>() where T : CharacterModule => Controller.AddCharacter<T>();

        public void AddItem<T>() where T : ItemModule => Controller.AddItem<T>();
    }
}
