// <copyright file="DrawEventArgs.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.GameLoop
{
    using System;
    using Assets;

    /// <summary>
    /// Event Args for draw time of game loop.
    /// </summary>
    public class DrawEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DrawEventArgs"/> class.
        /// </summary>
        /// <param name="totalTime">The total time span since first update loop.</param>
        /// <param name="elapsedTime">The time span since previous update loop.</param>
        /// <param name="isRunningSlowly">
        /// A value indicating whether game is running slowly, true if it is, false if else.
        /// </param>
        /// <param name="renderer">The graphics handler.</param>
        public DrawEventArgs(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly, Renderer renderer)
        {
            this.TotalTime = totalTime;
            this.ElapsedTime = elapsedTime;
            this.IsRunningSlowly = isRunningSlowly;
            this.Renderer = renderer;
        }

        /// <summary>
        /// Gets the total time span since first update loop.
        /// </summary>
        /// <value>
        /// The total time span since first update loop.
        /// </value>
        public TimeSpan TotalTime { get; private set; }

        /// <summary>
        /// Gets the time span since previous update loop.
        /// </summary>
        /// <value>
        /// The time span since previous update loop.
        /// </value>
        public TimeSpan ElapsedTime { get; private set; }

        /// <summary>
        /// Gets a value indicating whether game is running slowly, true if it is, false if else.
        /// </summary>
        /// <value>
        /// A value indicating whether game is running slowly, true if it is, false if else.
        /// </value>
        public bool IsRunningSlowly { get; private set; }

        /// <summary>
        /// Gets the graphics handler.
        /// </summary>
        /// <value>
        /// The graphics handler.
        /// </value>
        public Renderer Renderer { get; private set; }
    }
}
