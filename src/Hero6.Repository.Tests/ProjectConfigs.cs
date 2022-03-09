// <copyright file="ProjectConfigs.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Repository
{
    [TestFixture]
    public class ProjectConfigs
    {
        private List<string> files = new List<string>();
        private string props;

        [SetUp]
        public void SetUp()
        {
            string currentDir = System.AppDomain.CurrentDomain.BaseDirectory;
            string dir = new DirectoryInfo(currentDir).Parent.Parent.Parent.Parent.FullName;
            files = GetProjectFiles(dir);
            props = File.ReadAllText("../../../../Directory.Build.props");
        }

        [Test]
        public void FindsAllProjects()
        {
            Assert.That(files.Count, Is.EqualTo(16));
        }

        [Test]
        public void AllProjectsAreSetToSupportedTargetFrameworkVersion()
        {
            var expected = new string[]
            {
                "<TargetFramework>netstandard2.0</TargetFramework>",
                "<TargetFramework>netcoreapp3.0</TargetFramework>",
            };

            files.ForEach(f => Assert.That(expected.Any(e => File.ReadAllText(f).Contains(e)), Is.True, f));
        }

        [Test]
        public void AllProjectsHaveWerrorEnabled()
        {
            files.ForEach(f => Assert.That(File.ReadAllText(f).Contains("<TreatWarningsAsErrors>true</TreatWarningsAsErrors>"), Is.False, f));
            Assert.That(props.Contains("<TreatWarningsAsErrors>true</TreatWarningsAsErrors>"), Is.True);
        }

        [Test]
        public void AllProjectsHaveStylecopConfigured()
        {
            files.ForEach(f =>
            {
                Assert.That(File.ReadAllText(f).Contains("stylecop.json"), Is.False, f);
                Assert.That(File.ReadAllText(f).Contains("Hero6.ruleset"), Is.False, f);
            });
            Assert.That(props.Contains("<AdditionalFiles Include=\"../stylecop.json\" Link=\"stylecop.json\" />"), Is.True);
            Assert.That(props.Contains("<CodeAnalysisRuleSet>../Hero6.ruleset</CodeAnalysisRuleSet>"), Is.True);
        }

        private static List<string> GetProjectFiles(string dir)
        {
            List<string> files = Directory.EnumerateFiles(dir).Where(file => file.EndsWith(".csproj")).ToList();
            Directory.EnumerateDirectories(dir).ToList().ForEach(d => files.AddRange(GetProjectFiles(d)));
            return files;
        }
    }
}
