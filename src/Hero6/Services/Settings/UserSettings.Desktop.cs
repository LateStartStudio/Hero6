// <copyright file="UserSettings.Desktop.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Services.DotNetWrappers;
using Newtonsoft.Json;

#if DESKTOPGL
namespace LateStartStudio.Hero6.Services.Settings
{
    public class UserSettings : IUserSettings
    {
        private readonly IFileWrapper file;
        private readonly IDirectoryWrapper directory;
        private readonly IGameSettings gameSettings;

        private UserSettingsData data;

        public UserSettings(IFileWrapper file, IDirectoryWrapper directory, IGameSettings gameSettings)
        {
            this.file = file;
            this.directory = directory;
            this.gameSettings = gameSettings;

            data = file.Exists(Filename)
                ? JsonConvert.DeserializeObject<UserSettingsData>(file.ReadAllText(Filename))
                : new UserSettingsData();

            GameStartedCount++;

            Save();
        }

        public bool IsFullScreen
        {
            get { return data.IsFullScreen; }
            set { data.IsFullScreen = value; }
        }

        public int WindowWidth
        {
            get { return data.WindowWidth; }
            set { data.WindowWidth = value; }
        }

        public int WindowHeight
        {
            get { return data.WindowHeight; }
            set { data.WindowHeight = value; }
        }

        public int GameStartedCount
        {
            get { return data.GameStartedCount; }
            private set { data.GameStartedCount = value; }
        }

        private string Filename => $"{gameSettings.UserFilesDir}.usersettings.json";

        public void Save()
        {
            // CreateDirectory does nothing if the directory already exists
            directory.CreateDirectory(gameSettings.UserFilesDir);

            file.WriteAllText(Filename, JsonConvert.SerializeObject(data));
        }

        public void Reset()
        {
            file.Delete(Filename);
            data = new UserSettingsData();
            Save();
        }

        private class UserSettingsData
        {
            public bool IsFullScreen { get; set; } = false;

            public int WindowWidth { get; set; } = 960;

            public int WindowHeight { get; set; } = 720;

            public int GameStartedCount { get; set; } = 0;
        }
    }
}
#endif
