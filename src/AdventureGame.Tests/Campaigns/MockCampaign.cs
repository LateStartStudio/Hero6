﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockCampaign.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the MockCampaign type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Campaigns
{
    using Assets;
    using UserInterfaces;

    public class MockCampaign : Campaign
    {
        private const string Id = "Mock Campaign";
        private const int Cap = 100;

        private static MockCampaign instance;

        private MockCampaign(Renderer renderer, MockAssetManager assets, MockUserInterface ui)
            : base(Id, Cap, renderer, assets, ui)
        {
        }

        public static MockCampaign Instance
        {
            get
            {
                if (instance == null)
                {
                    MockRenderer renderer = new MockRenderer();
                    MockAssetManager assets = new MockAssetManager();
                    MockUserInterface ui = new MockUserInterface(renderer, assets);

                    instance = new MockCampaign(renderer, assets, ui);
                }

                return instance;
            }
        }
    }
}
