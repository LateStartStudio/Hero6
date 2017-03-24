﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserSettings.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the IUserSettings interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Utilities.Settings
{
    /// <summary>
    /// Defines the interface for settable user settings.
    /// </summary>
    public interface IUserSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether the game should be run in full screen.
        /// </summary>
        /// <value>
        /// A value indicating whether the game should be run in full screen.
        /// </value>
        bool IsFullScreen { get; set; }

        /// <summary>
        /// Gets or sets a value representing the width of the window to render.
        /// </summary>
        /// <value>
        /// A value representing the width of the window to render.
        /// </value>
        int WindowWidth { get; set; }

        /// <summary>
        /// Gets or sets a value representing the height of the window to render.
        /// </summary>
        /// <value>
        /// A value representing the height of the window to render.
        /// </value>
        int WindowHeight { get; set; }

        /// <summary>
        /// Save settings to system.
        /// </summary>
        void Save();
    }
}
