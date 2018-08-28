// <copyright file="HotspotsModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions
{
    using LateStartStudio.Hero6.Engine.Assets.Graphics;

    /// <summary>
    /// API for the hotspots module.
    /// </summary>
    public class HotspotsModule : GameModule<HotspotsController>
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
