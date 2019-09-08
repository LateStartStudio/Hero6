// <copyright file="IHotspotsModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions
{
    using System.Drawing;

    public interface IHotspotsModule : IGameModule
    {
        Hotspot this[Color color] { get; }
    }
}
