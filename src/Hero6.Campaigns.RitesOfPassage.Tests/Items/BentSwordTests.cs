// <copyright file="BentSwordTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Localization;
using LateStartStudio.Hero6.ModuleController.Campaigns.Items;
using LateStartStudio.Hero6.Tests.Categories;
using NSubstitute;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Campaigns.RitesOfPassage.Items
{
    [TestFixture]
    [UnitCategory]
    public class BentSwordTests : ItemTestBase<BentSword>
    {
        [Test]
        public void OnLookShowsText()
        {
            Module.Look();
            Services.UserInterfaces.Current.Received().ShowTextBox(Strings.BentSwordLook);
        }

        [Test]
        public void OnGrabHide()
        {
            Module.IsVisible = true;
            Module.Grab();
            Assert.That(Module.IsVisible, Is.False);
        }

        [Test]
        public void OnGrabShowsText()
        {
            Module.Grab();
            Services.UserInterfaces.Current.Received().ShowTextBox(Strings.BentSwordGrab);
        }

        [Test]
        public void OnGrabAddToPlayerInventory()
        {
            Module.Grab();
            Services.Campaigns.Current.Player.Received().AddInventoryItem<InventoryItems.BentSword>();
        }

        [Test]
        public void OnTalkShowsText()
        {
            Module.Talk();
            Services.UserInterfaces.Current.Received().ShowTextBox(Strings.BentSwordTalk);
        }

        protected override BentSword MakeModule() => new BentSword(Services.UserInterfaces, Services.Campaigns);
    }
}
