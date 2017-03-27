﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateEventArgs.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the UpdateEventArgs event args.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.GameLoop
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
        /// <param name="totalTime">The total time span since first update loop.</param>
        /// <param name="elapsedTime">The time span since previous update loop.</param>
        /// <param name="isRunningSlowly">
        /// A value indicating whether game is running slowly, true if it is, false if else.
        /// </param>
        public UpdateEventArgs(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly)
        {
            this.TotalTime = totalTime;
            this.ElapsedTime = elapsedTime;
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
