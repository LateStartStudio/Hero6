// <copyright file="CharacterAnimationTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using System;
    using LateStartStudio.Hero6.Engine.Assets;
    using LateStartStudio.Hero6.Engine.Assets.Graphics;
    using NUnit.Framework;

    [TestFixture]
    public class CharacterAnimationTests : TestBase
    {
        private CharacterAnimation animation;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            this.animation = new CharacterAnimationMock(Campaign);
            animation.Load();
        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();

            animation.Unload();
        }

        [Test]
        public void CenterDownAnimationGetAndSet()
        {
            SpriteSheet spriteSheet = new SpriteSheet(Campaign, "TestSetAndGet", 10, 10);
            animation.CenterDownAnimation = spriteSheet;
            Assert.That(animation.CenterDownAnimation, Is.EqualTo(spriteSheet));
        }

        [Test]
        public void CenterUpnAnimationGetAndSet()
        {
            SpriteSheet spriteSheet = new SpriteSheet(Campaign, "TestSetAndGet", 10, 10);
            animation.CenterUpAnimation = spriteSheet;
            Assert.That(animation.CenterUpAnimation, Is.EqualTo(spriteSheet));
        }

        [Test]
        public void LeftCenterAnimationGetAndSet()
        {
            SpriteSheet spriteSheet = new SpriteSheet(Campaign, "TestSetAndGet", 10, 10);
            animation.LeftCenterAnimation = spriteSheet;
            Assert.That(animation.LeftCenterAnimation, Is.EqualTo(spriteSheet));
        }

        [Test]
        public void LeftDownAnimationGetAndSet()
        {
            SpriteSheet spriteSheet = new SpriteSheet(Campaign, "TestSetAndGet", 10, 10);
            animation.LeftDownAnimation = spriteSheet;
            Assert.That(animation.LeftDownAnimation, Is.EqualTo(spriteSheet));
        }

        [Test]
        public void LeftUpAnimationGetAndSet()
        {
            SpriteSheet spriteSheet = new SpriteSheet(Campaign, "TestSetAndGet", 10, 10);
            animation.LeftUpAnimation = spriteSheet;
            Assert.That(animation.LeftUpAnimation, Is.EqualTo(spriteSheet));
        }

        [Test]
        public void RightCenterAnimationGetAndSet()
        {
            SpriteSheet spriteSheet = new SpriteSheet(Campaign, "TestSetAndGet", 10, 10);
            animation.RightCenterAnimation = spriteSheet;
            Assert.That(animation.RightCenterAnimation, Is.EqualTo(spriteSheet));
        }

        [Test]
        public void RightDownAnimationGetAndSet()
        {
            SpriteSheet spriteSheet = new SpriteSheet(Campaign, "TestSetAndGet", 10, 10);
            animation.RightDownAnimation = spriteSheet;
            Assert.That(animation.RightDownAnimation, Is.EqualTo(spriteSheet));
        }

        [Test]
        public void RightUpAnimationGetAndSet()
        {
            SpriteSheet spriteSheet = new SpriteSheet(Campaign, "TestSetAndGet", 10, 10);
            animation.RightUpAnimation = spriteSheet;
            Assert.That(animation.RightUpAnimation, Is.EqualTo(spriteSheet));
        }

        [Test]
        public void LocationGetAndSet()
        {
            animation.Location = new Point(100, 100);
            Assert.That(animation.Location.X, Is.EqualTo(100));
            Assert.That(animation.Location.Y, Is.EqualTo(97));
        }

        [Test]
        public void WidthGet() => Assert.That(animation.Width, Is.EqualTo(0));

        [Test]
        public void HeightGet() => Assert.That(animation.Height, Is.EqualTo(3));

        [Test]
        public void IsMovingGetAndSet()
        {
            Assume.That(animation.IsMoving, Is.Not.True);
            animation.IsMoving = true;
            Assert.That(animation.IsMoving, Is.True);
        }

        [Test]
        public void FacingDirectionGetAndSet()
        {
            TestFacingDirectionGetAndSet(Vector2.RightUp);
            TestFacingDirectionGetAndSet(Vector2.Down);
            TestFacingDirectionGetAndSet(Vector2.Left);
            TestFacingDirectionGetAndSet(Vector2.LeftDown);
            TestFacingDirectionGetAndSet(Vector2.LeftUp);
            TestFacingDirectionGetAndSet(Vector2.Right);
            TestFacingDirectionGetAndSet(Vector2.RightDown);
            TestFacingDirectionGetAndSet(Vector2.Up);
        }

        [Test]
        public void FacingDirectionGetAndSetWhenSameValue()
        {
            TestFacingDirectionGetAndSet(Vector2.RightUp);
            TestFacingDirectionGetAndSet(Vector2.RightUp);
        }

        [TestCase(Interaction.Mouth)]
        [TestCase(Interaction.Eye)]
        [TestCase(Interaction.Hand)]
        [TestCase(Interaction.Move)]
        public void InteractReturnTrue(Interaction interaction)
        {
            Assert.That(animation.Interact(0, 0, interaction), Is.True);
        }

        [Test]
        public void UpdateRunsUntilFrameChangesWithoutCrash()
        {
            TimeSpan[] deltas =
            {
                TimeSpan.Zero,
                TimeSpan.FromSeconds(0.01),
                TimeSpan.FromSeconds(1.0 / 16.0),
                TimeSpan.FromSeconds(1.0),
                TimeSpan.FromSeconds(1.0),
                TimeSpan.FromSeconds(1.0),
                TimeSpan.FromSeconds(1.0),
                TimeSpan.FromSeconds(1.0),
                TimeSpan.FromSeconds(1.0),
                TimeSpan.FromSeconds(1.0),
                TimeSpan.FromSeconds(1.0),
                TimeSpan.FromSeconds(1.0)
            };
            TimeSpan delta = TimeSpan.Zero;
            animation.IsMoving = true;

            foreach (TimeSpan d in deltas)
            {
                delta += delta.Add(d);
                animation.Update(TimeSpan.Zero, delta, false);
            }

            Assert.Pass();
        }

        [Test]
        public void UpdateWhenIsMovingIsFalseRunsWithoutCrash()
        {
            animation.Update(TimeSpan.Zero, TimeSpan.Zero, false);
            Assert.Pass();
        }

        [Test]
        public void Draw()
        {
            animation.Draw(TimeSpan.Zero, TimeSpan.Zero, false);
            Assert.That(RendererMock.IsDrawInvoked, Is.True);
        }

        private void TestFacingDirectionGetAndSet(Vector2 direction)
        {
            animation.FacingDirection = direction;
            Assert.That(animation.FacingDirection, Is.EqualTo(direction));
        }
    }
}
