// <copyright file="RoomTestBase.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Engine.Campaigns.Rooms;
using LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions;
using LateStartStudio.Hero6.Tests.HelperTools;
using NSubstitute;

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Rooms
{
    public abstract class RoomTestBase<TModule> : ModuleControllerTestBase<TModule, RoomController>
        where TModule : RoomModule
    {
        protected override RoomController MakeController()
        {
            var controller = Substitute.For<RoomController>(Module, Services.Services);
            var hotspotsController = Substitute.For<HotspotsController>(Services.Services);
            hotspotsController.PreInitialize();
            hotspotsController.Initialize();
            controller.Hotspots.Returns(hotspotsController);
            return controller;
        }
    }
}
