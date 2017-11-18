// <copyright file="PointTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets.Graphics
{
    using NUnit.Framework;

    [TestFixture]
    public class PointTests
    {
        private Point point;

        [SetUp]
        public void SetUp() => this.point = default(Point);

        [Test]
        public void MakeDefault()
        {
            Point newPoint = default(Point);

            Assert.That(newPoint.X, Is.EqualTo(0));
            Assert.That(newPoint.Y, Is.EqualTo(0));
        }

        [TestCase(1, 2)]
        public void MakeFromInput(int x, int y)
        {
            Point newPoint = new Point(x, y);

            Assert.That(newPoint.X, Is.EqualTo(x));
            Assert.That(newPoint.Y, Is.EqualTo(y));
        }

        [TestCase(1, 2)]
        public void MakeFromVector2Constructor(int x, int y)
        {
            Point newPoint = new Point(new Vector2(x, y));

            Assert.That(newPoint.X, Is.EqualTo(x));
            Assert.That(newPoint.Y, Is.EqualTo(y));
        }

        [TestCase(1, 2)]
        public void MakeFromVector2Explicitly(int x, int y)
        {
            Point newPoint = (Point)new Vector2(x, y);

            Assert.That(newPoint.X, Is.EqualTo(x));
            Assert.That(newPoint.Y, Is.EqualTo(y));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetAndSetX(int x)
        {
            point.X = x;
            Assert.That(point.X, Is.EqualTo(x));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetAndSetY(int y)
        {
            point.Y = y;
            Assert.That(point.Y, Is.EqualTo(y));
        }
    }
}
