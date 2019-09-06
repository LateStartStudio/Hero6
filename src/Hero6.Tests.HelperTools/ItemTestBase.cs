// <copyright file="ItemTestBase.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Items
{
    using LateStartStudio.Hero6.Engine.Campaigns.Items;
    using LateStartStudio.Hero6.Tests.HelperTools;
    using LateStartStudio.Hero6.Tests.HelperTools.Utilities;
    using NSubstitute;

    public abstract class ItemTestBase<TModule> : ModuleControllerTestBase<TModule, ItemController>
        where TModule : ItemModule
    {
        protected override ItemController MakeController() => Substitute.For<ItemController>(Module, Services.Services);
    }
}
