// <copyright file="WalkAreasController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions
{
    public abstract class WalkAreasController : GameController<WalkAreasController, WalkAreasModule>
    {
        protected WalkAreasController(WalkAreasModule module)
            : base(module)
        {
        }
    }
}
