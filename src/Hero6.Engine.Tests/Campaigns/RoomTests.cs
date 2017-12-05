// <copyright file="RoomTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using System;
    using System.Collections.Generic;
    using LateStartStudio.Hero6.Engine.Assets;
    using LateStartStudio.Hero6.Engine.Assets.Graphics;
    using NUnit.Framework;

    [TestFixture]
    public class RoomTests : TestBase
    {
        private RoomMock room;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            this.room = (RoomMock)Campaign.GetRoom(CampaignMock.Room1);
        }

        [Test]
        public void CharactersGet()
        {
            Room newRoom = new RoomMock(CampaignMock.Make(), "0:0:0", "0:0:0", "0:0:0");
            Assert.That(newRoom.Characters, Is.EqualTo(new List<Character>()));
        }

        [Test]
        public void ItemsGet()
        {
            Room newRoom = new RoomMock(CampaignMock.Make(), "0:0:0", "0:0:0", "0:0:0");
            Assert.That(newRoom.Items, Is.EqualTo(new List<Item>()));
        }

        [Test]
        public void WidthGet() => Assert.That(room.Width, Is.EqualTo(3));

        [Test]
        public void HeightGet() => Assert.That(room.Height, Is.EqualTo(3));

        [Test]
        public void InteractWalkReturnFalseWhenOutOfBounds()
        {
            Assert.That(room.Interact(int.MaxValue, int.MaxValue, Interaction.Move), Is.False);
        }

        [TestCase(Interaction.Eye)]
        [TestCase(Interaction.Hand)]
        [TestCase(Interaction.Mouth)]
        public void InteractOnCharacterReturnTrue(Interaction interaction)
        {
            Assert.That(room.Interact(0, 0, interaction), Is.True);
        }

        [TestCase(Interaction.Eye)]
        [TestCase(Interaction.Hand)]
        [TestCase(Interaction.Mouth)]
        public void InteractOnItemReturnTrue(Interaction interaction)
        {
            room.Characters.Clear();
            Assert.That(room.Interact(0, 0, interaction), Is.True);
        }

        [Test]
        public void InteractEyeOnHotSpot()
        {
            bool res = false;

            // Remove characters and items to avoid mouse click intersections
            ////room.Characters.Clear();
            ////room.Items.Clear();

            room.Hotspots[new Color(255, 0, 0, 0)].Look += (s, a) => res = true;
            room.Interact(0, 0, Interaction.Eye);
            Assert.That(res, Is.True);
        }

        [Test]
        public void InteractGrabOnHotSpot()
        {
            bool res = false;

            // Remove characters and items to avoid mouse click intersections
            room.Characters.Clear();
            room.Items.Clear();

            room.Hotspots[new Color(255, 0, 0, 0)].Grab += (s, a) => res = true;
            room.Interact(0, 0, Interaction.Hand);
            Assert.That(res, Is.True);
        }

        [Test]
        public void InteractMouthOnHotSpot()
        {
            bool res = false;

            // Remove characters and items to avoid mouse click intersections
            room.Characters.Clear();
            room.Items.Clear();

            room.Hotspots[new Color(255, 0, 0, 0)].Talk += (s, a) => res = true;
            room.Interact(0, 0, Interaction.Mouth);
            Assert.That(res, Is.True);
        }

        [Test]
        public void InteractOnHotspotIsFalseWhenArgumentInvalid()
        {
            // Remove characters and items to avoid mouse click intersections
            room.Characters.Clear();
            room.Items.Clear();

            Assert.That(room.Interact(0, 0, (Interaction)int.MaxValue), Is.False);
        }

        [Test]
        public void UpdateIsInvoked()
        {
            bool res = false;
            room.PostUpdate += (s, a) => res = true;
            room.Update(TimeSpan.Zero, TimeSpan.Zero, false);
            Assert.That(res, Is.True);
        }

        [Test]
        public void DrawIsInvoked()
        {
            Assume.That(RendererMock.IsDrawInvoked, Is.False);
            room.Draw(TimeSpan.Zero, TimeSpan.Zero, false);
            Assert.That(RendererMock.IsDrawInvoked, Is.True);
        }
    }
}
