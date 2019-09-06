// <copyright file="WalkAreasController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions
{
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;

    /// <summary>
    /// API for walk areas controller.
    /// </summary>
    public abstract class WalkAreasController : GameController<WalkAreasController, WalkAreasModule>
    {
        /// <summary>
        /// Makes a new instance of the walk areas controller.
        /// </summary>
        protected WalkAreasController(IServices services)
            : base(new WalkAreasModule(), services)
        {
        }
    }
}
