// <copyright file="StandingOn.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.ModuleController.Campaigns.Characters;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Rooms.Regions
{
    /// <summary>
    /// Standing On Event Args.
    /// </summary>
    public class StandingOn : EventArgs
    {
        /// <summary>
        /// Makes a new instance of the <see cref="StandingOn"/> class.
        /// </summary>
        /// <param name="character">The character that invoked the <see cref="StandingOn"/> event.</param>
        public StandingOn(ICharacterModule character)
        {
            Character = character;
        }

        /// <summary>
        /// Gets the character.
        /// </summary>
        public ICharacterModule Character { get; }
    }
}
