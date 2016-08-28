// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AStarTests.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the AStarTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Search.Tests.Pathfinder
{
    using NUnit.Framework;
    using Search.Pathfinder;

    [TestFixture]
    public class AStarTests : PathfinderTests
    {
        protected override IPathfinder CreateInstance(Heuristic heuristic)
        {
            return new AStar(25, (node, neighbor) => 1, heuristic);
        }
    }
}
