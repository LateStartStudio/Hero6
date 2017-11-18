// <copyright file="CharacterTests.cs" company="Late Start Studio">
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
    public class CharacterTests : TestBase
    {
        private CharacterMock character;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            this.character = (CharacterMock)Campaign.GetCharacter(CampaignMock.Character1);
        }

        [Test]
        public void AnimationGetAndSet()
        {
            CharacterAnimation expected = new CharacterAnimationMock(Campaign);
            character.Animation = expected;
            Assert.That(character.Animation, Is.EqualTo(expected));
        }

        [Test]
        public void MovementPathGetAndSet()
        {
            Queue<Point> expected = new Queue<Point>();
            character.MovementPath = expected;
            Assert.That(character.MovementPath, Is.EqualTo(expected));
        }

        [Test]
        public void InventoryGetAndSet()
        {
            IList<InventoryItem> expected = new List<InventoryItem>();
            character.Inventory = expected;
            Assert.That(character.Inventory, Is.EqualTo(expected));
        }

        [Test]
        public void LocationGetAndSet()
        {
            Point expected = default(Point);
            character.Location = expected;
            Assert.That(character.Location, Is.EqualTo(expected));
            Assert.That(character.Animation.Location, Is.EqualTo(new Point(-50, -100)));
        }

        [Test]
        public void WidthGet()
        {
            Assert.That(character.Width, Is.EqualTo(character.Animation.Width));
        }

        [Test]
        public void HeightGet()
        {
            Assert.That(character.Height, Is.EqualTo(character.Animation.Height));
        }

        [Test]
        public void IsPlayerGet() => Assert.That(character.IsPlayer, Is.False);

        [TestCase(30)]
        public void SpeedGetAndSet(int expected)
        {
            character.Speed = expected;
            Assert.That(character.Speed, Is.EqualTo(expected));
        }

        [Test]
        public void InventoryAddRemoveHas()
        {
            InventoryItem item = new InventoryItemMock(Campaign, "Item");
            Assert.That(character.HasInventory(item), Is.False);
            character.AddInventory(item);
            Assert.That(character.HasInventory(item), Is.True);
            character.RemoveInventory(item);
            Assert.That(character.HasInventory(item), Is.False);
        }

        [Test]
        public void ChangeRoomClearsMovementPath()
        {
            character.MovementPath.Enqueue(default(Point));
            Assert.That(character.MovementPath.Count, Is.GreaterThan(0));
            character.ChangeRoom(CampaignMock.Room2);
            Assert.That(character.MovementPath.Count, Is.EqualTo(0));
        }

        [Test]
        public void ChangeRoomSetsLocation()
        {
            Point location = new Point(5, 9);
            Assert.That(character.Location, Is.Not.EqualTo(location));
            character.ChangeRoom(CampaignMock.Room2, location.X, location.Y);
            Assert.That(character.Location, Is.EqualTo(location));
        }

        [Test]
        public void ChangeRoomIsSuccessful()
        {
            Point location = new Point(5, 5);
            Assume.That(Campaign.GetRoom(CampaignMock.Room1).Characters.Contains(character), Is.True);
            Assume.That(Campaign.GetRoom(CampaignMock.Room2).Characters.Contains(character), Is.Not.True);
            character.ChangeRoom(CampaignMock.Room2, location.X, location.Y);
            Assert.That(Campaign.GetRoom(CampaignMock.Room1).Characters.Contains(character), Is.False);
            Assert.That(Campaign.GetRoom(CampaignMock.Room2).Characters.Contains(character), Is.True);
        }

        [Test]
        public void InteractIsFalseWhenXAndYIsOutOfBounds()
        {
            Assert.That(character.Interact(9999, 999, Interaction.Eye), Is.False);
        }

        [TestCase(Interaction.Eye)]
        [TestCase(Interaction.Hand)]
        [TestCase(Interaction.Mouth)]
        public void InteractIsTrueWhenSupportedInteraction(Interaction interaction)
        {
            Assert.That(character.Interact(0, 0, interaction));
        }

        [Test]
        public void InteractThrowsNotSupportedExceptionOnMove()
        {
            Assert.Throws<NotSupportedException>(() => character.Interact(0, 0, Interaction.Move));
        }

        [Test]
        public void UpdateIsFalseWhenNotInvoked()
        {
            Assert.That(character.IsUpdateInvoked, Is.False);
        }

        [Test]
        public void UpdateIsTrueWhenInvoked()
        {
            character.Update(TimeSpan.Zero, TimeSpan.Zero, false);
            Assert.That(character.IsUpdateInvoked, Is.True);
        }

        [Test]
        public void AnimationIsMovingIsFalseWhenMovementPathIsEmptyAfterUpdateIsInvoked()
        {
            character.Update(TimeSpan.Zero, TimeSpan.Zero, false);
            Assert.That(character.Animation.IsMoving, Is.False);
        }

        [Test]
        public void AnimationIsMovingIsTrueWhenMovementPathIsNotEmptyAfterUpdateIsInvoked()
        {
            character.MovementPath.Enqueue(default(Point));
            character.Update(TimeSpan.Zero, TimeSpan.Zero, false);
            Assert.That(character.Animation.IsMoving, Is.True);
        }

        [Test]
        public void MoveCharacterAlongPath()
        {
            Point[] path = { new Point(0, 0), new Point(0, 1), new Point(0, 2), new Point(0, 3) };
            character.MovementPath = new Queue<Point>(path);

            foreach (Point p in path)
            {
                character.Update(TimeSpan.Zero, TimeSpan.FromSeconds(1.0 / character.Speed), false);
                Assert.That(character.Location, Is.EqualTo(p));
            }
        }

        [Test]
        public void DrawIsTrueWhenVisible()
        {
            character.IsVisible = true;
            character.Draw(TimeSpan.Zero, TimeSpan.Zero, false);
            Assert.That(RendererMock.IsDrawInvoked, Is.True);
        }

        [Test]
        public void DrawIsFalseWhenNotVisible()
        {
            character.IsVisible = false;
            character.Draw(TimeSpan.Zero, TimeSpan.Zero, false);
            Assert.That(RendererMock.IsDrawInvoked, Is.False);
        }
    }
}
