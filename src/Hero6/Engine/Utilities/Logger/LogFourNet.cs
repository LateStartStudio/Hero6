// <copyright file="LogFourNet.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Utilities.Logger
{
    using System;
    using System.IO;
    using System.Reflection;
    using LateStartStudio.Hero6.Engine.Utilities.Settings;
    using log4net;
    using log4net.Config;

    /// <summary>
    /// The LogFourNet class, wrapper around the popular framework log4net.
    /// </summary>
    public class LogFourNet : IDisposable, ILogger
    {
        private readonly IUserSettings userSettings;
        private readonly ILog log;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogFourNet"/> class.
        /// </summary>
        public LogFourNet(IUserSettings userSettings)
        {
            this.userSettings = userSettings;
            Filename = LogFileName;
            WillDeleteLogOnDispose = true;
            log = LogManager.GetLogger(typeof(LogFourNet));
            var repo = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(repo, new FileInfo("Hero6.Logger.config"));

            Info("This is the Hero6 log, if you're seeing this file it's most likely because Hero6 has crashed. Provide this file when you report the crash.");
            Info($"Hero6 {Game.GraphicsApi} v{Assembly.GetExecutingAssembly().GetName().Version} Log");
            Info("Forums: http://www.hero6.org/forum/");
            Info("Bug Tracker: https://github.com/LateStartStudio/Hero6/issues");
            Info("E-mail: hero6lives@gmail.com");
            Info("Creating Hero6 Game Instance.");
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="LogFourNet"/> class. Calls
        /// IDisposable.Dispose().
        /// </summary>
        ~LogFourNet()
        {
            Dispose();
        }

        /// <inheritdoc />
        public string Filename
        {
            get { return (string)GlobalContext.Properties["LogName"]; }
            private set { GlobalContext.Properties["LogName"] = value; }
        }

        /// <inheritdoc />
        public bool WillDeleteLogOnDispose { get; set; }

        private static string LogFilesDir => $"{Game.UserFilesDir}.logs{Path.DirectorySeparatorChar}";

        private string LogFileName => $"{LogFilesDir}Hero6-Log-{userSettings.GameStartedCount}.txt";

        /// <inheritdoc />
        public void Dispose()
        {
            if (WillDeleteLogOnDispose)
            {
                File.Delete(Filename);
            }
        }

        /// <inheritdoc />
        public void Info(string message) => log.Info(message);

        /// <inheritdoc />
        public void Info(string message, Exception e) => log.Info(message, e);

        /// <inheritdoc />
        public void Warning(string message) => log.Warn(message);

        /// <inheritdoc />
        public void Warning(string message, Exception e) => log.Warn(message, e);

        /// <inheritdoc />
        public void Error(string message) => log.Error(message);

        /// <inheritdoc />
        public void Error(string message, Exception e) => log.Error(message, e);
    }
}
