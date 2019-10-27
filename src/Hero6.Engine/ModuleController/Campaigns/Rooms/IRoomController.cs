// <copyright file="IRoomController.cs" company="Late Start Studio">
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
    public interface IRoomController : IGameController
    {
        IRoomModule Module { get; }

        /// <summary>
        /// Gets the characters in this room.
        /// </summary>
        IEnumerable<ICharacterController> Characters { get; }

        /// <summary>
        /// Gets the walk areas for this room.
        /// </summary>
        IWalkAreasController WalkAreas { get; }

        /// <summary>
        /// Gets the hotspots for this room.
        /// </summary>
        IHotspotsController Hotspots { get; }

        /// <summary>
        /// Adds character to this room.
        /// </summary>
        /// <typeparam name="T">Character by type.</typeparam>
        void AddCharacter<T>() where T : ICharacterModule;

        /// <summary>
        /// Removes character from this room.
        /// </summary>
        /// <typeparam name="T">Character by type.</typeparam>
        void RemoveCharacter<T>() where T : ICharacterModule;

        /// <summary>
        /// Removes character from this room.
        /// </summary>
        /// <param name="character">Character to remove.</param>
        void RemoveCharacter(ICharacterModule character);

        /// <summary>
        /// Adds item to this room.
        /// </summary>
        /// <typeparam name="T">Item by type.</typeparam>
        void AddItem<T>() where T : IItemModule;
    }
}
