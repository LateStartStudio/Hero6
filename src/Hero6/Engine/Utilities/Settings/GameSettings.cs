// <copyright file="GameSettings.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Utilities.Settings
{
    public class GameSettings : IGameSettings
    {
        public int NativeWidth => 320;

        public int NativeHeight => 240;

        public bool IsPaused { get; set; }
    }
}
