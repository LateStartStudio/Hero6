// <copyright file="Logger.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Utilities.Logger
{
    using System;
    using System.IO;
    using System.Reflection;
    using LateStartStudio.Hero6.Engine.GameLoop;
    using LateStartStudio.Hero6.Engine.Utilities.Settings;
    using Microsoft.Xna.Framework;
    using Game = LateStartStudio.Hero6.Game;

    public class Logger : ILogger, IXnaGameLoop, IDisposable
    {
        private readonly IUserSettings userSettings;
        private readonly ILoggerCore loggerCore;

        public Logger(IUserSettings userSettings, ILoggerCore loggerCore)
        {
            this.userSettings = userSettings;
            this.loggerCore = loggerCore;
            Filename = LogFileName;
            WillDeleteLogOnDispose = true;
        }

        ~Logger()
        {
            Dispose();
        }

        public string Filename
        {
            get { return loggerCore.Filename; }
            private set { loggerCore.Filename = value; }
        }

        public bool WillDeleteLogOnDispose { get; set; }

        private static string LogFilesDir => $"{Game.UserFilesDir}.logs{Path.DirectorySeparatorChar}";

        private string LogFileName => $"{LogFilesDir}Hero6-Log-{userSettings.GameStartedCount}.txt";

        public void Dispose()
        {
            if (WillDeleteLogOnDispose)
            {
                loggerCore.DeleteLog();
            }
        }

        public void Info(string message) => loggerCore.Info(message);

        public void Warning(string message) => loggerCore.Warning(message);

        public void Error(string message) => loggerCore.Error(message);

        public void Exception(Exception exception) => loggerCore.Exception(exception);

        public void Initialize()
        {
            loggerCore.Configure();

            Info("This is the Hero6 log, if you're seeing this file it's most likely because Hero6 has crashed. Provide this file when you report the crash.");
            Info($"Hero6 {Game.GraphicsApi} v{Assembly.GetExecutingAssembly().GetName().Version} Log");
            Info("Forums: http://www.hero6.org/forum/");
            Info("Bug Tracker: https://github.com/LateStartStudio/Hero6/issues");
            Info("E-mail: hero6lives@gmail.com");
            Info("Creating Hero6 Game Instance.");
        }

        public void Load()
        {
        }

        public void Unload()
        {
        }

        public void Update(GameTime time)
        {
        }

        public void Draw(GameTime time)
        {
        }
    }
}
