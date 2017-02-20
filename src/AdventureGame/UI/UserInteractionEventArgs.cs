// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserInteractionEventArgs.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the UserInteractionEventArgs type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.UI
{
    using System;

    /// <summary>
    /// Event Args to provide information for user interaction.
    /// </summary>
    public class UserInteractionEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserInteractionEventArgs"/> class.
        /// </summary>
        /// <param name="x">The x coordinate of the user interaction.</param>
        /// <param name="y">The y coordinate of the user interaction.</param>
        public UserInteractionEventArgs(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets the x coordinate of the user interaction.
        /// </summary>
        /// <value>
        /// The x coordinate of the user interaction.
        /// </value>
        public int X { get; private set; }

        /// <summary>
        /// Gets the y coordinate of the user interaction.
        /// </summary>
        /// <value>
        /// The y coordinate of the user interaction.
        /// </value>
        public int Y { get; private set; }
    }
}
