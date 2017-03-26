// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockCampaign.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the MockCampaign type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame
{
    using Engine;
    using UI;

    public class MockCampaign : Campaign
    {
        private const string Id = "Mock Campaign";
        private const int Cap = 100;

        private static MockCampaign instance;

        private MockCampaign(MockEngine engine, MockContentManager content, MockUserInterface ui)
            : base(Id, Cap, engine, content, ui)
        {
        }

        public static MockCampaign Instance
        {
            get
            {
                if (instance == null)
                {
                    MockEngine engine = new MockEngine();
                    MockContentManager content = new MockContentManager();
                    MockUserInterface ui = new MockUserInterface(engine, content);

                    instance = new MockCampaign(engine, content, ui);
                }

                return instance;
            }
        }
    }
}
