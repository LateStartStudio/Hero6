// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPathfinder.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the IPathfinder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Search.Pathfinder
{
    using System.Collections.Generic;

    /// <summary>
    /// Find the actual distance from a node to its neighbor.
    /// </summary>
    /// <param name="from">The staert node.</param>
    /// <param name="to">The end node, typically a neighbor.</param>
    /// <returns>The distance from a node to its neighbor.</returns>
    public delegate int FindDistance(Node from, Node to);

    /// <summary>
    /// Calculates a heuristic from start node to end node.
    /// </summary>
    /// <param name="from">The start node.</param>
    /// <param name="to">The end node.</param>
    /// <returns>A numeric value representing the value of the heuristic.</returns>
    public delegate int Heuristic(Node from, Node to);

    /// <summary>
    /// Interface to provide required functionality for a pathfinder algorithm.
    /// </summary>
    public interface IPathfinder
    {
        /// <summary>
        /// Finds the path from the start node to the end node.
        /// </summary>
        /// <param name="start">The start node.</param>
        /// <param name="end">The end node.</param>
        /// <returns>
        /// A list of all nodes that must be travelled from the start node to reach the end node.
        /// </returns>
        IList<Node> FindPath(Node start, Node end);
    }
}
