// <copyright file="IRoomModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;
using LateStartStudio.Hero6.ModuleController.Campaigns.Characters;
using LateStartStudio.Hero6.ModuleController.Campaigns.Items;
using LateStartStudio.Hero6.ModuleController.Campaigns.Rooms.Regions;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Rooms
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
