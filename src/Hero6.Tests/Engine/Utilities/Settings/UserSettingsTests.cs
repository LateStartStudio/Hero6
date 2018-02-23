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
        public void SetUp() => this.userSettings = new UserSettings();

        [TestCase(true)]
        [TestCase(false)]
        public void GetAndSetIsFullScreen(bool isFullScreen)
        {
            userSettings.IsFullScreen = isFullScreen;
            userSettings.Save();
            Assert.That(userSettings.IsFullScreen, Is.EqualTo(isFullScreen));
        }

        [TestCase(5)]
        [TestCase(10)]
        public void GetAndSetWindowWidth(int width)
        {
            userSettings.WindowWidth = width;
            userSettings.Save();
            Assert.That(userSettings.WindowWidth, Is.EqualTo(width));
        }

        [TestCase(5)]
        [TestCase(10)]
        public void GetAndSetWindowHeight(int height)
        {
            userSettings.WindowHeight = height;
            userSettings.Save();
            Assert.That(userSettings.WindowHeight, Is.EqualTo(height));
        }
    }
}
