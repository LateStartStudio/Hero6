// <copyright file="SettingsMock.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Utilities.Settings
{
    public class SettingsMock : IUserSettings
    {
        public bool IsFullScreen { get; set; }

        public int WindowWidth { get; set; }

        public int WindowHeight { get; set; }

        public void Save()
        {
        }
    }
}
