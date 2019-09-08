// <copyright file="Node.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using Priority_Queue;

namespace LateStartStudio.Collections.Generic
{
    /// <summary>
    /// A simple Node class to use for generic tests.
    /// </summary>
    public partial class Node
    {
        public Node(int id)
        {
            this.ID = id;
        }

        public int ID { get; }
    }

    /// <summary>
    /// Hack extension. The Optimized Priority Queue framework requires any node to extend from
    /// FastPrioirtyQueueNode. The extensions is separated to itself here to make it easy to remove
    /// if we ever need to.
    /// </summary>
    public partial class Node : FastPriorityQueueNode
    {
    }
}
