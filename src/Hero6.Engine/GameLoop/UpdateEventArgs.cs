// <copyright file="UpdateEventArgs.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.GameLoop
{
    using System;

    /// <summary>
    /// Event Args for update time of game loop.
    /// </summary>
    public class UpdateEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEventArgs"/> class.
        /// </summary>
        /// <param name="total">The total time span since first update loop.</param>
        /// <param name="elapsed">The time span since previous update loop.</param>
        /// <param name="isRunningSlowly">
        /// A value indicating whether game is running slowly, true if it is, false if else.
        /// </param>
        public UpdateEventArgs(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            this.TotalTime = total;
            this.ElapsedTime = elapsed;
            this.IsRunningSlowly = isRunningSlowly;
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
    }
}
