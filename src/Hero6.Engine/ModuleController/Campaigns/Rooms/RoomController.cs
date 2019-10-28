// <copyright file="RoomController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;
using LateStartStudio.Hero6.ModuleController.Campaigns.Characters;
using LateStartStudio.Hero6.ModuleController.Campaigns.Items;
using LateStartStudio.Hero6.ModuleController.Campaigns.Rooms.Regions;
using LateStartStudio.Hero6.Services.DependencyInjection;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Rooms
{
    /// <summary>
    /// API for room controller.
    /// </summary>
    public abstract class RoomController : GameController<IRoomController, IRoomModule>, IRoomController
    {
        /// <summary>
        /// Makes a new <see cref="RoomController"/> instance.
        /// </summary>
        /// <param name="module">The module for this controller.</param>
        protected RoomController(IRoomModule module, IServiceLocator services)
            : base(module, services)
        {
        }

        /// <summary>
        /// Gets the characters in this room.
        /// </summary>
        public abstract IEnumerable<ICharacterController> Characters { get; }

        /// <summary>
        /// Gets the walk areas for this room.
        /// </summary>
        public abstract IWalkAreasController WalkAreas { get; }

        /// <summary>
        /// Gets the hotspots for this room.
        /// </summary>
        public abstract IHotspotsController Hotspots { get; }

        /// <summary>
        /// Adds character to this room.
        /// </summary>
        /// <typeparam name="T">Character by type.</typeparam>
        public abstract void AddCharacter<T>() where T : ICharacterModule;

        /// <summary>
        /// Removes character from this room.
        /// </summary>
        /// <typeparam name="T">Character by type.</typeparam>
        public abstract void RemoveCharacter<T>() where T : ICharacterModule;

        /// <summary>
        /// Removes character from this room.
        /// </summary>
        /// <param name="character">Character to remove.</param>
        public abstract void RemoveCharacter(ICharacterModule character);

        /// <summary>
        /// Adds item to this room.
        /// </summary>
        /// <typeparam name="T">Item by type.</typeparam>
        public abstract void AddItem<T>() where T : IItemModule;
    }
}
