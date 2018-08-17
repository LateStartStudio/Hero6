// <copyright file="HotspotModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions
{
    using LateStartStudio.Hero6.Engine.Assets.Graphics;

    public class HotspotsModule : GameModule<HotspotsController>
    {
        public override string Name => "Hotspots";

        public Hotspot this[Color color] => Controller[color];
    }
}
