// <copyright file="IDirectoryWrapper.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Utilities
{
    /// <summary>
    /// Wrapper around System.IO.Directory for easier testing
    /// </summary>
    public interface IDirectoryWrapper
    {
#pragma warning disable CS1591
#pragma warning disable SA1600
        void CreateDirectory(string userFilesDir);
#pragma warning restore SA1600
#pragma warning restore CS1591
    }
}
