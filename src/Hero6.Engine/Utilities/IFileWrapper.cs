// <copyright file="IFileWrapper.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Utilities
{
    /// <summary>
    /// Wrapper around System.IO.File for easier testing
    /// </summary>
    public interface IFileWrapper
    {
#pragma warning disable CS1591
#pragma warning disable SA1600
        bool Exists(string path);

        void Delete(string path);

        string ReadAllText(string path);

        void WriteAllText(string path, string contents);
#pragma warning restore SA1600
#pragma warning restore CS1591
    }
}
