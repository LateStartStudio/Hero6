// <copyright file="AdventureGameElementTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using System;
    using LateStartStudio.Hero6.Engine.Assets.Graphics;
    using LateStartStudio.Hero6.Engine.UserInterfaces;
    using NUnit.Framework;

    [TestFixture]
    public class AdventureGameElementTests : TestBase
    {
        private AdventureGameElementMock element;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            this.element = new AdventureGameElementMock(Campaign);
            element.Load();
        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();

            element.Unload();
        }

        [TestCase(1, 2)]
        [TestCase(3, 4)]
        public void GetAndSetLocation(int x, int y)
        {
            Point location = new Point(x, y);
            element.Location = location;
            Assert.That(element.Location, Is.EqualTo(location));
        }

        [Test]
        public void GetWidth() => Assert.That(element.Width, Is.EqualTo(0));

        [Test]
        public void GetHeight() => Assert.That(element.Height, Is.EqualTo(0));

        [Test]
        public void IsVisibleDefaultTrue() => Assert.That(element.IsVisible, Is.True);

        [Test]
        public void GetAndSetIsVisible()
        {
            Assume.That(element.IsVisible, Is.Not.False);
            element.IsVisible = false;
            Assert.That(element.IsVisible, Is.False);
        }

        [TestCase(Interaction.Mouth)]
        [TestCase(Interaction.Eye)]
        [TestCase(Interaction.Hand)]
        [TestCase(Interaction.Move)]
        public void Interact(Interaction i) => Assert.That(element.Interact(0, 0, i), Is.True);

        [TestCase("Test Display")]
        public void Display(string text)
        {
            Assume.That(((MockUserInterface)Campaign.UserInterface).IsShowTextBoxInvoked, Is.False);
            element.Display(text);
            Assert.That(((MockUserInterface)Campaign.UserInterface).IsShowTextBoxInvoked, Is.True);
        }

        [Test]
        public void Update()
        {
            Assume.That(element.IsUpdateInvoked, Is.False);
            element.Update(TimeSpan.Zero, TimeSpan.Zero, false);
            Assert.That(element.IsUpdateInvoked, Is.True);
        }

        [Test]
        public void Draw()
        {
            Assume.That(element.IsDrawInvoked, Is.False);
            element.Draw(TimeSpan.Zero, TimeSpan.Zero, false);
            Assert.That(element.IsDrawInvoked, Is.True);
        }
    }
}
