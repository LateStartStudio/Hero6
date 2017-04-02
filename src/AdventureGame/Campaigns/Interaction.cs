// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Interaction.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the Interaction enum.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Campaigns
{
    /// <summary>
    /// Enums for interaction types done by the player via input.
    /// </summary>
    public enum Interaction
    {
        /// <summary>
        /// Movement interaction.
        /// </summary>
        Move,

        /// <summary>
        /// Looking, examine interaction.
        /// </summary>
        Eye,

        /// <summary>
        /// Take, grab, push interaction.
        /// </summary>
        Hand,

        /// <summary>
        /// Talk, ask, yell interaction.
        /// </summary>
        Mouth
    }
}
