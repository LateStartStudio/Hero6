// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILogger.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the ILogger interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Utilities
{
    using System;

    public interface ILogger
    {
        string Filename { get; }

        bool WillDeleteLogOnDispose { get; set; }

        void Debug(string message);

        void Debug(string message, Exception e);

        void Info(string message);

        void Info(string message, Exception e);

        void Warning(string message);

        void Warning(string message, Exception e);

        void Error(string message);

        void Error(string message, Exception e);

        void Fatal(string message);

        void Fatal(string message, Exception e);
    }
}
