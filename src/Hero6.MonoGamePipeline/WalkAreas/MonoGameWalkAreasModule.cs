// <copyright file="MonoGameWalkAreasModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.MonoGamePipeline.WalkAreas
{
    using System.Collections.Generic;
    using LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions;

    /// <summary>
    /// Our MonoGame implementation for walk areas.
    /// </summary>
    public class MonoGameWalkAreasModule : WalkAreasModule
    {
        /// <summary>
        /// Makes a new <see cref="MonoGameWalkAreasModule"/> instance.
        /// </summary>
        /// <param name="areas">The walk areas.</param>
        public MonoGameWalkAreasModule(IEnumerable<WalkArea> areas)
        {
            Areas = new List<WalkArea>(areas);
        }

        /// <summary>
        /// Gets the walk areas name.
        /// </summary>
        public override string Name { get; }

        /// <summary>
        /// Gets teh walk areas.
        /// </summary>
        public IEnumerable<WalkArea> Areas { get; }
    }
}
