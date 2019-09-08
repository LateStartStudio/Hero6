// <copyright file="AStarTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using NUnit.Framework;

namespace LateStartStudio.Search.Pathfinder
{
    [TestFixture]
    public class AStarTests : PathfinderTests
    {
        protected override IPathfinder CreateInstance(Heuristic heuristic)
        {
            return new AStar(25, (node, neighbor) => 1, heuristic);
        }
    }
}
