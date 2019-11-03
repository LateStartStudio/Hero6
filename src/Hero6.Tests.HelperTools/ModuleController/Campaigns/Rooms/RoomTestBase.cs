// <copyright file="RoomTestBase.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.ModuleController.Campaigns.Rooms.Regions;
using NSubstitute;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Rooms
{
    public abstract class RoomTestBase<TModule> : ModuleControllerTestBase<TModule, IRoomController>
        where TModule : IRoomModule
    {
        protected override IRoomController MakeController()
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
