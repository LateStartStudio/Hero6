// <copyright file="ILoggerCore.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;

namespace LateStartStudio.Hero6.Services.Logger
{
    public interface ILoggerCore
    {
        string Filename { get; set; }

        void Configure();

        void Info(string message);

        void Warning(string message);

        void Error(string message);

        void Exception(Exception exception);

        void DeleteLog();
    }
}
