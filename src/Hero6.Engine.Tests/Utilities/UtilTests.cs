// <copyright file="UtilTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Utilities
{
    using LateStartStudio.Hero6.Engine.Utilities.Logger;
    using LateStartStudio.Hero6.Engine.Utilities.Settings;
    using NUnit.Framework;

    [TestFixture]
    public class UtilTests
    {
        [Test]
        public void GetAndSetLogger()
        {
            ILogger logger = new LogFourNet("Test.txt");
            Util.Logger = logger;
            Assert.That(Util.Logger, Is.EqualTo(logger));
        }

        [Test]
        public void GetAndSetUserSettings()
        {
            IUserSettings settings = new SettingsMock();
            Util.UserSettings = settings;
            Assert.That(Util.UserSettings, Is.EqualTo(settings));
        }
    }
}
