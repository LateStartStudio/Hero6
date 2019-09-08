// <copyright file="IRoomModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;
using LateStartStudio.Hero6.Engine.Campaigns.Characters;
using LateStartStudio.Hero6.Engine.Campaigns.Items;
using LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions;

namespace LateStartStudio.Hero6.Engine.Campaigns.Rooms
{
    public interface IRoomModule
    {
        string Background { get; }

        string WalkAreasMask { get; }

        string HotspotsMask { get; }

        IEnumerable<CharacterModule> Characters { get; }

        IHotspotsModule Hotspots { get; }

        void AddCharacter<T>() where T : CharacterModule;

        void AddItem<T>() where T : ItemModule;
    }
}
