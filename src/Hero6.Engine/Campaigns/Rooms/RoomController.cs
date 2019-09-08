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
    using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;

    /// <summary>
    /// API for room controller.
    /// </summary>
    public abstract class RoomController : GameController<RoomController, RoomModule>
    {
        /// <summary>
        /// Makes a new <see cref="RoomController"/> instance.
        /// </summary>
        /// <param name="module">The module for this controller.</param>
        protected RoomController(RoomModule module, IServices services)
            : base(module, services)
        {
        }

        /// <summary>
        /// Gets the characters in this room.
        /// </summary>
        public abstract IEnumerable<CharacterController> Characters { get; }

        /// <summary>
        /// Gets the walk areas for this room.
        /// </summary>
        public abstract WalkAreasController WalkAreas { get; }

        /// <summary>
        /// Gets the hotspots for this room.
        /// </summary>
        public abstract HotspotsController Hotspots { get; }

        /// <summary>
        /// Adds character to this room.
        /// </summary>
        /// <typeparam name="T">Character by type.</typeparam>
        public abstract void AddCharacter<T>() where T : CharacterModule;

        /// <summary>
        /// Adds item to this room.
        /// </summary>
        /// <typeparam name="T">Item by type.</typeparam>
        public abstract void AddItem<T>() where T : ItemModule;
    }
}
