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

namespace LateStartStudio.Hero6.Engine.Utilities.Logger
{
    using System;

    /// <summary>
    /// Interface for loggging functions.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Gets the filename of the log.
        /// </summary>
        /// <value>
        /// The filename of the log.
        /// </value>
        string Filename { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the log file should be kept after logger
        /// instance is disposed. It will be deleted if true, but not if false.
        /// </summary>
        /// <value>
        /// A value indicating whether the log file should be kept after logger instance is
        /// disposed. It will be deleted if true, but not if false.
        /// </value>
        bool WillDeleteLogOnDispose { get; set; }

        /// <summary>
        /// Prints a message classified Debug to the log.
        /// </summary>
        /// <param name="message">The message to print.</param>
        void Debug(string message);

        /// <summary>
        /// Prints a message classified Debug to the log, including the stack trace of
        /// the exception.
        /// </summary>
        /// <param name="message">The message to print.</param>
        /// <param name="e">The exception to print.</param>
        void Debug(string message, Exception e);

        /// <summary>
        /// Prints a message classified Info to the log.
        /// </summary>
        /// <param name="message">The message to print.</param>
        void Info(string message);

        /// <summary>
        /// Prints a message classified Info to the log, including the stack trace of
        /// the exception.
        /// </summary>
        /// <param name="message">The message to print.</param>
        /// <param name="e">The exception to print.</param>
        void Info(string message, Exception e);

        /// <summary>
        /// Prints a message classified Warning to the log.
        /// </summary>
        /// <param name="message">The message to print.</param>
        void Warning(string message);

        /// <summary>
        /// Prints a message classified Warning to the log, including the stack trace of
        /// the exception.
        /// </summary>
        /// <param name="message">The message to print.</param>
        /// <param name="e">The exception to print.</param>
        void Warning(string message, Exception e);

        /// <summary>
        /// Prints a message classified Error to the log.
        /// </summary>
        /// <param name="message">The message to print.</param>
        void Error(string message);

        /// <summary>
        /// Prints a message classified Error to the log, including the stack trace of
        /// the exception.
        /// </summary>
        /// <param name="message">The message to print.</param>
        /// <param name="e">The exception to print.</param>
        void Error(string message, Exception e);

        /// <summary>
        /// Prints a message classified Fatal to the log.
        /// </summary>
        /// <param name="message">The message to print.</param>
        void Fatal(string message);

        /// <summary>
        /// Prints a message classified Fatal to the log, including the stack trace of
        /// the exception.
        /// </summary>
        /// <param name="message">The message to print.</param>
        /// <param name="e">The exception to print.</param>
        void Fatal(string message, Exception e);
    }
}
