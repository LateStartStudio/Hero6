// <copyright file="ItemTestBase.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using NSubstitute;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Items
{
    public abstract class ItemTestBase<TModule> : ModuleControllerTestBase<TModule, ItemController>
        where TModule : ItemModule
    {
        protected override ItemController MakeController() => Substitute.For<ItemController>(Module, Services.Services);
    }
}
