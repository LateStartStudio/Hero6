// <copyright file="HotspotsController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Drawing;
using LateStartStudio.Hero6.Services.DependencyInjection;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Rooms.Regions
{
    /// <summary>
    /// API for the hotspots controller.
    /// </summary>
    public abstract class HotspotsController : GameController<HotspotsController, HotspotsModule>
    {
        /// <summary>
        /// Makes a new <see cref="HotspotsController"/> instance.
        /// </summary>
        protected HotspotsController(IServiceLocator services) : base(new HotspotsModule(), services)
        {
        }

        /// <summary>
        /// Gets the hotspot using the color value from the hotspots mask as a key.
        /// </summary>
        /// <param name="color">The color key in the hotspot mask.</param>
        /// <returns>The hotspot from the mask with the color value.</returns>
        public abstract Hotspot this[Color color] { get; }
    }
}
