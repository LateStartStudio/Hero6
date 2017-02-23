// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DummyLogger.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the DummyLogger type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Utilities
{
    using System;

    /// <summary>
    /// A dummy logger for platforms where logging is not currently implemented.
    /// </summary>
    public class DummyLogger : IDisposable, ILogger
    {
        public void Dispose()
        {
        }

        public string Filename => "Dummy Logger";

        public bool WillDeleteLogOnDispose { get; set; }

        public void Debug(string message)
        {
        }

        public void Debug(string message, Exception e)
        {
        }

        public void Info(string message)
        {
        }

        public void Info(string message, Exception e)
        {
        }

        public void Warning(string message)
        {
        }

        public void Warning(string message, Exception e)
        {
        }

        public void Error(string message)
        {
        }

        public void Error(string message, Exception e)
        {
        }

        public void Fatal(string message)
        {
        }

        public void Fatal(string message, Exception e)
        {
        }
    }
}
