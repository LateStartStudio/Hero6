// <copyright file="MouseMove.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;

namespace LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse
{
    /// <summary>
    /// Mouse movement <see cref="EventArgs"/>.
    /// </summary>
    public class MouseMove : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MouseMove"/>.
        /// </summary>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        public MouseMove(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets the x position.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Gets the y position.
        /// </summary>
        public int Y { get; }
    }
}
