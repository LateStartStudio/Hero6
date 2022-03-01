// <copyright file="FileLoggerHostedService.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using LateStartStudio.Hero6.Services.PlatformInfo;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Hero6.Engine.Services.Logger
{
    /// <summary>
    /// Handles Hero6 file logs.
    /// </summary>
    public class FileLoggerHostedService : IHostedService
    {
        private readonly ILogger logger;
        private readonly IPlatformInfo platformInfo;
        private readonly FileLoggerSettings fileLoggerSettings;

        public FileLoggerHostedService(ILogger<FileLoggerHostedService> logger, IPlatformInfo platformInfo, FileLoggerSettings fileLoggerSettings)
        {
            this.logger = logger;
            this.platformInfo = platformInfo;
            this.fileLoggerSettings = fileLoggerSettings;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("This is the Hero6 log, if you're seeing this file it's most likely because Hero6 has crashed. Provide this file when you report the crash.");
            logger.LogInformation($"Hero6 {platformInfo.Platform} v{Assembly.GetExecutingAssembly().GetName().Version} Log");
            logger.LogInformation("Forums: http://www.hero6.org/forum/");
            logger.LogInformation("Bug Tracker: https://github.com/LateStartStudio/Hero6/issues");
            logger.LogInformation("E-mail: hero6lives@gmail.com");
            logger.LogInformation("Creating Hero6 Game Instance.");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            if (fileLoggerSettings.WillDeleteLogOnDispose)
            {
                File.Delete(fileLoggerSettings.FileName);
            }

            return Task.CompletedTask;
        }
    }
}
