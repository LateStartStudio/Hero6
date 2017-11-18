// <copyright file="WalkAreasTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Regions
{
    using System.Collections.Generic;
    using System.Linq;
    using LateStartStudio.Hero6.Engine.Assets.Graphics;
    using LateStartStudio.Search.Pathfinder;
    using NUnit.Framework;

    [TestFixture]
    public class WalkAreasTests
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

        [Test]
        public void GetAreas()
        {
            IEnumerable<WalkArea> areas = new WalkArea[0];
            Assert.That(new WalkAreas(areas).Areas, Is.EqualTo(areas));
        }

        [Test]
        public void GetPathSimple1()
        {
            char[,] map =
            {
                { '0', '0', 'X', '1', '1' },
                { '0', '0', 'X', '1', '1' },
                { '0', '0', 'X', 'X', 'X' },
                { '0', '0', 'X', '2', '2' },
                { '0', '0', 'X', '2', '2' }
            };

            IList<Point> expected1 = new List<Point>
            {
                new Point(0, 0), new Point(0, 1), new Point(0, 2), new Point(0, 3), new Point(0, 4)
            };

            IList<Point> expected2 = new List<Point>
            {
                new Point(3, 0), new Point(4, 1)
            };

            IList<Point> expected3 = new List<Point>
            {
                new Point(4, 3), new Point(3, 4)
            };

            GetPathTest(map, expected1, new Point(0, 0), new Point(0, 4));
            GetPathTest(map, expected2, new Point(3, 0), new Point(4, 1));
            GetPathTest(map, expected3, new Point(4, 3), new Point(3, 4));
            GetPathTest(map, null, new Point(0, 0), new Point(3, 4));
        }

        [Test]
        public void GetPathIsNullWhenFromToOnDifferentAreas()
        {
            char[,] map =
            {
                { '0', '0', 'X', 'X', 'X' },
                { '0', '0', 'X', 'X', 'X' },
                { 'X', 'X', 'X', 'X', 'X' },
                { 'X', 'X', 'X', '1', '1' },
                { 'X', 'X', 'X', '1', '1' }
            };

            GetPathTest(map, null, new Point(0, 0), new Point(4, 4));
        }

        private static void GetPathTest(char[,] map, IList<Point> expected, Point from, Point to)
        {
            Assert.That(new WalkAreas(GenerateWalkAreas(map)).GetPath(from, to), Is.EqualTo(expected));
        }

        private static IEnumerable<WalkArea> GenerateWalkAreas(char[,] map)
        {
            IDictionary<char, WalkArea> areas = new Dictionary<char, WalkArea>();
            map.Cast<char>().Distinct().Where(c => c != 'X').ToList().ForEach(c => areas.Add(c, GenerateWalkArea(map, c)));
            return areas.Values;
        }

        private static WalkArea GenerateWalkArea(char[,] map, char region)
        {
            IDictionary<int, Node> graph = new Dictionary<int, Node>();

            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    if (map[y, x] != region)
                    {
                        continue;
                    }

                    Node node = new Node((map.GetLength(1) * y) + x);
                    graph.Add(node.ID, node);
                }
            }

            foreach (KeyValuePair<int, Node> node in graph)
            {
                node.Value.Children = FindNeighbors(node.Value, graph, map);
            }

            return new WalkArea(map.GetLength(0), map.GetLength(1), graph);
        }

        private static IList<Node> FindNeighbors(Node node, IDictionary<int, Node> graph, char[,] map)
        {
            IList<Node> neighbors = new List<Node>();

            for (int i = 0; i < DirectionVectors.GetLength(0); i++)
            {
                int x = (node.ID % map.GetLength(0)) + DirectionVectors[i, 0];
                int y = (node.ID / map.GetLength(0)) + DirectionVectors[i, 1];

                if (x < 0 && x >= map.GetLength(1) && y < 0 && y >= map.GetLength(0))
                {
                    continue;
                }

                int id = (y * map.GetLength(0)) + x;

                if (!graph.ContainsKey(id))
                {
                    continue;
                }

                neighbors.Add(graph[id]);
            }

            return neighbors;
        }
    }
}