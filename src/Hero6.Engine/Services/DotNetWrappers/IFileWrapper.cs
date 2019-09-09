// <copyright file="IFileWrapper.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Services.DotNetWrappers
{
    /// <summary>
    /// Wrapper around System.IO.File for easier testing.
    /// </summary>
    public interface IFileWrapper
    {
        bool Exists(string path);

        void Delete(string path);

        string ReadAllText(string path);

        void WriteAllText(string path, string contents);
    }
}
