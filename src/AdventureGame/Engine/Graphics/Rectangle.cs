// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Rectangle.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the Rectangle type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Engine.Graphics
{
    /// <summary>
    /// A struct for a rectangle in x and y coordinates.
    /// </summary>
    public struct Rectangle
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
        /// Gets or sets the width.
        /// </summary>
        public int Width;

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        public int Height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> struct.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public Rectangle(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> struct by deep copy of two
        /// <see cref="Point"/> instances for x and y coordinates, width and height.
        /// </summary>
        /// <param name="location">The x and y coordinates.</param>
        /// <param name="size">The width and height.</param>
        public Rectangle(Point location, Point size)
        {
            this.X = location.X;
            this.Y = location.Y;
            this.Width = size.X;
            this.Height = size.Y;
        }

        /// <summary>
        /// Checks if the specified x and y coordinates is within the current instance.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>
        /// True if the x and y coordinates are within the rectangle; false otherwise.
        /// </returns>
        public bool Contains(int x, int y)
        {
            return x >= this.X && x <= this.X + this.Width && y >= this.Y && y <= this.Y + this.Height;
        }
    }
}
