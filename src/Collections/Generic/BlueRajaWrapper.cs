// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlueRajaWrapper.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the BlueRajaWrapper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Collections.Generic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Priority_Queue;

    /// <summary>
    /// A wrapper class that encapsulates the framework Optimized Priority Queue by BlueRaja.
    /// </summary>
    /// <typeparam name="T">
    /// The type of element in the priority queue. Any instance of T must extend from the class
    /// FastPriorityQueueNode as this is essential to achieve performance.
    /// </typeparam>
    public class BlueRajaWrapper<T> : IPriorityQueue<T> where T : FastPriorityQueueNode
    {
        private readonly FastPriorityQueue<T> pq;

        private object syncRoot;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlueRajaWrapper{T}"/> class that is empty
        /// and has capacity set by input argument.
        /// </summary>
        /// <param name="capacity">
        /// The capacity of the priority queue.
        /// </param>
        public BlueRajaWrapper(int capacity)
        {
            this.pq = new FastPriorityQueue<T>(capacity);
        }

        /// <inheritdoc />
        public int Count => this.pq.Count;

        /// <inheritdoc />
        public bool IsSynchronized => false;

        /// <inheritdoc />
        public object SyncRoot
        {
            get
            {
                if (this.syncRoot == null)
                {
                    System.Threading.Interlocked.CompareExchange<object>(
                        ref this.syncRoot,
                        new object(),
                        null);
                }

                return this.syncRoot;
            }
        }

        /// <inheritdoc />
        public bool Contains(T item)
        {
            return this.pq.Contains(item);
        }

        /// <inheritdoc />
        public void Clear()
        {
            this.pq.Clear();
        }

        /// <inheritdoc />
        public void CopyTo(Array array, int index)
        {
            T[] items = new T[this.pq.Count];

            int i = 0;
            foreach (T item in this.pq)
            {
                items[i++] = item;
            }

            Array.Copy(items, index, array, 0, items.Length);
        }

        /// <inheritdoc />
        public T Peek()
        {
            return this.pq.First;
        }

        /// <inheritdoc />
        public T Dequeue()
        {
            return this.Count > 0 ? this.pq.Dequeue() : default(T);
        }

        /// <inheritdoc />
        public void Enqueue(T item, float priority)
        {
            this.pq.Enqueue(item, priority);
        }

        /// <inheritdoc />
        public void UpdatePriority(T item, float priority)
        {
            this.pq.UpdatePriority(item, priority);
        }

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator()
        {
            return this.pq.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
