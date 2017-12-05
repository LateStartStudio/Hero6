// <copyright file="SpriteSheetTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using System;
    using LateStartStudio.Hero6.Engine.Assets.Graphics;
    using NUnit.Framework;

    [TestFixture]
    public class SpriteSheetTests : TestBase
    {
        private SpriteSheet spriteSheet;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            this.spriteSheet = new SpriteSheet(Campaign, "0:0:0", 0, 0);
            spriteSheet.Load();
        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();

            spriteSheet.Unload();
        }

        [TestCase("Test Set")]
        public void GetAndSetSheetID(string id)
        {
            Assume.That(spriteSheet.SheetID, Is.Not.EqualTo(id));
            spriteSheet.SheetID = id;
            Assert.That(spriteSheet.SheetID, Is.EqualTo(id));
        }

        [TestCase("Test Set", 0, 0)]
        public void GetAndSetSheet(string id, int w, int h)
        {
            Texture2D expected = new Texture2DMock(id, w, h);
            Assume.That(spriteSheet.Sheet, Is.Not.EqualTo(expected));
            spriteSheet.Sheet = expected;
            Assert.That(spriteSheet.Sheet, Is.EqualTo(expected));
        }

        [TestCase(1)]
        public void GetAndSetRows(int rows)
        {
            Assume.That(spriteSheet.Rows, Is.Not.EqualTo(rows));
            spriteSheet.Rows = rows;
            Assert.That(spriteSheet.Rows, Is.EqualTo(rows));
        }

        [TestCase(1)]
        public void GetAndSetColumns(int col)
        {
            Assume.That(spriteSheet.Rows, Is.Not.EqualTo(col));
            spriteSheet.Columns = col;
            Assert.That(spriteSheet.Columns, Is.EqualTo(col));
        }

        [Test]
        public void Update()
        {
            bool result = true;
            spriteSheet.PostUpdate += (s, e) => result = true;
            spriteSheet.Update(TimeSpan.Zero, TimeSpan.Zero, false);
            Assert.That(result, Is.True);
        }

        [Test]
        public void Draw()
        {
            bool result = false;
            spriteSheet.PostDraw += (s, e) => result = true;
            spriteSheet.Draw(TimeSpan.Zero, TimeSpan.Zero, false);
            Assert.That(result, Is.True);
        }
    }
}
