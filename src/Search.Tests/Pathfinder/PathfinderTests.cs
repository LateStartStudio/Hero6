// <copyright file="PathfinderTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LateStartStudio.Search.Pathfinder
{
    [TestFixture]
    public abstract class PathfinderTests
    {
        private static readonly int[,] DirectionVectors =
        {
            { -1, -1 },
            { 0, -1 },
            { 1, -1 },
            { -1, 0 },
            { 1, 0 },
            { -1, 1 },
            { 0, 1 },
            { 1, 1 },
        };

        private Node[,] graph;

        protected IPathfinder Pathfinder { get; private set; }

        [SetUp]
        public void Init()
        {
            this.Pathfinder = this.CreateInstance(this.CalculateOctileHeuristic);
        }

        /// <summary>
        /// O = Open Node
        /// B = Blocked Node
        ///
        /// Start = 2, 2
        /// End = 0, 0.
        /// </summary>
        [Test]
        public void FindPathNoValid()
        {
            char[,] map =
            {
                { 'O', 'O', 'O', 'O', 'O' },
                { 'O', 'B', 'B', 'B', 'O' },
                { 'O', 'B', 'O', 'B', 'O' },
                { 'O', 'B', 'B', 'B', 'O' },
                { 'O', 'O', 'O', 'O', 'O' },
            };

            this.GenerateGraph(map);

            Assert.AreEqual(null, this.Pathfinder.FindPath(this.graph[2, 2], this.graph[0, 0]));
        }

        /// <summary>
        /// O = Open Node
        /// B = Blocked Node
        ///
        /// Start = 4, 4
        /// End = 0, 0.
        /// </summary>
        [Test]
        public void FindPathSimpleDiag()
        {
            char[,] map =
            {
                { 'O', 'O', 'O', 'O', 'O' },
                { 'O', 'O', 'O', 'O', 'O' },
                { 'O', 'O', 'O', 'O', 'O' },
                { 'O', 'O', 'O', 'O', 'O' },
                { 'O', 'O', 'O', 'O', 'O' },
            };

            GenerateGraph(map);

            IList<Node> expected = new List<Node>
            {
                graph[4, 4],
                graph[3, 3],
                graph[2, 2],
                graph[1, 1],
                graph[0, 0],
            };

            IList<Node> actual = Pathfinder.FindPath(graph[4, 4], graph[0, 0]);

            Assert.AreEqual(expected, actual);
        }

        protected abstract IPathfinder CreateInstance(Heuristic heuristic);

        private static Node GenerateNode(int id, char node)
        {
            switch (node)
            {
                case 'O':
                    return new Node(id);
                case 'B':
                    return new Node(id, true);
                default:
                    throw new NotImplementedException();
            }
        }

        private int CalculateOctileHeuristic(Node from, Node to)
        {
            int fromX = from.ID % this.graph.GetLength(0);
            int fromY = from.ID / this.graph.GetLength(0);
            int toX = to.ID % this.graph.GetLength(0);
            int toY = to.ID / this.graph.GetLength(0);

            return (int)(Math.Min(Math.Abs(fromX - toX), Math.Abs(fromY - toY)) + (1.5 * Math.Max(Math.Abs(fromX - toX), Math.Abs(fromY - toY))));
        }

        private void GenerateGraph(char[,] map)
        {
            this.graph = new Node[map.GetLength(0), map.GetLength(1)];

            for (int y = 0; y < this.graph.GetLength(1); y++)
            {
                for (int x = 0; x < this.graph.GetLength(0); x++)
                {
                    this.graph[y, x] = GenerateNode((map.GetLength(1) * y) + x, map[y, x]);
                }
            }

            foreach (Node node in this.graph)
            {
                node.Children = this.FindNeighbors(node);
            }
        }

        private IList<Node> FindNeighbors(Node searchNode)
        {
            IList<Node> neighbors = new List<Node>();

            for (int i = 0; i < DirectionVectors.GetLength(0); i++)
            {
                int x = (searchNode.ID % this.graph.GetLength(0)) + DirectionVectors[i, 0];
                int y = (searchNode.ID / this.graph.GetLength(0)) + DirectionVectors[i, 1];

                if (x >= 0 && x < this.graph.GetLength(1) && y >= 0 && y < this.graph.GetLength(0))
                {
                    neighbors.Add(this.graph[y, x]);
                }
            }

            return neighbors;
        }
    }
}
