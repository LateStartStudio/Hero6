// <copyright file="IGameSettings.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Utilities.Settings
{
    using System.Drawing;

    /// <summary>
    /// A collection of settings that are specified at design-time.
    /// </summary>
    public interface IGameSettings
    {
        /// <summary>
        /// Gets the native width of the game window.
        /// </summary>
        int NativeWidth { get; }

        /// <summary>
        /// Gets the native height of the game window.
        /// </summary>
        int NativeHeight { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the game should run or not.
        /// </summary>
        bool IsPaused { get; set; }

        /// <summary>
        /// Gets or sets a value the scale from the window resolution to the game resolution.
        /// </summary>
        PointF WindowScale { get; set; }
    }
}
