// <copyright file="TestBase.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using LateStartStudio.Hero6.Engine.Assets;
    using NUnit.Framework;

    public class TestBase
    {
        protected CampaignMock Campaign { get; private set; }

        [SetUp]
        public virtual void SetUp()
        {
            RendererMock.IsPaused = false;
            RendererMock.IsDrawInvoked = false;
            RendererMock.IsDrawStringInvoked = false;
            Campaign = CampaignMock.Make();
            Campaign.Load();
        }

        [TearDown]
        public virtual void TearDown()
        {
            Campaign.Unload();
        }
    }
}
