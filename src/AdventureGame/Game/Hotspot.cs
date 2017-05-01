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
        /// Raised when the player interacts with the character by looking, examining, or other
        /// equivalents.
        /// </summary>
        public event EventHandler<EventArgs> Look;

        /// <summary>
        /// Raised when the player interacts with the character by grabbing, taking, or other
        /// equivalents.
        /// </summary>
        public event EventHandler<EventArgs> Grab;

        /// <summary>
        /// Raised when the player interacts with the character by talking, asking, or other
        /// equivalents.
        /// </summary>
        public event EventHandler<EventArgs> Talk;

        /// <summary>
        /// Raised when a character is standing in a hot spot.
        /// </summary>
        public event EventHandler<HotspotWalkingEventArgs> WhileStandingIn;

        /// <summary>
        /// Invoke the event for looking at a hotspot.
        /// </summary>
        /// <param name="e">The hotspot looking event args.</param>
        public void InvokeLook(EventArgs e)
        {
            this.Look?.Invoke(this, e);
        }

        /// <summary>
        /// Invoke the event for grabbing a hotspot.
        /// </summary>
        /// <param name="e">The hotsport grabbing event args.</param>
        public void InvokeGrab(EventArgs e)
        {
            this.Grab?.Invoke(this, e);
        }

        /// <summary>
        /// Invoke the event for talking at a hotspot.
        /// </summary>
        /// <param name="e">The hotsport talking event args.</param>
        public void InvokeTalk(EventArgs e)
        {
            this.Talk?.Invoke(this, e);
        }

        /// <summary>
        /// Invoke the event for standing in a hot spot.
        /// </summary>
        /// <param name="e">The hotspot walking event args.</param>
        public void InvokeWhileStandingIn(HotspotWalkingEventArgs e)
        {
            this.WhileStandingIn?.Invoke(this, e);
        }
    }
}
