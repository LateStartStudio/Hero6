// <copyright file="UserSettingsTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Tests.Categories;
using NSubstitute;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Services.Settings
{
    [TestFixture]
    [UnitCategory]
    public class UserSettingsTests : ServiceTestBase<IUserSettings>
    {
        [Test]
        public void IsFullScreenDefaultValueIsFalse()
        {
            Assert.That(Service.IsFullScreen, Is.EqualTo(false));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void GetAndSetIsFullScreenPersistsOnNewInstance(bool isFullScreen)
        {
            Service.IsFullScreen = isFullScreen;
            Service.Save();
            Service = MakeService();
            Assert.That(Service.IsFullScreen, Is.EqualTo(isFullScreen));
        }

        [Test]
        public void WindowWidthDefaultValueIs960()
        {
            Assert.That(Service.WindowWidth, Is.EqualTo(960));
        }

        [TestCase(5)]
        [TestCase(10)]
        public void GetAndSetWindowWidth(int width)
        {
            Service.WindowWidth = width;
            Service.Save();
            Service = MakeService();
            Assert.That(Service.WindowWidth, Is.EqualTo(width));
        }

        [Test]
        public void WindowHeightDefaultValueIs720()
        {
            Assert.That(Service.WindowHeight, Is.EqualTo(720));
        }

        [TestCase(5)]
        [TestCase(10)]
        public void GetAndSetWindowHeight(int height)
        {
            Service.WindowHeight = height;
            Service.Save();
            Service = MakeService();
            Assert.That(Service.WindowHeight, Is.EqualTo(height));
        }

        [Test]
        public void GameStartedIncrementsOnNewInstance()
        {
            Assert.That(Service.GameStartedCount, Is.EqualTo(1));
            Service = MakeService();
            Assert.That(Service.GameStartedCount, Is.EqualTo(2));
            Service = MakeService();
            Assert.That(Service.GameStartedCount, Is.EqualTo(3));
        }

        [Test]
        public void ResetDeletesFile()
        {
            Service.Reset();
            Assert.That(Services.File.DeleteInvoked, Is.True);
        }

        [Test]
        public void SaveMakesDirectory()
        {
            Services.GameSettings.UserFilesDir.Returns("test");
            Service.Save();
            Services.Directory.Received().CreateDirectory("test");
        }

        protected override IUserSettings MakeService() => new UserSettings(Services.File, Services.Directory, Services.GameSettings);
    }
}
