// <copyright file="ExtensionBarTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Dialogs
{
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using LateStartStudio.Hero6.Tests.HelperTools;
    using NUnit.Framework;

    [TestFixture]
    public class ExtensionBarTests
    {
        private SierraVgaServicesProvider services;
        private ExtensionBar extensionBar;

        [SetUp]
        public void SetUp()
        {
            services = new SierraVgaServicesProvider();
            extensionBar = services.UserInterfaces.Current.GetDialog<ExtensionBar>();
        }

        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnLeftSide()
        {
            extensionBar.IsVisible = true;
            services.Mouse.Lift(extensionBar.LeftButton, MouseButton.Left);
            Assert.That(extensionBar.IsVisible, Is.False);
        }

        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnRightSide()
        {
            extensionBar.IsVisible = true;
            services.Mouse.Lift(extensionBar.RightButton, MouseButton.Left);
            Assert.That(extensionBar.IsVisible, Is.False);
        }

        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnRunButton()
        {
            extensionBar.IsVisible = true;
            services.Mouse.Lift(extensionBar.RunButton, MouseButton.Left);
            Assert.That(extensionBar.IsVisible, Is.False);
        }

        [Test]
        public void RunButtonIsBrightWhenMouseEnter()
        {
            extensionBar.RunButton.Child = extensionBar.RunImageDark;
            services.Mouse.Enter(extensionBar.RunButton);
            Assert.That(extensionBar.RunButton.Child, Is.EqualTo(extensionBar.RunImageBright));
        }

        [Test]
        public void RunButtonIsDarkWhenMouseLeave()
        {
            extensionBar.RunButton.Child = extensionBar.RunImageBright;
            services.Mouse.Leave(extensionBar.RunButton);
            Assert.That(extensionBar.RunButton.Child, Is.EqualTo(extensionBar.RunImageDark));
        }

        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnSneakButton()
        {
            extensionBar.IsVisible = true;
            services.Mouse.Lift(extensionBar.SneakButton, MouseButton.Left);
            Assert.That(extensionBar.IsVisible, Is.False);
        }

        [Test]
        public void SneakButtonIsBrightWhenMouseEnter()
        {
            extensionBar.SneakButton.Child = extensionBar.SneakImageDark;
            services.Mouse.Enter(extensionBar.SneakButton);
            Assert.That(extensionBar.SneakButton.Child, Is.EqualTo(extensionBar.SneakImageBright));
        }

        [Test]
        public void SneakButtonIsDarkWhenMouseLeave()
        {
            extensionBar.SneakButton.Child = extensionBar.SneakImageBright;
            services.Mouse.Leave(extensionBar.SneakButton);
            Assert.That(extensionBar.SneakButton.Child, Is.EqualTo(extensionBar.SneakImageDark));
        }

        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnCancelButton()
        {
            extensionBar.IsVisible = true;
            services.Mouse.Lift(extensionBar.SleepButton, MouseButton.Left);
            Assert.That(extensionBar.IsVisible, Is.False);
        }

        [Test]
        public void CancelButtonIsBrightWhenMouseEnter()
        {
            extensionBar.SleepButton.Child = extensionBar.SleepImageDark;
            services.Mouse.Enter(extensionBar.SleepButton);
            Assert.That(extensionBar.SleepButton.Child, Is.EqualTo(extensionBar.SleepImageBright));
        }

        [Test]
        public void CancelButtonIsDarkWhenMouseLeave()
        {
            extensionBar.SleepButton.Child = extensionBar.SleepImageBright;
            services.Mouse.Leave(extensionBar.SleepButton);
            Assert.That(extensionBar.SleepButton.Child, Is.EqualTo(extensionBar.SleepImageDark));
        }

        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnStatsButton()
        {
            extensionBar.IsVisible = true;
            services.Mouse.Lift(extensionBar.StatsButton, MouseButton.Left);
            Assert.That(extensionBar.IsVisible, Is.False);
        }

        [Test]
        public void StatsButtonIsBrightWhenMouseEnter()
        {
            extensionBar.StatsButton.Child = extensionBar.StatsImageDark;
            services.Mouse.Enter(extensionBar.StatsButton);
            Assert.That(extensionBar.StatsButton.Child, Is.EqualTo(extensionBar.StatsImageBright));
        }

        [Test]
        public void StatsButtonIsDarkWhenMouseLeave()
        {
            extensionBar.StatsButton.Child = extensionBar.StatsImageBright;
            services.Mouse.Leave(extensionBar.StatsButton);
            Assert.That(extensionBar.StatsButton.Child, Is.EqualTo(extensionBar.StatsImageDark));
        }

        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnTimeButton()
        {
            extensionBar.IsVisible = true;
            services.Mouse.Lift(extensionBar.TimeButton, MouseButton.Left);
            Assert.That(extensionBar.IsVisible, Is.False);
        }

        [Test]
        public void TimeButtonIsBrightWhenMouseEnter()
        {
            extensionBar.TimeButton.Child = extensionBar.TimeImageDark;
            services.Mouse.Enter(extensionBar.TimeButton);
            Assert.That(extensionBar.TimeButton.Child, Is.EqualTo(extensionBar.TimeImageBright));
        }

        [Test]
        public void TimeButtonIsDarkWhenMouseLeave()
        {
            extensionBar.TimeButton.Child = extensionBar.TimeImageBright;
            services.Mouse.Leave(extensionBar.TimeButton);
            Assert.That(extensionBar.TimeButton.Child, Is.EqualTo(extensionBar.TimeImageDark));
        }
    }
}
