// <copyright file="FountainTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Campaigns.RitesOfPassage.Characters;
using LateStartStudio.Hero6.Localization;
using LateStartStudio.Hero6.ModuleController.Campaigns.Characters;
using LateStartStudio.Hero6.ModuleController.Campaigns.Rooms;
using LateStartStudio.Hero6.ModuleController.Campaigns.Rooms.Regions;
using LateStartStudio.Hero6.Tests.Categories;
using NSubstitute;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Campaigns.RitesOfPassage.Rooms.Albion
{
    [TestFixture]
    [UnitCategory]
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
            var hero = Services.Campaigns.Current.GetCharacter<Hero>();
            Module.Hotspots[Fountain.HotspotSouthExit].StandingOn.Invoke(new StandingOn(hero));
            hero.Received().ChangeRoom<HillOverAlbion>(Arg.Any<int>(), Arg.Any<int>(), CharacterDirection.CenterDown);
        }

        [Test]
        public void OnLookFountainShowText()
        {
            Module.Hotspots[Fountain.HotspotFountainSpot].Look.Invoke();
            Services.UserInterfaces.Current.Received().ShowTextBox(Strings.FountainLook);
        }

        [Test]
        public void OnGrabFountainShowText()
        {
            Module.Hotspots[Fountain.HotspotFountainSpot].Grab.Invoke();
            Services.UserInterfaces.Current.Received().ShowTextBox(Strings.FountainGrab);
        }

        [Test]
        public void OnTalkFountainShowText()
        {
            Module.Hotspots[Fountain.HotspotFountainSpot].Talk.Invoke();
            Services.UserInterfaces.Current.Received().ShowTextBox(Strings.FountainTalk);
        }

        protected override Fountain MakeModule() => new Fountain(Services.Campaigns, Services.UserInterfaces);

        protected override void PreInitialize()
        {
            base.PreInitialize();
            Services.Campaigns.Current.GetCharacter<Llewella>().Returns(Substitute.For<ICharacterModule>());
            Module.Hotspots[Fountain.HotspotFountainSpot].Returns(Substitute.For<Hotspot>());
            Module.Hotspots[Fountain.HotspotSouthExit].Returns(Substitute.For<Hotspot>());
        }
    }
}
