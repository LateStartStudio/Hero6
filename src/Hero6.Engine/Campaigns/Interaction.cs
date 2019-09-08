// <copyright file="Interaction.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
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
        Mouth,
    }
}
