// <copyright file="ColorTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets.Graphics
{
    using NUnit.Framework;

    [TestFixture]
    public class ColorTests
    {
        private Color color;

        [SetUp]
        public void SetUp() => this.color = default(Color);

        [Test]
        public void MakeDefault()
        {
            Color newColor = default(Color);

            Assert.That(newColor.R, Is.EqualTo(0));
            Assert.That(newColor.G, Is.EqualTo(0));
            Assert.That(newColor.B, Is.EqualTo(0));
            Assert.That(newColor.A, Is.EqualTo(0));
        }

        [TestCase(1, 2, 3, 4)]
        public void MakeFromInput(byte r, byte g, byte b, byte a)
        {
            Color newColor = new Color(r, g, b, a);

            Assert.That(newColor.R, Is.EqualTo(r));
            Assert.That(newColor.G, Is.EqualTo(g));
            Assert.That(newColor.B, Is.EqualTo(b));
            Assert.That(newColor.A, Is.EqualTo(a));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetAndSetR(byte expected)
        {
            color.R = expected;
            Assert.That(color.R, Is.EqualTo(expected));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetAndSetG(byte expected)
        {
            color.G = expected;
            Assert.That(color.G, Is.EqualTo(expected));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetAndSetB(byte expected)
        {
            color.B = expected;
            Assert.That(color.B, Is.EqualTo(expected));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void GetAndSetA(byte expected)
        {
            color.A = expected;
            Assert.That(color.A, Is.EqualTo(expected));
        }

        [TestCase(1, 1, 1, 1)]
        public void EqualsTrueOnSameInput(byte r, byte g, byte b, byte a)
        {
            Color left = new Color(r, g, b, a);
            Color right = new Color(r, g, b, a);

            Assert.That(left.Equals(right), Is.True);
        }

        [TestCase(1, 1, 1, 1, 1, 2, 3, 4)]
        public void EqualsFalseOnDifferentInput(
            byte leftR,
            byte leftG,
            byte leftB,
            byte leftA,
            byte rightR,
            byte rightG,
            byte rightB,
            byte rightA)
        {
            Color left = new Color(leftR, leftG, leftB, leftA);
            Color right = new Color(rightR, rightG, rightB, rightA);

            Assert.That(left.Equals(right), Is.False);
        }

        [Test]
        public void EqualsFalseOnNullInput() => Assert.That(color.Equals(null), Is.False);

        [TestCase(1, 1, 1, 1)]
        public void EqualsOperatorTrue(byte r, byte g, byte b, byte a)
        {
            Color left = new Color(r, g, b, a);
            Color right = new Color(r, g, b, a);

            Assert.That(left == right, Is.True);
        }

        [TestCase(1, 1, 1, 1, 1, 2, 3, 4)]
        public void EqualsOperatorFalse(
            byte leftR,
            byte leftG,
            byte leftB,
            byte leftA,
            byte rightR,
            byte rightG,
            byte rightB,
            byte rightA)
        {
            Color left = new Color(leftR, leftG, leftB, leftA);
            Color right = new Color(rightR, rightG, rightB, rightA);

            Assert.That(left == right, Is.False);
        }

        [TestCase(1, 1, 1, 1, 1, 2, 3, 4)]
        public void InequalsOperatorTrue(
            byte leftR,
            byte leftG,
            byte leftB,
            byte leftA,
            byte rightR,
            byte rightG,
            byte rightB,
            byte rightA)
        {
            Color left = new Color(leftR, leftG, leftB, leftA);
            Color right = new Color(rightR, rightG, rightB, rightA);

            Assert.That(left != right, Is.True);
        }

        [TestCase(1, 1, 1, 1)]
        public void InequalsOperatorFalse(byte r, byte g, byte b, byte a)
        {
            Color left = new Color(r, g, b, a);
            Color right = new Color(r, g, b, a);

            Assert.That(left != right, Is.False);
        }

        [Test]
        public void GetHashCodeTrue()
        {
            Assert.That(default(Color).GetHashCode(), Is.EqualTo(default(Color).GetHashCode()));
        }

        [Test]
        public void GetHashCodeFalse()
        {
            Assert.That(default(Color).GetHashCode(), Is.Not.EqualTo(new Color(1, 2, 3, 4)));
        }

        [Test]
        public void White() => Assert.That(new Color(255, 255, 255, 255), Is.EqualTo(Color.White));

        [Test]
        public void Black() => Assert.That(new Color(0, 0, 0, 255), Is.EqualTo(Color.Black));

        [Test]
        public void Transparent() => Assert.That(new Color(0, 0, 0, 0), Is.EqualTo(Color.Transparent));
    }
}
