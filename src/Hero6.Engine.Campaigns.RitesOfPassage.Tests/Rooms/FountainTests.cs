// <copyright file="FountainTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Rooms
{
    using LateStartStudio.Hero6.Engine.Campaigns.Characters;
    using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Characters;
    using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Rooms.Albion;
    using LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions;
    using LateStartStudio.Hero6.Localization;
    using NSubstitute;
    using NUnit.Framework;

    public class FountainTests : RoomTestBase<Fountain>
    {
        [Test]
        public void SpawnLlewellaOnInit()
        {
            Controller.Received().AddCharacter<Llewella>();
        }

        [Test]
        public void WhenStandingInSouthExitMoveCharacterToHillOverAlbion()
        {
            var hero = Services.CampaignController.GetCharacter<Hero>();
            Module.Hotspots[Module.HotspotSouthExit].StandingOn.Invoke(new StandingOn(hero));
            hero.Received().ChangeRoom<HillOverAlbion>(Arg.Any<int>(), Arg.Any<int>(), CharacterDirection.CenterDown);
        }

        [Test]
        public void OnLookFountainShowText()
        {
            Module.Hotspots[Module.HotspotFountainSpot].Look.Invoke();
            Services.UserInterfaces.Current.Received().ShowTextBox(Strings.FountainLook);
        }

        [Test]
        public void OnGrabFountainShowText()
        {
            Module.Hotspots[Module.HotspotFountainSpot].Grab.Invoke();
            Services.UserInterfaces.Current.Received().ShowTextBox(Strings.FountainGrab);
        }

        [Test]
        public void OnTalkFountainShowText()
        {
            Module.Hotspots[Module.HotspotFountainSpot].Talk.Invoke();
            Services.UserInterfaces.Current.Received().ShowTextBox(Strings.FountainTalk);
        }
    }
}
