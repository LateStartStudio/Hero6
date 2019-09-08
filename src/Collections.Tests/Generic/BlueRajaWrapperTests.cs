// <copyright file="BlueRajaWrapperTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using NUnit.Framework;

namespace LateStartStudio.Collections.Generic
{
    [TestFixture]
    public class BlueRajaWrapperTests : PriorityQueueTests
    {
        [Test]
        public void IsSynchronsizedFalse()
        {
            Assert.IsFalse(this.PriorityQueue.IsSynchronized);
        }

        [Test]
        public void SyncRootNotNull()
        {
            Assert.IsNotNull(this.PriorityQueue.SyncRoot);
        }

        protected override IPriorityQueue<Node> CreateInstance()
        {
            return new BlueRajaWrapper<Node>(50);
        }
    }
}
