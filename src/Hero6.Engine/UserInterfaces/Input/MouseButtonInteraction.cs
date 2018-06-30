// <copyright file="MouseButtonInteraction.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Input
{
    using System;

    /// <summary>
    /// The <see cref="MouseButtonInteraction"/> <see cref="EventArgs"/>.
    /// </summary>
    public class MouseButtonInteraction : EventArgs
    {
        /// <summary>
        /// Initalizes a new instance of the <see cref="MouseButtonInteraction"/> <see cref="EventArgs"/>.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="button">The buttons used for this interaction.</param>
        public MouseButtonInteraction(int x, int y, MouseButton button)
        {
            X = x;
            Y = y;
            Y = y;
            Button = button;
        }

        /// <summary>
        /// Gets the x coordinate.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Gets the y coordinate.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Gets the button used for this interaction.
        /// </summary>
        public MouseButton Button { get; }
    }
}
