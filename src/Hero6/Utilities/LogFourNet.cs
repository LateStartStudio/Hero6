// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogFourNet.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the LogFourNet type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Utilities
{
    using System;
    using System.IO;
    using System.Reflection;
    using log4net;

    public class LogFourNet : IDisposable, ILogger
    {
        private readonly ILog log;

        public LogFourNet()
        {
            string dir = string.Format(
                "{0}{1}Hero6{1}logs{1}",
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Path.DirectorySeparatorChar);

            string filename = $"Hero6-Log-{DateTime.Now}.txt";
            filename = filename.Replace(" ", "-");
            filename = filename.Replace(":", "-");
            filename = filename.Replace("/", "-");

            this.Filename = $"{dir}{filename}";

            this.WillDeleteLogOnDispose = true;

            GlobalContext.Properties["LogName"] = this.Filename;

            this.log = LogManager.GetLogger(typeof(LogFourNet).Name);

            this.Info($"Hero6 {Game.GraphicsApi} v{Assembly.GetExecutingAssembly().GetName().Version} Log");
            this.Info("Forums: http://www.hero6.org/forum/");
            this.Info("Bug Tracker: https://github.com/LateStartStudio/Hero6/issues");
            this.Info("E-mail: hero6lives@gmail.com");
        }

        ~LogFourNet()
        {
            this.Dispose();
        }

        public string Filename { get; }

        public bool WillDeleteLogOnDispose { get; set; }

        public void Dispose()
        {
            if (this.WillDeleteLogOnDispose)
            {
                File.Delete(this.Filename);
            }
        }

        public void Debug(string message)
        {
            if (this.log.IsDebugEnabled)
            {
                this.log.Debug(message);
            }
        }

        public void Debug(string message, Exception e)
        {
            if (this.log.IsDebugEnabled)
            {
                this.log.Debug(message, e);
            }
        }

        public void Info(string message)
        {
            if (this.log.IsInfoEnabled)
            {
                this.log.Info(message);
            }
        }

        public void Info(string message, Exception e)
        {
            if (this.log.IsInfoEnabled)
            {
                this.log.Info(message, e);
            }
        }

        public void Warning(string message)
        {
            if (this.log.IsWarnEnabled)
            {
                this.log.Info(message);
            }
        }

        public void Warning(string message, Exception e)
        {
            if (this.log.IsWarnEnabled)
            {
                this.log.Warn(message, e);
            }
        }

        public void Error(string message)
        {
            if (this.log.IsErrorEnabled)
            {
                this.log.Error(message);
            }
        }

        public void Error(string message, Exception e)
        {
            if (this.log.IsErrorEnabled)
            {
                this.log.Error(message, e);
            }
        }

        public void Fatal(string message)
        {
            if (this.log.IsFatalEnabled)
            {
                this.log.Fatal(message);
            }
        }

        public void Fatal(string message, Exception e)
        {
            if (this.log.IsFatalEnabled)
            {
                this.log.Fatal(message, e);
            }
        }
    }
}
