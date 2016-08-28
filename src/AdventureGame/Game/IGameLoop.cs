// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGameLoop.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the IGameLoop interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Game
{
    using System;

    /// <summary>
    /// This interface contains functionality that covers the most basic Game Loop.
    /// </summary>
    public interface IGameLoop
    {
        /// <summary>
        /// Loads all assets.
        /// </summary>
        void Load();

        /// <summary>
        /// Unloads all assets.
        /// </summary>
        void Unload();

        /// <summary>
        /// Updates game logic.
        /// </summary>
        /// <param name="totalTime">The amount of game time since the start of the game.</param>
        /// <param name="elapsedTime">
        /// The amount of elapsed game time since the last update.
        /// </param>
        /// <param name="isRunningSlowly">
        /// Whether the game is running multiple updates this frame.
        /// </param>
        void Update(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly);

        /// <summary>
        /// Draws the game to the screen.
        /// </summary>
        /// <param name="totalTime">The amount of game time since the start of the game.</param>
        /// <param name="elapsedTime">
        /// The amount of elapsed game time since the last update.
        /// </param>
        /// <param name="isRunningSlowly">
        /// Whether the game is running multiple updates this frame.
        /// </param>
        void Draw(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly);
    }
}
