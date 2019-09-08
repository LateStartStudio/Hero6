// <copyright file="IMouse.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;

namespace LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse
{
    /// <summary>
    /// Interface containing basic core functionality of the mouse unit.
    /// </summary>
    public interface IMouse
    {
        /// <summary>
        /// Occurs when the mouse has changed x or y position.
        /// </summary>
        event EventHandler<MouseMove> Move;

        /// <summary>
        /// Occurs when any mouse button is pressed down.
        /// </summary>
        event EventHandler<MouseButtonInteraction> ButtonPress;

        /// <summary>
        /// Occurs when any mouse button is held down.
        /// </summary>
        event EventHandler<MouseButtonInteraction> ButtonHold;

        /// <summary>
        /// Occurs when any mouse button is lifted up.
        /// </summary>
        event EventHandler<MouseButtonInteraction> ButtonLift;

        /// <summary>
        /// Gets or sets mouse cursor.
        /// </summary>
        ICursor Cursor { get; set; }

        /// <summary>
        /// Gets or sets the x coordinate of the mouse.
        /// </summary>
        int X { get; set; }

        /// <summary>
        /// Gets or sets the y coordinate of the mouse.
        /// </summary>
        int Y { get; set; }

        /// <summary>
        /// Gets the scroll wheel value.
        /// </summary>
        int ScrollWheel { get; }

        /// <summary>
        /// Center the mouse in the middle of the window.
        /// </summary>
        void Center();

        /// <summary>
        /// Saves a backup of the cursor.
        /// </summary>
        void SaveCursor();

        /// <summary>
        /// Loads the backup of the cursor.
        /// </summary>
        void LoadCursor();
    }
}
