// <copyright file="UserInterfaceTestBase.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using NSubstitute;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces
{
    public abstract class UserInterfaceTestBase<TModule> : ModuleControllerTestBase<TModule, UserInterfaceController>
        where TModule : UserInterfaceModule
    {
        protected override UserInterfaceController MakeController() => Substitute.For<UserInterfaceController>(Module, Services.Services);
    }
}
