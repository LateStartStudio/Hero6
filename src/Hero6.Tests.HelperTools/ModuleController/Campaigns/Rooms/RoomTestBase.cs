// <copyright file="RoomTestBase.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using NSubstitute;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Rooms
{
    public abstract class RoomTestBase<TModule> : ModuleControllerTestBase<TModule, IRoomController>
        where TModule : IRoomModule
    {
        protected override IRoomController MakeController() => Substitute.For<IRoomController>();
    }
}
