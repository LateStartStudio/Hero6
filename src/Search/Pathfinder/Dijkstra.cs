// <copyright file="Dijkstra.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;

namespace LateStartStudio.Search.Pathfinder
{
    /// <summary>
    /// A class for implementation of the Dijkstra algorithm.
    /// </summary>
    public class Dijkstra : IPathfinder
    {
        private readonly AStar pathfinder;

        /// <summary>
        /// Initializes a new instance of the Dijkstra class.
        /// </summary>
        /// <param name="openSetCapacity">The max capacity of the open set.</param>
        /// <param name="findDistance">A delegate to find the g distance.</param>
        public Dijkstra(int openSetCapacity, FindDistance findDistance)
        {
            this.pathfinder = new AStar(openSetCapacity, findDistance, (from, to) => 0);
        }

        /// <inheritdoc />
        public IList<Node> FindPath(Node start, Node end)
        {
            return this.pathfinder.FindPath(start, end);
        }
    }
}
