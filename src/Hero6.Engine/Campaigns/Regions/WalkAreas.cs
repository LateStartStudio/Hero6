// <copyright file="WalkAreas.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Regions
{
    using System.Collections.Generic;

    using LateStartStudio.Hero6.Engine.Assets.Graphics;

    /// <summary>
    /// A collections of walk areas.
    /// </summary>
    public class WalkAreas
    {
        /// <summary>
        /// Initializes a new instance of the class <see cref="WalkAreas"/>.
        /// </summary>
        /// <param name="areas">The walk areas.</param>
        public WalkAreas(IEnumerable<WalkArea> areas)
        {
            this.Areas = new List<WalkArea>(areas);
        }

        /// <summary>
        /// Gets all the walk areas.
        /// </summary>
        public IEnumerable<WalkArea> Areas { get; }

        /// <summary>
        /// Gets a path from start to end. Will return a path in the first walk area where the
        /// start and end node exists. If there are no walk areas where the start and end nodes
        /// exist it will return null.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end ndoe.</param>
        /// <returns>The first valid path found, null if no valid paths exists.</returns>
        public IEnumerable<Point> GetPath(Point start, Point end)
        {
            foreach (WalkArea area in Areas)
            {
                if (
                    !area.Nodes.ContainsKey((start.Y * area.Width) + start.X) ||
                    !area.Nodes.ContainsKey((end.Y * area.Width) + end.X))
                {
                    continue;
                }

                return area.GetPath(start, end);
            }

            return null;
        }
    }
}
