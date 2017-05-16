// <copyright file="Node.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Search.Pathfinder
{
    using System.Collections.Generic;
    using Priority_Queue;

    /// <summary>
    /// A class representing a node in a graph.
    /// </summary>
    public class Node : FastPriorityQueueNode
    {
        /// <summary>
        /// Initializes a new instance of the Node class with default values.
        /// </summary>
        /// <param name="id">The node ID.</param>
        /// <param name="isVisited">If the node has been previously visited or not.</param>
        /// <param name="parent">The parent node.</param>
        /// <param name="h">The heuristic value.</param>
        /// <param name="g">The total cost so far.</param>
        public Node(
            int id,
            bool isVisited = false,
            Node parent = null,
            int h = 0,
            int g = 0)
        {
            this.ID = id;
            this.IsVisited = isVisited;
            this.Parent = parent;
            this.H = h;
            this.G = g;
            this.Children = new List<Node>();
        }

        /// <summary>
        /// Gets the node ID.
        /// </summary>
        /// <value>
        /// A unique ID value.
        /// </value>
        public int ID { get; }

        /// <summary>
        /// Gets or sets a value indicating whether if the node has bee previously visited or not.
        /// </summary>
        /// <value>
        /// True if the node has been previously visited, false otherwise.
        /// </value>
        public bool IsVisited
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the parent node.
        /// </summary>
        /// <value>
        /// The parent node. Is null only if no parent exists.
        /// </value>
        public Node Parent
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the children nodes.
        /// </summary>
        /// <value>
        /// The children nodes.
        /// </value>
        public IList<Node> Children
        {
            get; set;
        }

        /// <summary>
        ///  Gets the total cost value of reaching this node.
        /// </summary>
        /// <value>
        /// The total cost value.
        /// </value>
        public int F => this.G + this.H;

        /// <summary>
        /// Gets or sets the heuristic value.
        /// </summary>
        /// <value>
        /// The heuristic value.
        /// </value>
        public int H
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the total cost so far.
        /// </summary>
        /// <value>
        /// The total cost so far.
        /// </value>
        public int G
        {
            get; set;
        }

        /// <summary>
        /// Equals-function. Determined by the property ID.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>True if the object is equal. False otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            Node other = (Node)obj;

            return this.ID == other.ID;
        }

        /// <summary>
        /// GetHashCode -function. Determined by the property ID.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            return this.ID;
        }
    }
}
