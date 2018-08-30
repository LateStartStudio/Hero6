// <copyright file="Vector2Tests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets.Graphics
{
    using NUnit.Framework;

    [TestFixture]
    public class Vector2Tests
    {
        [Test]
        public void MakeDefault()
        {
            Vector2 vector = default(Vector2);

            Assert.AreEqual(0.0f, vector.X);
            Assert.AreEqual(0.0f, vector.Y);
        }

        [Test]
        public void MakeFromInput()
        {
            Vector2 vector = new Vector2(1.0f, 2.0f);

            Assert.AreEqual(1.0f, vector.X);
            Assert.AreEqual(2.0f, vector.Y);
        }

        [Test]
        public void GetAndSet()
        {
            Vector2 vector = default(Vector2);

            Assert.AreEqual(0.0f, vector.X);
            Assert.AreEqual(0.0f, vector.Y);

            vector.X = 1.0f;
            vector.Y = 2.0f;

            Assert.AreEqual(1.0f, vector.X);
            Assert.AreEqual(2.0f, vector.Y);
        }

        [Test]
        public void Add()
        {
            Vector2 vector = default(Vector2);
            vector += new Vector2(1.0f, 2.0f);

            Assert.AreEqual(1.0f, vector.X);
            Assert.AreEqual(2.0f, vector.Y);
        }

        [Test]
        public void Subtract()
        {
            Vector2 vector = default(Vector2);
            vector -= new Vector2(1.0f, 2.0f);

            Assert.AreEqual(-1.0f, vector.X);
            Assert.AreEqual(-2.0f, vector.Y);
        }

        [Test]
        public void EqualsTrueOnSameInput()
        {
            Vector2 vector1 = new Vector2(1.0f, 2.0f);
            Vector2 vector2 = new Vector2(1.0f, 2.0f);

            Assert.IsTrue(vector1.Equals(vector2));
        }

        [Test]
        public void EqualsFalseOnDifferentInput()
        {
            Vector2 vector1 = default(Vector2);
            Vector2 vector2 = new Vector2(1.0f, 2.0f);

            Assert.IsFalse(vector1.Equals(vector2));
        }

        [Test]
        public void EqualsFalseOnNullInput()
        {
            Vector2 vector = default(Vector2);

            Assert.IsFalse(vector.Equals(null));
        }

        [Test]
        public void EqualsOperatorTrue()
        {
            Vector2 left = new Vector2(1.0f, 2.0f);
            Vector2 right = new Vector2(1.0f, 2.0f);

            Assert.IsTrue(left == right);
        }

        [Test]
        public void EqualsOperatorFalse()
        {
            Vector2 left = default(Vector2);
            Vector2 right = new Vector2(1.0f, 2.0f);

            Assert.IsFalse(left == right);
        }

        [Test]
        public void InequalsOperatorTrue()
        {
            Vector2 left = default(Vector2);
            Vector2 right = new Vector2(1.0f, 2.0f);

            Assert.IsTrue(left != right);
        }

        [Test]
        public void InequalsOperatorFalse()
        {
            Vector2 left = new Vector2(1.0f, 2.0f);
            Vector2 right = new Vector2(1.0f, 2.0f);

            Assert.IsFalse(left != right);
        }

        [Test]
        public void GetHashCodeTrue()
        {
            Vector2 vector1 = new Vector2(1.0f, 2.0f);
            Vector2 vector2 = new Vector2(1.0f, 2.0f);

            Assert.AreEqual(vector1.GetHashCode(), vector2.GetHashCode());
        }

        [Test]
        public void LeftUp()
        {
            Assert.AreEqual(new Vector2(-1.0f, -1.0f), Vector2.LeftUp);
        }

        [Test]
        public void Up()
        {
            Assert.AreEqual(new Vector2(0.0f, -1.0f), Vector2.Up);
        }

        [Test]
        public void RightUp()
        {
            Assert.AreEqual(new Vector2(1.0f, -1.0f), Vector2.RightUp);
        }

        [Test]
        public void Left()
        {
            Assert.AreEqual(new Vector2(-1.0f, 0.0f), Vector2.Left);
        }

        [Test]
        public void Right()
        {
            Assert.AreEqual(new Vector2(1.0f, 0.0f), Vector2.Right);
        }

        [Test]
        public void LeftDown()
        {
            Assert.AreEqual(new Vector2(-1.0f, 1.0f), Vector2.LeftDown);
        }

        [Test]
        public void Down()
        {
            Assert.AreEqual(new Vector2(0.0f, 1.0f), Vector2.Down);
        }

        [Test]
        public void RightDown()
        {
            Assert.AreEqual(new Vector2(1.0f, 1.0f), Vector2.RightDown);
        }

        [Test]
        public void Center()
        {
            Assert.AreEqual(new Vector2(0.0f, 0.0f), Vector2.Center);
        }
    }
}
