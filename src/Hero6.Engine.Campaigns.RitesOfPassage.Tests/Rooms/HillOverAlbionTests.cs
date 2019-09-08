// <copyright file="HillOverAlbionTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Engine.Campaigns.Characters;
using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Characters;
using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Items;
using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Rooms.Albion;
using LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions;
using LateStartStudio.Hero6.Localization;
using LateStartStudio.Hero6.Tests.HelperTools.Categories;
using NSubstitute;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Rooms
{
    [TestFixture]
    [Unit]
    public class HillOverAlbionTests : RoomTestBase<HillOverAlbion>
    {
        [Test]
        public void OnInitSpawnHero()
        {
            Controller.Received().AddCharacter<Hero>();
        }

        [Test]
        public void OnInitSpawnBentSword()
        {
            Controller.Received().AddItem<BentSword>();
        }

        [Test]
        public void WhenStandingInNorthExitMoveCharacterToFountain()
        {
            var hero = Services.Campaigns.Current.GetCharacter<Hero>();
            Module.Hotspots[HillOverAlbion.HotspotNorthExit].StandingOn.Invoke(new StandingOn(hero));
            hero.Received().ChangeRoom<Fountain>(Arg.Any<int>(), Arg.Any<int>(), CharacterDirection.CenterUp);
        }

        [Test]
        public void OnLookAlbionSignShowText()
        {
            Module.Hotspots[HillOverAlbion.HotspotAlbionSign].Look.Invoke();
            Services.UserInterfaces.Current.Received().ShowTextBox(Strings.AlbionSignLook);
        }

        [Test]
        public void OnGrabAlbionSignShowText()
        {
            Module.Hotspots[HillOverAlbion.HotspotAlbionSign].Grab.Invoke();
            Services.UserInterfaces.Current.Received().ShowTextBox(Strings.AlbionSignGrab);
        }

        [Test]
        public void OnTalkAlbionSignShowText()
        {
            Module.Hotspots[HillOverAlbion.HotspotAlbionSign].Talk.Invoke();
            Services.UserInterfaces.Current.Received().ShowTextBox(Strings.AlbionSignTalk);
        }

        protected override HillOverAlbion MakeModule() => new HillOverAlbion(Services.Campaigns, Services.UserInterfaces);

        protected override void PreInitialize()
        {
            base.PreInitialize();
            Module.Hotspots[HillOverAlbion.HotspotAlbionSign].Returns(Substitute.For<Hotspot>());
            Module.Hotspots[HillOverAlbion.HotspotNorthExit].Returns(Substitute.For<Hotspot>());
        }
    }
}
