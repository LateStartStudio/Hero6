// <copyright file="ItemTestBase.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using NSubstitute;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Items
{
    public abstract class ItemTestBase<TModule> : ModuleControllerTestBase<TModule, IItemController>
        where TModule : ItemModule
    {
        protected override IItemController MakeController() => Substitute.For<IItemController>();
    }
}
