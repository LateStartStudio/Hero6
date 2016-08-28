// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Hotspot.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the Hotspot type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Game
{
    using System;

    /// <summary>
    /// A class that represents a hot spot.
    /// </summary>
    public class Hotspot
    {
        /// <summary>
        /// Raised when a character is standing in a hot spot.
        /// </summary>
        public event EventHandler<HotspotWalkingEventArgs> WhileStandingIn;

        /// <summary>
        /// Invoke the event for standing in a hot spot.
        /// </summary>
        /// <param name="character">The character standing in a hot spot.</param>
        public void InvokeWhileStandingIn(Character character)
        {
            if (this.WhileStandingIn != null)
            {
                this.WhileStandingIn.Invoke(this, new HotspotWalkingEventArgs(character));
            }
        }
    }
}
