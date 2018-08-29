// <copyright file="ProjectConfigs.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Repository
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class ProjectConfigs
    {
        private List<string> files = new List<string>();

        [SetUp]
        public void SetUp()
        {
            string currentDir = System.AppDomain.CurrentDomain.BaseDirectory;
            string dir = new DirectoryInfo(currentDir).Parent.Parent.Parent.FullName;
            this.files = GetProjectFiles(dir);

            Assume.That(files.Count, Is.GreaterThan(0), "No .csproj files was found.");
        }

        [Test]
        public void AllProjectsAreSetToCsharpLanguageLevel6()
        {
            const string Expected = "<LangVersion>6</LangVersion>";

            files.ForEach(f => Assert.That(File.ReadAllText(f).Contains(Expected), Is.True, f));
        }

        [Test]
        public void AllProjectsAreSetToDottNetLevel4Dot6Dot1()
        {
            const string Expected = "<TargetFrameworkVersion>v4.6.1</TargetFrameworkVersion>";

            foreach (string file in files)
            {
                // Skip because target framework refers to Android SDK version
                if (file.Contains("Hero6.Android"))
                {
                    continue;
                }

                Assert.That(File.ReadAllText(file).Contains(Expected), Is.True, file);
            }
        }

        private static List<string> GetProjectFiles(string dir)
        {
            List<string> files = Directory.EnumerateFiles(dir).Where(file => file.EndsWith(".csproj")).ToList();
            Directory.EnumerateDirectories(dir).ToList().ForEach(d => files.AddRange(GetProjectFiles(d)));
            return files;
        }
    }
}
