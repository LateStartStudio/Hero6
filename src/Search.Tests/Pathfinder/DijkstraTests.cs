// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DijkstraTests.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the DijkstraTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
