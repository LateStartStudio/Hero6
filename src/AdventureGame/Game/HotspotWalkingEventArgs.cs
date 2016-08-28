// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HotspotWalkingEventArgs.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the HotspotWalkingEventArgs type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Game
{
    /// <summary>
    /// A class with the Event Args for walking interactions with hot spots.
    /// </summary>
    public class HotspotWalkingEventArgs : System.EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HotspotWalkingEventArgs"/> class.
        /// </summary>
        /// <param name="character">The character interacting with the hot spot.</param>
        public HotspotWalkingEventArgs(Character character)
        {
            Character = character;
        }

        /// <summary>
        /// Gets the character interacting with the hot spot.
        /// </summary>
        /// <value>
        /// The character interacting with the hot spot.
        /// </value>
        public Character Character
        {
            get; private set;
        }
    }
}
