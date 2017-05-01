// <copyright file="IMouse.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Input
{
    using LateStartStudio.Hero6.Engine.Assets.Graphics;

    /// <summary>
    /// Interface containing basic core functionality of the mouse unit.
    /// </summary>
    public interface IMouse
    {
        /// <summary>
        /// Gets or sets the x coordinate of the mouse.
        /// </summary>
        int X { get; set; }

        /// <summary>
        /// Gets or sets the y coordinate of the mouse.
        /// </summary>
        int Y { get; set; }

        /// <summary>
        /// Gets or sets the coordinates of the mouse.
        /// </summary>
        Point Location { get; set; }

        /// <summary>
        /// Gets the state of the left mouse button.
        /// </summary>
        MouseButtonState Left { get; }

        /// <summary>
        /// Gets the state of the middle mouse button.
        /// </summary>
        MouseButtonState Middle { get; }

        /// <summary>
        /// Gets the state of the right mouse button.
        /// </summary>
        MouseButtonState Right { get; }

        /// <summary>
        /// Gets the state of extra mouse button button 1.
        /// </summary>
        MouseButtonState X1 { get; }

        /// <summary>
        /// Gets the state of extra mouse button button 1.
        /// </summary>
        MouseButtonState X2 { get; }

        /// <summary>
        /// Gets the scroll wheel value.
        /// </summary>
        int ScrollWheel { get; }
    }
}
