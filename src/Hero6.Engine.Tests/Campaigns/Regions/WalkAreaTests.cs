// <copyright file="WalkAreaTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Regions
{
    using System;
    using System.Collections.Generic;
    using LateStartStudio.Hero6.Engine.Assets.Graphics;
    using LateStartStudio.Search.Pathfinder;
    using NUnit.Framework;

    [TestFixture]
    public class WalkAreaTests
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
            { 1, 1 }
        };

        [TestCase(10)]
        public void GetWidth(int w)
        {
            Assert.That(new WalkArea(w, 15, new Dictionary<int, Node>()).Width, Is.EqualTo(w));
        }

        [TestCase(15)]
        public void GetHeight(int h)
        {
            Assert.That(new WalkArea(10, h, new Dictionary<int, Node>()).Height, Is.EqualTo(h));
        }

        [Test]
        public void GetNodes()
        {
            IDictionary<int, Node> graph = new Dictionary<int, Node>();

            Assert.That(new WalkArea(10, 15, graph).Nodes, Is.EqualTo(graph));
        }

        [Test]
        public void GetPathSimple()
        {
            char[,] map =
            {
                { 'O', 'O', 'O', 'O', 'O' },
                { 'O', 'O', 'O', 'O', 'O' },
                { 'O', 'O', 'O', 'O', 'O' },
                { 'O', 'O', 'O', 'O', 'O' },
                { 'O', 'O', 'O', 'O', 'O' }
            };

            IList<Point> expected = new List<Point>
            {
                new Point(0, 0), new Point(1, 1), new Point(2, 2), new Point(3, 3), new Point(4, 4)
            };

            GetPathTest(map, expected, new Point(0, 0), new Point(4, 4));
        }

        private static void GetPathTest(char[,] map, IList<Point> expected, Point from, Point to)
        {
            IDictionary<int, Node> graph = GenerateGraph(map);

            Assert.That(new WalkArea(map.GetLength(0), map.GetLength(1), graph).GetPath(from, to), Is.EqualTo(expected));
        }

        private static IDictionary<int, Node> GenerateGraph(char[,] map)
        {
            IDictionary<int, Node> graph = new Dictionary<int, Node>();

            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Node node = GenerateNode((map.GetLength(1) * y) + x, map[y, x]);
                    graph.Add(node.ID, node);
                }
            }

            foreach (KeyValuePair<int, Node> node in graph)
            {
                node.Value.Children = FindNeighbors(node.Value, graph, map);
            }

            return graph;
        }

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

        private static IList<Node> FindNeighbors(Node searchNode, IDictionary<int, Node> graph, char[,] map)
        {
            IList<Node> neighbors = new List<Node>();

            for (int i = 0; i < DirectionVectors.GetLength(0); i++)
            {
                int x = (searchNode.ID % map.GetLength(0)) + DirectionVectors[i, 0];
                int y = (searchNode.ID / map.GetLength(0)) + DirectionVectors[i, 1];
                int id = x + (y * map.GetLength(0));

                if (x >= 0 && x < map.GetLength(1) && y >= 0 && y < map.GetLength(0))
                {
                    neighbors.Add(graph[id]);
                }
            }

            return neighbors;
        }
    }
}
