// <copyright file="PriorityQueueTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections;
using NUnit.Framework;

namespace LateStartStudio.Collections.Generic
{
    public abstract class PriorityQueueTests
    {
        protected IPriorityQueue<Node> PriorityQueue { get; private set; }

        [SetUp]
        public void Init()
        {
            this.PriorityQueue = this.CreateInstance();
        }

        [Test]
        public void Contains()
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);

            this.PriorityQueue.Enqueue(node1, node1.ID);

            Assert.IsTrue(this.PriorityQueue.Contains(node1));
            Assert.IsFalse(this.PriorityQueue.Contains(node2));
        }

        [Test]
        public void Count()
        {
            Node[] nodes = new Node[5];

            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new Node(i);
                this.PriorityQueue.Enqueue(nodes[i], nodes[i].ID);
            }

            Assert.AreEqual(nodes.Length, this.PriorityQueue.Count);
        }

        [Test]
        public void Clear()
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);

            this.PriorityQueue.Enqueue(node1, node1.ID);
            this.PriorityQueue.Enqueue(node2, node2.ID);

            Assert.AreEqual(2, this.PriorityQueue.Count);
            Assert.IsTrue(this.PriorityQueue.Contains(node1));
            Assert.IsTrue(this.PriorityQueue.Contains(node2));

            this.PriorityQueue.Clear();

            Assert.AreEqual(0, this.PriorityQueue.Count);
            Assert.IsFalse(this.PriorityQueue.Contains(node1));
            Assert.IsFalse(this.PriorityQueue.Contains(node2));
        }

        [Test]
        public void CopyTo()
        {
            Node[] nodes = new Node[5];

            for (int i = 0; i < 5; i++)
            {
                nodes[i] = new Node(i + 1);
                this.PriorityQueue.Enqueue(nodes[i], nodes[i].ID);
            }

            Node[] result = new Node[this.PriorityQueue.Count];
            this.PriorityQueue.CopyTo(result, 0);

            Assert.AreEqual(nodes, result);
        }

        [Test]
        public void PeekItem()
        {
            Node node = new Node(5);
            this.PriorityQueue.Enqueue(node, node.ID);

            Assert.AreEqual(this.PriorityQueue.Peek(), node);
        }

        [Test]
        public void DequeueItemWhenEmpty()
        {
            Assert.AreEqual(null, this.PriorityQueue.Dequeue());
        }

        [Test]
        public void EnqueuePopItemWhenHardcodedArbitraryOrder()
        {
            Node node0 = new Node(1);
            Node node1 = new Node(2);
            Node node2 = new Node(3);
            Node node3 = new Node(4);
            Node node4 = new Node(5);
            Node node5 = new Node(6);
            Node node6 = new Node(7);
            Node node7 = new Node(8);
            Node node8 = new Node(9);
            Node node9 = new Node(10);

            this.PriorityQueue.Enqueue(node5, node5.ID);
            this.PriorityQueue.Enqueue(node3, node3.ID);
            this.PriorityQueue.Enqueue(node6, node6.ID);
            this.PriorityQueue.Enqueue(node7, node7.ID);
            this.PriorityQueue.Enqueue(node1, node1.ID);
            this.PriorityQueue.Enqueue(node9, node9.ID);
            this.PriorityQueue.Enqueue(node0, node0.ID);
            this.PriorityQueue.Enqueue(node2, node2.ID);
            this.PriorityQueue.Enqueue(node8, node8.ID);
            this.PriorityQueue.Enqueue(node4, node4.ID);

            Assert.AreEqual(10, this.PriorityQueue.Count);
            Assert.AreEqual(node0, this.PriorityQueue.Dequeue());
            Assert.AreEqual(9, this.PriorityQueue.Count);
            Assert.AreEqual(node1, this.PriorityQueue.Dequeue());
            Assert.AreEqual(8, this.PriorityQueue.Count);
            Assert.AreEqual(node2, this.PriorityQueue.Dequeue());
            Assert.AreEqual(7, this.PriorityQueue.Count);
            Assert.AreEqual(node3, this.PriorityQueue.Dequeue());
            Assert.AreEqual(6, this.PriorityQueue.Count);
            Assert.AreEqual(node4, this.PriorityQueue.Dequeue());
            Assert.AreEqual(5, this.PriorityQueue.Count);
            Assert.AreEqual(node5, this.PriorityQueue.Dequeue());
            Assert.AreEqual(4, this.PriorityQueue.Count);
            Assert.AreEqual(node6, this.PriorityQueue.Dequeue());
            Assert.AreEqual(3, this.PriorityQueue.Count);
            Assert.AreEqual(node7, this.PriorityQueue.Dequeue());
            Assert.AreEqual(2, this.PriorityQueue.Count);
            Assert.AreEqual(node8, this.PriorityQueue.Dequeue());
            Assert.AreEqual(1, this.PriorityQueue.Count);
            Assert.AreEqual(node9, this.PriorityQueue.Dequeue());
            Assert.AreEqual(0, this.PriorityQueue.Count);
        }

        [Test]
        public void UpdatePriority()
        {
            Node node1 = new Node(2);
            Node node2 = new Node(3);
            this.PriorityQueue.Enqueue(node1, node1.ID);
            this.PriorityQueue.Enqueue(node2, node2.ID);
            this.PriorityQueue.UpdatePriority(node2, 1);

            Assert.AreEqual(node2, this.PriorityQueue.Peek());
        }

        [Test]
        public void GetEnumeratorReachEnd()
        {
            Node node = new Node(1);

            this.PriorityQueue.Enqueue(node, node.ID);

            IEnumerator enumerator = this.PriorityQueue.GetEnumerator();

            enumerator.MoveNext();
            Assert.AreEqual(node, enumerator.Current);

            Assert.IsFalse(enumerator.MoveNext()); // False on end of enumerator
            Assert.IsFalse(enumerator.MoveNext()); // False if already reached end
        }

        protected abstract IPriorityQueue<Node> CreateInstance();
    }
}
