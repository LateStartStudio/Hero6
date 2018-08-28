﻿// <copyright file="WalkAreasController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions
{
    /// <summary>
    /// API for walk areas controller.
    /// </summary>
    public abstract class WalkAreasController : GameController<WalkAreasController, WalkAreasModule>
    {
        /// <summary>
        /// Makes a new instance of the walk areas controller.
        /// </summary>
        /// <param name="module">The module for this controller.</param>
        protected WalkAreasController(WalkAreasModule module)
            : base(module)
        {
        }
    }
}
