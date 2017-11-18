// <copyright file="MockCampaign.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using Assets;
    using UserInterfaces;

    public class MockCampaign : Campaign
    {
        private const string Id = "Mock Campaign";
        private const int Cap = 100;

        private static MockCampaign instance;

        private MockCampaign(MockAssetManager assets, MockUserInterface ui)
            : base(Id, Cap, assets, ui)
        {
        }

        public static MockCampaign Instance
        {
            get
            {
                if (instance == null)
                {
                    Campaign.Renderer = new RendererMock();
                    MockAssetManager assets = new MockAssetManager();
                    MockUserInterface ui = new MockUserInterface(assets, null);

                    instance = new MockCampaign(assets, ui);
                }

                return instance;
            }
        }
    }
}
