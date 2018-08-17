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

        /// <summary>
        /// Convert a <see cref="Vector2"/> instance to a <see cref="Point"/> instance. Note that
        /// there is risk of losing data since this is a float to integer conversion.
        /// </summary>
        /// <param name="vector2">The <see cref="Vector2"/> instance to convert.</param>
        public static explicit operator Point(Vector2 vector2)
        {
            return new Point(vector2);
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }

        public static Point operator -(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }

        /// <inheritdoc />
        public override string ToString() => $"X = {X}, Y = {Y}";
    }
}
