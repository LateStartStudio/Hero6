// <copyright file="IDirectoryWrapper.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Utilities
{
    /// <summary>
    /// Wrapper around System.IO.Directory for easier testing.
    /// </summary>
    public interface IDirectoryWrapper
    {
        void CreateDirectory(string userFilesDir);
    }
}
