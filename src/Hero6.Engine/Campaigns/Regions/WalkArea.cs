// <copyright file="WalkArea.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Regions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LateStartStudio.Hero6.Engine.Assets.Graphics;
    using LateStartStudio.Search.Pathfinder;

    /// <summary>
    /// Representation of a single walk area for a room. The walk area is stored to disk as a image
    /// mask, and then loaded and converted to a Dictionary of pathfinder nodes.
    /// </summary>
    public class WalkArea
    {
        private readonly IPathfinder pathfinder;

        /// <summary>
        /// Initializes a new instane of the <see cref="WalkArea"/> class.
        /// </summary>
        /// <param name="width">The width of the image mask this instance was loaded from.</param>
        /// <param name="height">The height of the image mask this instance loaded from.</param>
        /// <param name="nodes">The nodes this instance was loaded from.</param>
        public WalkArea(int width, int height, IDictionary<int, Node> nodes)
        {
            this.Width = width;
            this.Height = height;
            this.Nodes = nodes;
            this.pathfinder = new AStar(
                OpenSetCapacity,
                FindNeighborDistance,
                CalculateOctileHeuristic);
        }

        /// <summary>
        /// Gets the width of the image mask this instance was loaded from.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Gets the height of the image mask this instance loaded from.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Gets the nodes this instance was loaded from.
        /// </summary>
        public IDictionary<int, Node> Nodes { get; }

        /// <summary>
        /// Gets the capacity of the open set in the pathfinder. We assume that maximum number of
        /// nodes that can be visited is the same as the amount of nodes that can be legally
        /// traversed.
        /// </summary>
        private int OpenSetCapacity => Nodes.Count;

        /// <summary>
        /// Gets the path from start to end.
        /// </summary>
        /// <param name="from">The start.</param>
        /// <param name="to">The end.</param>
        /// <returns>The path from start to end if it exists, null if else.</returns>
        public IEnumerable<Point> GetPath(Point from, Point to)
        {
            IEnumerable<Node> nodes = pathfinder.FindPath(
                Nodes[(from.Y * Width) + from.X],
                Nodes[(to.Y * Width) + to.X]);

            return nodes.Select(node => new Point(node.ID % Width, node.ID / Width)).ToList();
        }

        /// <summary>
        /// The distance between neighbors. We assume that the distance is equal reagardless of
        /// horizontal, vertical or diagonal positioning. Since there is no difference between
        /// the situations the value becomes irrelevant and we can just return a zero.
        /// </summary>
        /// <param name="from">The node.</param>
        /// <param name="to">The neighbor.</param>
        /// <returns>The distance.</returns>
        private static int FindNeighborDistance(Node from, Node to)
        {
            return 0;
        }

        /// <summary>
        /// Octile heuristic is a textbook example of how to calculate distances from nodes when
        /// we only move to neighbors at 45 degree angles. Top-Left, Top, Top-Right, etc.
        /// </summary>
        /// <param name="from">The start.</param>
        /// <param name="to">The end.</param>
        /// <returns>The estimated distance.</returns>
        private int CalculateOctileHeuristic(Node from, Node to)
        {
            int fromX = from.ID % Width;
            int fromY = from.ID / Width;
            int toX = to.ID % Width;
            int toY = to.ID / Width;

            return (int)(Math.Min(Math.Abs(fromX - toX), Math.Abs(fromY - toY)) + (1.5 * Math.Max(Math.Abs(fromX - toX), Math.Abs(fromY - toY))));
        }
    }
}
