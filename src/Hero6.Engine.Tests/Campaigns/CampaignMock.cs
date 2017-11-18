// <copyright file="CampaignMock.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using Assets;
    using UserInterfaces;

    public class CampaignMock : Campaign
    {
        private const string Id = "Mock Campaign";
        private const int Cap = 100;

        static CampaignMock()
        {
            Renderer = new RendererMock();
        }

        private CampaignMock(AssetManager assets, UserInterface ui)
            : base(Id, Cap, assets, ui)
        {
        }

        public static CampaignMock Make()
        {
            MockAssetManager assets = new MockAssetManager();
            MockUserInterface ui = new MockUserInterface(assets, null);

            return new CampaignMock(assets, ui);
        }
    }
}
