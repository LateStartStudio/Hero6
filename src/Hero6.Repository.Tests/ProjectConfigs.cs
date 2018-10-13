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
            const string expected = "<LangVersion>6</LangVersion>";
            files.ForEach(f => Assert.That(File.ReadAllText(f).Contains(expected), Is.True, f));
        }

        [Test]
        public void AllProjectsAreSetToDottNetLevel461()
        {
            const string expected1 = "<TargetFrameworkVersion>v4.6.1</TargetFrameworkVersion>";
            const string expected2 = "<TargetFramework>net461</TargetFramework>";

            foreach (var f in files)
            {
                var content = File.ReadAllText(f);
                var result = content.Contains(expected1) || content.Contains(expected2);
                Assert.That(result, Is.True, f);
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
