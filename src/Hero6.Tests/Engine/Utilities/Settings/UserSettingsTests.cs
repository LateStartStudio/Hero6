// <copyright file="UserSettingsTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Tests.HelperTools.Utilities;
using NSubstitute;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Engine.Utilities.Settings
{
    [TestFixture]
    public class UserSettingsTests
    {
        private FileWrapperStub file;
        private IDirectoryWrapper directory;
        private UserSettings userSettings;

        [SetUp]
        public void SetUp()
        {
            var services = new Hero6ServicesProvider();
            file = services.File;
            directory = Substitute.For<IDirectoryWrapper>();

            userSettings = MakeUserSettings();
        }

        [Test]
        public void IsFullScreenDefaultValueIsFalse()
        {
            Assert.That(userSettings.IsFullScreen, Is.EqualTo(false));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void GetAndSetIsFullScreenPersistsOnNewInstance(bool isFullScreen)
        {
            userSettings.IsFullScreen = isFullScreen;
            userSettings.Save();
            userSettings = MakeUserSettings();
            Assert.That(userSettings.IsFullScreen, Is.EqualTo(isFullScreen));
        }

        [Test]
        public void WindowWidthDefaultValueIs960()
        {
            Assert.That(userSettings.WindowWidth, Is.EqualTo(960));
        }

        [TestCase(5)]
        [TestCase(10)]
        public void GetAndSetWindowWidth(int width)
        {
            userSettings.WindowWidth = width;
            userSettings.Save();
            userSettings = MakeUserSettings();
            Assert.That(userSettings.WindowWidth, Is.EqualTo(width));
        }

        [Test]
        public void WindowHeightDefaultValueIs720()
        {
            Assert.That(userSettings.WindowHeight, Is.EqualTo(720));
        }

        [TestCase(5)]
        [TestCase(10)]
        public void GetAndSetWindowHeight(int height)
        {
            userSettings.WindowHeight = height;
            userSettings.Save();
            userSettings = MakeUserSettings();
            Assert.That(userSettings.WindowHeight, Is.EqualTo(height));
        }

        [Test]
        public void GameStartedIncrementsOnNewInstance()
        {
            Assert.That(userSettings.GameStartedCount, Is.EqualTo(1));
            userSettings = MakeUserSettings();
            Assert.That(userSettings.GameStartedCount, Is.EqualTo(2));
            userSettings = MakeUserSettings();
            Assert.That(userSettings.GameStartedCount, Is.EqualTo(3));
        }

        [Test]
        public void ResetDeletesFile()
        {
            userSettings.Reset();
            Assert.That(file.DeleteInvoked, Is.True);
        }

        [Test]
        public void SaveMakesDirectory()
        {
            userSettings.Save();
            directory.Received().CreateDirectory(Game.UserFilesDir);
        }

        private UserSettings MakeUserSettings() => new UserSettings(file, directory);
    }
}
