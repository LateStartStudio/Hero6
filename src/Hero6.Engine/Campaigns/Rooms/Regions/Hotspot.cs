// <copyright file="Hotspot.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions
{
    using System;

    public abstract class Hotspot
    {
        public Action Look { get; set; }

        public Action Grab { get; set; }

        public Action Talk { get; set; }

        public Action<StandingOn> StandingOn { get; set; }
    }
}
