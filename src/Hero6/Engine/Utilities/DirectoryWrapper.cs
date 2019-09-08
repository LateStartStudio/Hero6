// <copyright file="DirectoryWrapper.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.IO;

namespace LateStartStudio.Hero6.Engine.Utilities
{
    public class DirectoryWrapper : IDirectoryWrapper
    {
        public void CreateDirectory(string path) => Directory.CreateDirectory(path);
    }
}
