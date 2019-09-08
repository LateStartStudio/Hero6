// <copyright file="Hotspot.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Rooms.Regions
{
    /// <summary>
    /// Hotspots are areas defined at design-time in a room that the user can interact with in various ways.
    /// </summary>
    public abstract class Hotspot
    {
        /// <summary>
        /// Gets or sets the look event.
        /// </summary>
        public Action Look { get; set; }

        /// <summary>
        /// Gets or sets the grab event.
        /// </summary>
        public Action Grab { get; set; }

        /// <summary>
        /// Gets or sets the talk event.
        /// </summary>
        public Action Talk { get; set; }

        /// <summary>
        /// Gets or sets the standing on event.
        /// </summary>
        public Action<StandingOn> StandingOn { get; set; }
    }
}
