// <copyright file="LogFourNet.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Utilities.Logger
{
    using System;
    using System.IO;
    using log4net;

    /// <summary>
    /// The LogFourNet class, wrapper around the popular framework log4net.
    /// </summary>
    public class LogFourNet : IDisposable, ILogger
    {
        private readonly ILog log;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogFourNet"/> class.
        /// </summary>
        public LogFourNet()
        {
            this.Filename = LogFileName;
            this.WillDeleteLogOnDispose = true;
            this.log = LogManager.GetLogger(typeof(LogFourNet).Name);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="LogFourNet"/> class. Calls
        /// IDisposable.Dispose().
        /// </summary>
        ~LogFourNet()
        {
            this.Dispose();
        }

        /// <inheritdoc />
        public string Filename
        {
            get { return (string)GlobalContext.Properties["LogName"]; }
            private set { GlobalContext.Properties["LogName"] = value; }
        }

        /// <inheritdoc />
        public bool WillDeleteLogOnDispose { get; set; }

        private static string LogFilesDir => $"{Game.UserFilesDir}logs{Path.DirectorySeparatorChar}";

        private static string LogFileName => $"{LogFilesDir}Hero6-Log-{Util.UserSettings.GameStartedCount}.txt";

        /// <inheritdoc />
        public void Dispose()
        {
            if (this.WillDeleteLogOnDispose)
            {
                File.Delete(this.Filename);
            }
        }

        /// <inheritdoc />
        public void Debug(string message)
        {
            if (this.log.IsDebugEnabled)
            {
                this.log.Debug(message);
            }
        }

        /// <inheritdoc />
        public void Debug(string message, Exception e)
        {
            if (this.log.IsDebugEnabled)
            {
                this.log.Debug(message, e);
            }
        }

        /// <inheritdoc />
        public void Info(string message)
        {
            if (this.log.IsInfoEnabled)
            {
                this.log.Info(message);
            }
        }

        /// <inheritdoc />
        public void Info(string message, Exception e)
        {
            if (this.log.IsInfoEnabled)
            {
                this.log.Info(message, e);
            }
        }

        /// <inheritdoc />
        public void Warning(string message)
        {
            if (this.log.IsWarnEnabled)
            {
                this.log.Warn(message);
            }
        }

        /// <inheritdoc />
        public void Warning(string message, Exception e)
        {
            if (this.log.IsWarnEnabled)
            {
                this.log.Warn(message, e);
            }
        }

        /// <inheritdoc />
        public void Error(string message)
        {
            if (this.log.IsErrorEnabled)
            {
                this.log.Error(message);
            }
        }

        /// <inheritdoc />
        public void Error(string message, Exception e)
        {
            if (this.log.IsErrorEnabled)
            {
                this.log.Error(message, e);
            }
        }

        /// <inheritdoc />
        public void Fatal(string message)
        {
            if (this.log.IsFatalEnabled)
            {
                this.log.Fatal(message);
            }
        }

        /// <inheritdoc />
        public void Fatal(string message, Exception e)
        {
            if (this.log.IsFatalEnabled)
            {
                this.log.Fatal(message, e);
            }
        }
    }
}
