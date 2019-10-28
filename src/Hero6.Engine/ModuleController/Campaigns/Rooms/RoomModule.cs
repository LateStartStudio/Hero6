// <copyright file="RoomModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using LateStartStudio.Hero6.ModuleController.Campaigns.Characters;
using LateStartStudio.Hero6.ModuleController.Campaigns.Items;
using LateStartStudio.Hero6.ModuleController.Campaigns.Rooms.Regions;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Rooms
{
    /// <summary>
    /// API for room module.
    /// </summary>
    public abstract class RoomModule : GameModule<IRoomController, IRoomModule>, IRoomModule
    {
        /// <summary>
        /// Gets the path to the background image.
        /// </summary>
        public abstract string Background { get; }

        /// <summary>
        /// Gets the path the walk areas mask.
        /// </summary>
        public abstract string WalkAreasMask { get; }

        /// <summary>
        /// Gets the path to the hotspot mask.
        /// </summary>
        public abstract string HotspotsMask { get; }

        /// <summary>
        /// Gets the characters in this room.
        /// </summary>
        public IEnumerable<ICharacterModule> Characters => Controller.Characters.Select(c => c.Module);

        /// <summary>
        /// Gets the hotspot for this room.
        /// </summary>
        public IHotspotsModule Hotspots => Controller.Hotspots.Module;

        /// <summary>
        /// Adds character to this room.
        /// </summary>
        /// <typeparam name="T">Character by type.</typeparam>
        public void AddCharacter<T>() where T : ICharacterModule => Controller.AddCharacter<T>();

        public void RemoveCharacter<T>() where T : ICharacterModule => Controller.RemoveCharacter<T>();

        public void RemoveCharacter(ICharacterModule character) => Controller.RemoveCharacter(character);

        /// <summary>
        /// Adds item to this room.
        /// </summary>
        /// <typeparam name="T">Item by type.</typeparam>
        public void AddItem<T>() where T : IItemModule => Controller.AddItem<T>();
    }
}
