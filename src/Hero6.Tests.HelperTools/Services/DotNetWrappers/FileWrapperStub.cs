// <copyright file="FileWrapperStub.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;

namespace LateStartStudio.Hero6.Services.DotNetWrappers
{
    public class FileWrapperStub : IFileWrapper
    {
        private readonly Dictionary<string, string> files = new Dictionary<string, string>();

        public bool DeleteInvoked { get; private set; }

        public bool Exists(string path) => files.ContainsKey(path);

        public void Delete(string path)
        {
            files.Remove(path);
            DeleteInvoked = true;
        }

        public string ReadAllText(string path) => files[path];

        public void WriteAllText(string path, string contents) => files[path] = contents;
    }
}
