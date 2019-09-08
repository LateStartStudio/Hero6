// <copyright file="HeroTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Characters
{
    using LateStartStudio.Hero6.Engine.Campaigns.Animations;
    using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Animations.Characters.Hero.Idle;
    using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Animations.Characters.Hero.Walk;
    using LateStartStudio.Hero6.Localization;
    using LateStartStudio.Hero6.Tests.HelperTools.Categories;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    [Unit]
    public class HeroTests : CharacterTestBase<Hero>
    {
        [Test]
        public void OnLookShowsText()
        {
            Module.Look();
            Services.UserInterfaces.Current.Received().ShowTextBox(Strings.HeroLook);
        }

        [Test]
        public void OnGrabShowsText()
        {
            Module.Grab();
            Services.UserInterfaces.Current.Received().ShowTextBox(Strings.HeroGrab);
        }

        [Test]
        public void OnTalkShowsText()
        {
            Module.Talk();
            Services.UserInterfaces.Current.Received().ShowTextBox(Strings.HeroTalk);
        }

        protected override Hero MakeModule() => new Hero(Services.UserInterfaces, Services.Campaigns);

        protected override void PreInitialize()
        {
            base.PreInitialize();
            Services.Campaigns.Current.GetCharacterAnimation<HeroIdle>().Returns(Substitute.For<CharacterAnimationModule>());
            Services.Campaigns.Current.GetCharacterAnimation<HeroWalk>().Returns(Substitute.For<CharacterAnimationModule>());
        }
    }
}
