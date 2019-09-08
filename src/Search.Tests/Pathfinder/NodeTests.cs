// <copyright file="NodeTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using NUnit.Framework;

namespace LateStartStudio.Search.Pathfinder
{
    [TestFixture]
    public class NodeTests
    {
        [Test]
        public void IDSimpleTests()
        {
            Assert.AreEqual(1, new Node(1).ID);
        }

        [Test]
        public void ParentSimpleTests()
        {
            Node node0 = new Node(0);
            Node node1 = new Node(1, parent: node0);

            Assert.AreEqual(null, node0.Parent);
            Assert.AreEqual(node0, node1.Parent);
        }

        [Test]
        public void FSimpleTests()
        {
            Assert.AreEqual(10, new Node(0, h: 3, g: 7).F);
        }

        [Test]
        public void HSimpleTests()
        {
            Assert.AreEqual(5, new Node(0, h: 5).H);
        }

        [Test]
        public void GSimpleTests()
        {
            Assert.AreEqual(5, new Node(0, g: 5).G);
        }

        [Test]
        public void EqualsSimpleTests()
        {
            Assert.AreEqual(new Node(0), new Node(0));
            Assert.AreNotEqual(new Node(0), new Node(1));
            Assert.AreNotEqual(null, new Node(0));
            Assert.False(new Node(0).Equals(null));
        }

        [Test]
        public void GetHashSimpleTests()
        {
            Assert.AreEqual(1, new Node(1).GetHashCode());
        }
    }
}
