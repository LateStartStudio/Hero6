// <copyright file="StandingOn.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions
{
    using System;
    using LateStartStudio.Hero6.Engine.Campaigns.Characters;

    public class StandingOn : EventArgs
    {
        public StandingOn(CharacterController character)
        {
            Character = character;
        }

        public CharacterModule Character { get; }
    }
}
