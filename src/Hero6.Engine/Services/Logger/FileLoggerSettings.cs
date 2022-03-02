// <copyright file="FileLoggerSettings.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.IO;
using System.Linq;
using LateStartStudio.Hero6.Services.Settings;

namespace Hero6.Engine.Services.Logger
{
    /// <summary>
    /// Microsoft.Extensions.Logging doesn't support file logging out of the box so we need a 3rd party
    /// framework and also to configure it.
    /// </summary>
    public class FileLoggerSettings
    {
        private readonly IGameSettings gameSettings;

        public FileLoggerSettings(IGameSettings gameSettings, IUserSettings userSettings)
        {
            this.gameSettings = gameSettings;

            const string logFileNameFormat = "{0}Hero6-Log-{1}.txt";
            var logFileName = Enumerable
                .Range(0, int.MaxValue)
                .Select(i => string.Format(logFileNameFormat, LogFilesDir, i))
                .First(f => !File.Exists(f));
            FileName = logFileName;
        }

        public string FileName { get; }

        public bool WillDeleteLogOnDispose { get; set; } = true;

        private string LogFilesDir => $"{gameSettings.UserFilesDir}.logs{Path.DirectorySeparatorChar}";
    }
}
