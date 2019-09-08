// <copyright file="LoggerCore.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;

namespace LateStartStudio.Hero6.Engine.Utilities.Logger
{
    public class LoggerCore : ILoggerCore
    {
        private readonly ILog logger;

        public LoggerCore()
        {
            logger = LogManager.GetLogger(typeof(Logger));
        }

        public string Filename
        {
            get { return (string)GlobalContext.Properties["LogName"]; }
            set { GlobalContext.Properties["LogName"] = value; }
        }

        public void Configure()
        {
            var repo = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(repo, new FileInfo("Hero6.Logger.config"));
        }

        public void Info(string message) => logger.Info(message);

        public void Warning(string message) => logger.Warn(message);

        public void Error(string message) => logger.Error(message);

        public void Exception(Exception exception) => logger.Error(string.Empty, exception);

        public void DeleteLog() => File.Delete(Filename);
    }
}
