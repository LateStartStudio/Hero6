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

namespace LateStartStudio.Hero6.Engine.GameLoop
{
    using System;

    /// <summary>
    /// This interface contains functionality that covers the most basic Game Loop.
    /// </summary>
    public interface IGameLoop
    {
        /// <summary>
        /// Occurs on pre loading of assets in the game loop.
        /// </summary>
        event EventHandler<LoadEventArgs> PreLoad;

        /// <summary>
        /// Occurs on post loading of assets in the game loop.
        /// </summary>
        event EventHandler<LoadEventArgs> PostLoad;

        /// <summary>
        /// Occurs on pre unloading of assets in the game loop.
        /// </summary>
        event EventHandler<UnloadEventArgs> PreUnload;

        /// <summary>
        /// Occurs on post unloading of assets in the game loop.
        /// </summary>
        event EventHandler<UnloadEventArgs> PostUnload;

        /// <summary>
        /// Occurs on pre update in the game loop.
        /// </summary>
        event EventHandler<UpdateEventArgs> PreUpdate;

        /// <summary>
        /// Occurs on post update in the game loop.
        /// </summary>
        event EventHandler<UpdateEventArgs> PostUpdate;

        /// <summary>
        /// Occurs on pre draw in the game loop.
        /// </summary>
        event EventHandler<DrawEventArgs> PreDraw;

        /// <summary>
        /// Occurs on post update in the game loop.
        /// </summary>
        event EventHandler<DrawEventArgs> PostDraw;

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
        /// <param name="total">The amount of game time since the start of the game.</param>
        /// <param name="elapsed">
        /// The amount of elapsed game time since the last update.
        /// </param>
        /// <param name="isRunningSlowly">
        /// Whether the game is running multiple updates this frame.
        /// </param>
        void Update(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly);

        /// <summary>
        /// Draws the game to the screen.
        /// </summary>
        /// <param name="total">The amount of game time since the start of the game.</param>
        /// <param name="elapsed">
        /// The amount of elapsed game time since the last update.
        /// </param>
        /// <param name="isRunningSlowly">
        /// Whether the game is running multiple updates this frame.
        /// </param>
        void Draw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly);
    }
}
