// <copyright file="MouseButtonClickEventArgs.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Input
{
    /// <summary>
    /// Event args for when a mouse button is clicked.
    /// </summary>
    public class MouseButtonClickEventArgs
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MouseButtonClickEventArgs"/> class.
        /// </summary>
        /// <param name="x">The x coordinate of the mouse.</param>
        /// <param name="y">The y coordinate of the mouse.</param>
        /// <param name="button">The mouse button that was clicked.</param>
        public MouseButtonClickEventArgs(int x, int y, MouseButton button)
        {
            this.X = x;
            this.Y = y;
            this.Button = button;
        }

        /// <summary>
        /// Gets the x coordinate of the mouse.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Gets the y coordinate of the mouse.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Gets the mouse button that was clicked.
        /// </summary>
        public MouseButton Button { get; }
    }
}
