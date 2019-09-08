// <copyright file="IPriorityQueue.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections;
using System.Collections.Generic;

namespace LateStartStudio.Collections.Generic
{
    /// <summary>
    /// Represents a queue of elements ordered so that the lowest or highest ranking element
    /// is always the first in the queue.
    /// </summary>
    /// <typeparam name="T">Specifies the type of element in the IPriorityQueue.</typeparam>
    public interface IPriorityQueue<T> : IEnumerable<T>, ICollection
    {
        /// <summary>
        /// Adds an object to the IPriorityQueue.
        /// </summary>
        /// <param name="item">The object to add to the IPriorityQueue.</param>
        /// <param name="priority">The priority of the added item.</param>
        void Enqueue(T item, float priority);

        /// <summary>
        /// Returns the object that has the lowest or highest ranking in the IPriorityQueue
        /// without removing it.
        /// </summary>
        /// <returns>The object with the lowest or highest ranking in the IPriorityQueue.</returns>
        T Peek();

        /// <summary>
        /// Returns the object that has the lowest or highest ranking in the IPriorityQueue
        /// and removes it.
        /// </summary>
        /// <returns>The object with the lowest or highest ranking in the IPriorityQueue.</returns>
        T Dequeue();

        /// <summary>
        /// Updates the priority of the node specified.
        /// </summary>
        /// <param name="item">The item to update the priority of.</param>
        /// <param name="priority">The new priority the item should have.</param>
        void UpdatePriority(T item, float priority);

        /// <summary>
        /// Searches the IPriorityQueue for the item provided as an argument.
        /// </summary>
        /// <param name="item">The item to search for inside the IPriorityQueue.</param>
        /// <returns>Returns a boolean indicating if the item was found.</returns>
        bool Contains(T item);

        /// <summary>
        /// Removes all objects from the Priority Queue.
        /// </summary>
        void Clear();
    }
}
