// <copyright file="UserSettings.Desktop.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

#if DESKTOPGL
namespace LateStartStudio.Hero6.Engine.Utilities.Settings
{
    public class UserSettings : IUserSettings
    {
        private readonly Properties.Settings settings;

        public UserSettings()
        {
            settings = Properties.Settings.Default;
            GameStartedCount++;
            Save();
        }

        public bool IsFullScreen
        {
            get { return settings.IsFullScreen; }
            set { settings.IsFullScreen = value; }
        }

        public int WindowWidth
        {
            get { return settings.WindowWidth; }
            set { settings.WindowWidth = value; }
        }

        public int WindowHeight
        {
            get { return settings.WindowHeight; }
            set { settings.WindowHeight = value; }
        }

        public int GameStartedCount
        {
            get { return settings.GameStartedCount; }
            private set { settings.GameStartedCount = value; }
        }

        public void Save() => settings.Save();

        public void Reset() => settings.Reset();
    }
}
#endif
