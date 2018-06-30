// <copyright file="IGameSettings.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Utilities.Settings
{
    /// <summary>
    /// A colletion of settings that are specified at design-time.
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
    }
}
