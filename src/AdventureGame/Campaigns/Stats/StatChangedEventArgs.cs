// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatChangedEventArgs.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the StatChangedEventArgs type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Campaigns.Stats
{
    using System;

    /// <summary> 
    /// Event Args in event that a stat changes. 
    /// </summary> 
    public class StatChangedEventArgs : EventArgs
    {
        /// <summary> 
        /// Initializes a new instance of the <see cref="StatChangedEventArgs"/> class. 
        /// </summary> 
        /// <param name="stat">The stat type that was changed.</param> 
        /// <param name="value">The numeric value of the changed stat.</param> 
        public StatChangedEventArgs(Stat stat, uint value)
        {
            this.Stat = stat;
            this.Value = value;
        }

        /// <summary> 
        /// Gets the stat type that was changed. 
        /// </summary> 
        /// <value> 
        /// The statistic type that was changed. 
        /// </value> 
        public Stat Stat { get; private set; }

        /// <summary> 
        /// Gets the numeric value of the changed stat. 
        /// </summary> 
        /// <value> 
        /// The numeric value of the changed stat. 
        /// </value> 
        public uint Value { get; private set; }
    }
}
