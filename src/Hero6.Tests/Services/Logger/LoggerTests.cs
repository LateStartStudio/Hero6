// <copyright file="LoggerTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.Services.Settings;
using Microsoft.Xna.Framework;
using NSubstitute;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Services.Logger
{
    [TestFixture]
    public class LoggerTests
    {
        private IUserSettings userSettings;
        private ILoggerCore loggerCore;
        private Logger logger;

        [SetUp]
        public void SetUp()
        {
            var services = new Hero6ServicesProvider();
            userSettings = services.UserSettings;
            loggerCore = services.LoggerCore;
            logger = new Logger(userSettings, loggerCore);
            logger.Initialize();
            logger.Load();
        }

        [TearDown]
        public void TearDown() => logger.Unload();

        [TestCase("Test 1")]
        [TestCase("Test 2")]
        public void GetFilenameIsRetrievedFromCore(string filename)
        {
            loggerCore.Filename = filename;
            Assert.That(logger.Filename, Is.EqualTo(filename));
        }

        [Test]
        public void WillDeleteLogOnDisposeIsTrueByDefault() => Assert.That(logger.WillDeleteLogOnDispose, Is.True);

        [Test]
        public void DisposeDeletesLogWhenFlagIsTrue()
        {
            logger.WillDeleteLogOnDispose = true;
            logger.Dispose();
            loggerCore.Received().DeleteLog();
        }

        [Test]
        public void DisposeDoesNotDeleteLogWhenFlagIsFalse()
        {
            logger.WillDeleteLogOnDispose = false;
            logger.Dispose();
            loggerCore.DidNotReceive().DeleteLog();
        }

        [TestCase("Test 1")]
        [TestCase("Test 2")]
        public void InfoLogsInfoStatement(string message)
        {
            logger.Info(message);
            loggerCore.Received().Info(message);
        }

        [TestCase("Test 1")]
        [TestCase("Test 2")]
        public void WarningLogsWarningStatement(string message)
        {
            logger.Warning(message);
            loggerCore.Received().Warning(message);
        }

        [TestCase("Test 1")]
        [TestCase("Test 2")]
        public void ErrorLogsErrorStatement(string message)
        {
            logger.Error(message);
            loggerCore.Received().Error(message);
        }

        [Test]
        public void ExceptionLogsException()
        {
            var exception = new Exception();
            logger.Exception(exception);
            loggerCore.Received().Exception(exception);
        }

        [Test]
        public void UpdateWithoutThrowingException()
        {
            Assert.DoesNotThrow(() => logger.Update(new GameTime()));
        }

        [Test]
        public void DrawWithoutThrowingException()
        {
            Assert.DoesNotThrow(() => logger.Draw(new GameTime()));
        }
    }
}
