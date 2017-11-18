// <copyright file="InventoryItemTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class InventoryItemTests : TestBase
    {
        private InventoryItemMock inventoryItem;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            this.inventoryItem = (InventoryItemMock)Campaign.GetInventoryItem(CampaignMock.InventoryItem1);
        }

        [TestCase(0)]
        public void WidthGet(int w) => Assert.That(inventoryItem.Width, Is.EqualTo(w));

        [TestCase(0)]
        public void HeightGet(int h) => Assert.That(inventoryItem.Height, Is.EqualTo(h));

        [Test]
        public void Update()
        {
            Assume.That(inventoryItem.IsUpdateInvoked, Is.False);
            inventoryItem.Update(TimeSpan.Zero, TimeSpan.Zero, false);
            Assert.That(inventoryItem.IsUpdateInvoked, Is.True);
        }

        [Test]
        public void Draw()
        {
            Assume.That(inventoryItem.IsDrawInvoked, Is.False);
            inventoryItem.Draw(TimeSpan.Zero, TimeSpan.Zero, false);
            Assert.That(inventoryItem.IsDrawInvoked, Is.True);
        }

        [TestCase(Interaction.Mouth)]
        [TestCase(Interaction.Eye)]
        [TestCase(Interaction.Hand)]
        [TestCase(Interaction.Mouth)]
        public void Interact(Interaction interaction)
        {
            Assert.That(inventoryItem.Interact(0, 0, interaction), Is.True);
        }
    }
}
