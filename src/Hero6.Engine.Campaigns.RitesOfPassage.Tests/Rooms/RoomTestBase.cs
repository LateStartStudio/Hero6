// <copyright file="RoomTestBase.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Rooms
{
    using LateStartStudio.Hero6.Engine.Campaigns.Rooms;
    using NUnit.Framework;

    public class RoomTestBase<TModule> : TestBase
        where TModule : RoomModule
    {
        protected RoomController Controller { get; private set; }

        protected TModule Module { get; private set; }

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Controller = Services.CampaignController.GetRoom<TModule>();
            Module = Services.Campaigns.Current.GetRoom<TModule>();
        }
    }
}
