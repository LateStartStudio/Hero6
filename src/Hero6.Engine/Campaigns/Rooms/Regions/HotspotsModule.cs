// <copyright file="HotspotsModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Drawing;

namespace LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions
{
    /// <summary>
    /// API for the hotspots module.
    /// </summary>
    public class HotspotsModule : GameModule<HotspotsController, HotspotsModule>, IHotspotsModule
    {
        /// <summary>
        /// Gets the hotspots name.
        /// </summary>
        public override string Name => "Hotspots";

        /// <summary>
        /// Gets the hotspot using the color value from the hotspots mask as a key.
        /// </summary>
        /// <param name="color">The color key in the hotspot mask.</param>
        /// <returns>The hotspot from the mask with the color value.</returns>
        public Hotspot this[Color color] => Controller[color];
    }
}
