// <copyright file="WalkAreasController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Services.DependencyInjection;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Rooms.Regions
{
    /// <summary>
    /// API for walk areas controller.
    /// </summary>
    public abstract class WalkAreasController : GameController<IWalkAreasController, IWalkAreasModule>, IWalkAreasController
    {
        /// <summary>
        /// Makes a new instance of the walk areas controller.
        /// </summary>
        protected WalkAreasController(IServiceLocator services)
            : base(new WalkAreasModule(), services)
        {
        }
    }
}
