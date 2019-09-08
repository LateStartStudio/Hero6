// <copyright file="LlewellaTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Engine.Campaigns.Animations;
using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Animations.Characters.Llewella.Idle;
using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.InventoryItems;
using LateStartStudio.Hero6.Localization;
using LateStartStudio.Hero6.Tests.HelperTools.Categories;
using NSubstitute;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Characters
{
    [TestFixture]
    [Unit]
    public class LlewellaTests : CharacterTestBase<Llewella>
    {
        [Test]
        public void OnLookShowText()
        {
            Module.Look();
            Services.UserInterfaces.Current.Received().ShowTextBox(Strings.LlewellaLook);
        }

        [Test]
        public void OnGrabShowText()
        {
            Module.Grab();
            Services.UserInterfaces.Current.Received().ShowTextBox(Strings.LlewellaGrab);
        }

        [Test]
        public void OnTalkShowTextWhenNoOneHasBentSword()
        {
            Module.Talk();
            Services.UserInterfaces.Current.Received().ShowTextBox(Strings.LlewellaTalk2);
        }

        [Test]
        public void OnTalkShowTextWhenHeroHasBentSword()
        {
            Services.Campaigns.Current.Player.HasInventoryItem<BentSword>().Returns(true);
            Module.Talk();
            Services.UserInterfaces.Current.Received().ShowTextBox(Strings.LlewellaTalk1);
        }

        [Test]
        public void OnTalkPlayerLoseBentSwordWhenInPlayerInventory()
        {
            Services.Campaigns.Current.Player.HasInventoryItem<BentSword>().Returns(true);
            Module.Talk();
            Services.Campaigns.Current.Player.Received().RemoveInventoryItem<BentSword>();
        }

        [Test]
        public void OnTalkShowTextWhenBentSwordInLlewellaInventory()
        {
            Controller.HasInventoryItem<BentSword>().Returns(true);
            Module.Talk();
            Services.UserInterfaces.Current.Received().ShowTextBox(Strings.LlewellaTalk3);
        }

        protected override Llewella MakeModule() => new Llewella(Services.UserInterfaces, Services.Campaigns);

        protected override void PreInitialize()
        {
            base.PreInitialize();
            Services.Campaigns.Current.GetCharacterAnimation<LlewellaIdle>().Returns(Substitute.For<CharacterAnimationModule>());
        }
    }
}
