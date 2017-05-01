// <copyright file="DijkstraTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Search.Pathfinder
{
    using NUnit.Framework;

    [TestFixture]
    public class DijkstraTests : PathfinderTests
    {
        protected override IPathfinder CreateInstance(Heuristic heuristic)
        {
            return new Dijkstra(1000, (node, neighbor) => 1);
        }
    }
}
