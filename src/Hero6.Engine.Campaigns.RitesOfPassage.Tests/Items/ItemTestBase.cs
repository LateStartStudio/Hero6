// <copyright file="ItemTestBase.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Items
{
    using LateStartStudio.Hero6.Engine.Campaigns.Items;
    using NUnit.Framework;

    public class ItemTestBase<TModule> : TestBase
        where TModule : ItemModule
    {
        protected ItemController Controller { get; private set; }

        protected TModule Module { get; private set; }

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Controller = Services.CampaignController.GetItem<TModule>();
            Module = Services.Campaigns.Current.GetItem<TModule>();
        }
    }
}
