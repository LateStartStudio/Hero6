// <copyright file="IHotspotsController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Drawing;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Rooms.Regions
{
    public interface IHotspotsController : IGameController
    {
        IHotspotsModule Module { get; }

        /// <summary>
        /// Gets the hotspot using the color value from the hotspots mask as a key.
        /// </summary>
        /// <param name="color">The color key in the hotspot mask.</param>
        /// <returns>The hotspot from the mask with the color value.</returns>
        Hotspot this[Color color] { get; }
    }
}
