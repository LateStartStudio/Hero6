// <copyright file="UserSettingsTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Utilities.Settings
{
    using NUnit.Framework;

    [TestFixture]
    public class UserSettingsTests
    {
        private IUserSettings userSettings;

        [SetUp]
        public void SetUp() => userSettings = new UserSettings();

        [TearDown]
        public void TearDown() => userSettings.Reset();

        [Test]
        public void IsFullScreenDefaultValueIsFalse()
        {
            Assert.That(userSettings.IsFullScreen, Is.EqualTo(false));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void GetAndSetIsFullScreen(bool isFullScreen)
        {
            userSettings.IsFullScreen = isFullScreen;
            userSettings.Save();
            userSettings = new UserSettings();
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
            userSettings = new UserSettings();
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
            userSettings = new UserSettings();
            Assert.That(userSettings.WindowHeight, Is.EqualTo(height));
        }

        [Test]
        public void GameStartedIncrementsWhenGameStart()
        {
            userSettings.Reset();
            Assert.That(userSettings.GameStartedCount, Is.EqualTo(1));
            userSettings = new UserSettings();
            Assert.That(userSettings.GameStartedCount, Is.EqualTo(2));
        }
    }
}
