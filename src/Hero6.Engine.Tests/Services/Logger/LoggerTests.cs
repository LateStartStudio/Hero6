// <copyright file="LoggerTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.Tests.Categories;
using Microsoft.Xna.Framework;
using NSubstitute;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Services.Logger
{
    [TestFixture]
    [UnitCategory]
    public class LoggerTests : ServiceTestBase<ILogger>
    {
        [TestCase("Test 1")]
        [TestCase("Test 2")]
        public void GetFilenameIsRetrievedFromCore(string filename)
        {
            Services.LoggerCore.Filename = filename;
            Assert.That(Service.Filename, Is.EqualTo(filename));
        }

        [Test]
        public void WillDeleteLogOnDisposeIsTrueByDefault() => Assert.That(Service.WillDeleteLogOnDispose, Is.True);

        [Test]
        public void DisposeDeletesLogWhenFlagIsTrue()
        {
            Service.WillDeleteLogOnDispose = true;
            ((IDisposable)Service).Dispose();
            Services.LoggerCore.Received().DeleteLog();
        }

        [Test]
        public void DisposeDoesNotDeleteLogWhenFlagIsFalse()
        {
            Service.WillDeleteLogOnDispose = false;
            ((IDisposable)Service).Dispose();
            Services.LoggerCore.DidNotReceive().DeleteLog();
        }

        [TestCase("Test 1")]
        [TestCase("Test 2")]
        public void InfoLogsInfoStatement(string message)
        {
            Service.Info(message);
            Services.LoggerCore.Received().Info(message);
        }

        [TestCase("Test 1")]
        [TestCase("Test 2")]
        public void WarningLogsWarningStatement(string message)
        {
            Service.Warning(message);
            Services.LoggerCore.Received().Warning(message);
        }

        [TestCase("Test 1")]
        [TestCase("Test 2")]
        public void ErrorLogsErrorStatement(string message)
        {
            Service.Error(message);
            Services.LoggerCore.Received().Error(message);
        }

        [Test]
        public void ExceptionLogsException()
        {
            var exception = new Exception();
            Service.Exception(exception);
            Services.LoggerCore.Received().Exception(exception);
        }

        [Test]
        public void UpdateWithoutThrowingException()
        {
            Assert.DoesNotThrow(() => IXnaGameLoop.Update(new GameTime()));
        }

        [Test]
        public void DrawWithoutThrowingException()
        {
            Assert.DoesNotThrow(() => IXnaGameLoop.Draw(new GameTime()));
        }

        protected override ILogger MakeService()
        {
            return new Logger(Services.UserSettings, Services.GameSettings, Services.LoggerCore, Services.PlatformInfo);
        }
    }
}
