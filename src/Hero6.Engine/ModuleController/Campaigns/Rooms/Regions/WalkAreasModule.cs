// <copyright file="WalkAreasModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Rooms.Regions
{
    /// <summary>
    /// API for walk areas module.
    /// </summary>
    public class WalkAreasModule : GameModule<WalkAreasController, WalkAreasModule>
    {
        /// <summary>
        /// Gets the walk areas name.
        /// </summary>
        public override string Name => "Walk Areas";
    }
}
