// <copyright file="AStar.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Search.Pathfinder
{
    using System.Collections.Generic;
    using Collections.Generic;

    /// <summary>
    /// A class for implementation of the A* Search algorithm.
    /// </summary>
    public class AStar : IPathfinder
    {
        private readonly IPriorityQueue<Node> open;
        private readonly IList<Node> closed;
        private readonly FindDistance findDistance;
        private readonly Heuristic heuristic;

        /// <summary>
        /// Initializes a new instance of the AStar class.
        /// </summary>
        /// <param name="openSetCapacity">The max capacity of the open set.</param>
        /// <param name="findDistance">A delegate to find the g distance.</param>
        /// <param name="heuristic">A delegate to calculate the heuristic value.</param>
        public AStar(int openSetCapacity, FindDistance findDistance, Heuristic heuristic)
        {
            this.closed = new List<Node>();
            this.open = new BlueRajaWrapper<Node>(openSetCapacity);
            this.findDistance = findDistance;
            this.heuristic = heuristic;
        }

        /// <inheritdoc />
        public IList<Node> FindPath(Node start, Node end)
        {
            start.Parent = null;
            start.G = 0;
            start.H = 0;

            this.open.Enqueue(start, start.ID);

            while (this.open.Count > 0)
            {
                Node current = this.open.Dequeue();
                current.IsVisited = true;
                this.closed.Add(current);

                if (current.Equals(end))
                {
                    IList<Node> path = Backtrace(current);

                    this.ResetNodes();
                    return path;
                }

                foreach (Node neighbor in current.Children)
                {
                    if (neighbor.IsBlocked || neighbor.IsVisited)
                    {
                        continue;
                    }

                    int gscore = current.G + this.findDistance(current, neighbor);

                    if (this.open.Contains(neighbor))
                    {
                        if (gscore < neighbor.G)
                        {
                            neighbor.Parent = current;
                            neighbor.G = gscore;
                            neighbor.H = this.heuristic(neighbor, end);

                            this.open.UpdatePriority(neighbor, neighbor.F);
                        }

                        continue;
                    }

                    neighbor.Parent = current;
                    neighbor.G = gscore;
                    neighbor.H = this.heuristic(neighbor, end);

                    this.open.Enqueue(neighbor, neighbor.F);
                }
            }

            this.ResetNodes();
            return null;
        }

        private static void ResetNode(Node node)
        {
            node.IsVisited = false;
        }

        private static IList<Node> Backtrace(Node node)
        {
            IList<Node> reversePath = new List<Node>();

            while (node != null)
            {
                reversePath.Add(node);
                node = node.Parent;
            }

            IList<Node> path = new List<Node>();

            for (int i = reversePath.Count - 1; i >= 0; i--)
            {
                path.Add(reversePath[i]);
            }

            return path;
        }

        private void ResetNodes()
        {
            foreach (Node node in this.closed)
            {
                ResetNode(node);
            }

            foreach (Node node in this.open)
            {
                ResetNode(node);
            }

            this.closed.Clear();
            this.open.Clear();
        }
    }
}
