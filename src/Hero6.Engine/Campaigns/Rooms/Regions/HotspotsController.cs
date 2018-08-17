// <copyright file="HotspotController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions
{
    using LateStartStudio.Hero6.Engine.Assets.Graphics;

    public abstract class HotspotsController : GameController<HotspotsController, HotspotsModule>
    {
        protected HotspotsController()
            : base(new HotspotsModule())
        {
        }

        public abstract Hotspot this[Color color] { get; }
    }
}
