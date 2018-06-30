// <copyright file="MockCampaign.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using NSubstitute;
    using Utilities.DependencyInjection;

    public class MockCampaign : Campaign
    {
        private const string Id = "Mock Campaign";
        private const int Cap = 100;

        private static MockCampaign instance;

        static MockCampaign()
        {
            ServicesBank.Instance = Substitute.For<IServices>();
        }

        private MockCampaign()
            : base(Id, Cap)
        {
        }

        public static MockCampaign Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MockCampaign();
                }

                return instance;
            }
        }
    }
}
