// <copyright file="RectangleTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets.Graphics
{
    using NUnit.Framework;

    [TestFixture]
    public class RectangleTests
    {
        private Rectangle rectangle;

        [SetUp]
        public void SetUp() => this.rectangle = default(Rectangle);

        [Test]
        public void MakeDefault()
        {
            Rectangle newRectangle = default(Rectangle);

            Assert.That(newRectangle.X, Is.EqualTo(0));
            Assert.That(newRectangle.Y, Is.EqualTo(0));
            Assert.That(newRectangle.Width, Is.EqualTo(0));
            Assert.That(newRectangle.Height, Is.EqualTo(0));
        }

        [TestCase(1, 2, 3, 4)]
        public void MakeFromInput1(int x, int y, int w, int h)
        {
            Rectangle newRectangle = new Rectangle(x, y, w, h);

            Assert.That(newRectangle.X, Is.EqualTo(x));
            Assert.That(newRectangle.Y, Is.EqualTo(y));
            Assert.That(newRectangle.Width, Is.EqualTo(w));
            Assert.That(newRectangle.Height, Is.EqualTo(h));
        }

        [TestCase(1, 2, 3, 4)]
        public void MakeFromInput2(int x, int y, int w, int h)
        {
            Rectangle newRectangle = new Rectangle(new Point(x, y), new Point(w, h));

            Assert.That(newRectangle.X, Is.EqualTo(x));
            Assert.That(newRectangle.Y, Is.EqualTo(y));
            Assert.That(newRectangle.Width, Is.EqualTo(w));
            Assert.That(newRectangle.Height, Is.EqualTo(h));
        }

        [TestCase(0, 0, 5, 5, 2, 2)]
        public void ContainsTrue(int x0, int y0, int w, int h, int x1, int y1)
        {
            Assert.That(new Rectangle(x0, y0, w, h).Contains(x1, y1), Is.True);
        }

        [TestCase(0, 0, 5, 5, 6, 6)]
        public void ContainsFalse(int x0, int y0, int w, int h, int x1, int y1)
        {
            Assert.That(new Rectangle(x0, y0, w, h).Contains(x1, y1), Is.False);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetAndSetX(int x)
        {
            rectangle.X = x;
            Assert.That(rectangle.X, Is.EqualTo(x));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetAndSetY(int y)
        {
            rectangle.Y = y;
            Assert.That(rectangle.Y, Is.EqualTo(y));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetAndSetWidth(int w)
        {
            rectangle.Width = w;
            Assert.That(rectangle.Width, Is.EqualTo(w));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetAndSetHeight(int h)
        {
            rectangle.Height = h;
            Assert.That(rectangle.Height, Is.EqualTo(h));
        }
    }
}
