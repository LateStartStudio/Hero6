// <copyright file="FileWrapper.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.IO;

namespace LateStartStudio.Hero6.Engine.Utilities
{
    public class FileWrapper : IFileWrapper
    {
        public bool Exists(string path) => File.Exists(path);

        public void Delete(string path) => File.Delete(path);

        public string ReadAllText(string path) => File.ReadAllText(path);

        public void WriteAllText(string path, string contents) => File.WriteAllText(path, contents);
    }
}
