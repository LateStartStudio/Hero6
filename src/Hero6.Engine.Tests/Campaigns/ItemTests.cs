// <copyright file="ItemTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ItemTests : TestBase
    {
        private ItemMock item;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            this.item = (ItemMock)Campaign.GetItem(CampaignMock.Item1);
        }

        [TestCase(0)]
        public void WidthGet(int w) => Assert.That(item.Width, Is.EqualTo(w));

        [TestCase(0)]
        public void HeightGet(int h) => Assert.That(item.Height, Is.EqualTo(h));

        [Test]
        public void Update()
        {
            Assume.That(item.IsUpdateInvoked, Is.False);
            item.Update(TimeSpan.Zero, TimeSpan.Zero, false);
            Assert.That(item.IsUpdateInvoked, Is.True);
        }

        [Test]
        public void Draw()
        {
            Assume.That(item.IsDrawInvoked, Is.False);
            item.Draw(TimeSpan.Zero, TimeSpan.Zero, false);
            Assert.That(item.IsDrawInvoked, Is.True);
        }

        [TestCase(Interaction.Mouth)]
        [TestCase(Interaction.Eye)]
        [TestCase(Interaction.Hand)]
        public void InteractEye(Interaction i) => Assert.That(item.Interact(0, 0, i), Is.True);

        [Test]
        public void InteractFalseWhenNotVisible()
        {
            item.IsVisible = false;
            Assert.That(item.Interact(0, 0, Interaction.Eye), Is.False);
        }

        [Test]
        public void InteractFalseWhenXAndYOutsideBounds()
        {
            Assert.That(item.Interact(item.Width + 1, item.Height + 1, Interaction.Eye), Is.False);
        }

        [Test]
        public void InteractNotSupportedExceptionOnMove()
        {
            Assert.Throws<NotSupportedException>(() => item.Interact(0, 0, Interaction.Move));
        }
    }
}
