// <copyright file="Point.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets.Graphics
{
    /// <summary>
    /// A struct for a point in x and y coordinates.
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// Gets or sets the x coordinate.
        /// </summary>
        public int X;

        /// <summary>
        /// Gets or sets the y coordinate.
        /// </summary>
        public int Y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct by deep copy of the x and
        /// y coordinates from a <see cref="Vector2"/> instance.
        /// </summary>
        /// <param name="vector">The vector instance to copy x and y coordinates from.</param>
        public Point(Vector2 vector)
        {
            this.X = (int)vector.X;
            this.Y = (int)vector.Y;
        }
    }
}
