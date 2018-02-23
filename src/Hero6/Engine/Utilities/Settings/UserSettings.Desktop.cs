// <copyright file="UserSettings.Desktop.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

#if DESKTOPGL
namespace LateStartStudio.Hero6.Engine.Utilities.Settings
{
    using Properties;

    public class UserSettings : IUserSettings
    {
        private readonly Settings settings;

        public UserSettings()
        {
            this.settings = Settings.Default;
            GameStartedCount++;
            Save();
        }

        public bool IsFullScreen
        {
            get { return this.settings.IsFullScreen; }
            set { this.settings.IsFullScreen = value; }
        }

        public int WindowWidth
        {
            get { return this.settings.WindowWidth; }
            set { this.settings.WindowWidth = value; }
        }

        public int WindowHeight
        {
            get { return this.settings.WindowHeight; }
            set { this.settings.WindowHeight = value; }
        }

        public int GameStartedCount
        {
            get { return settings.GameStartedCount; }
            private set { settings.GameStartedCount = value; }
        }

        public void Save()
        {
            this.settings.Save();
        }
    }
}
#endif
