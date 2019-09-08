// <copyright file="ExtensionBarTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.Engine.UserInterfaces.Components;
using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
using LateStartStudio.Hero6.Tests.HelperTools;
using LateStartStudio.Hero6.Tests.HelperTools.Categories;
using NSubstitute;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Dialogs
{
    [TestFixture]
    [Unit]
    public class ExtensionBarTests : WindowTestBase<ExtensionBar>
    {
        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnLeftSide()
        {
            Module.IsVisible = true;
            Module.LeftButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, MouseButton.Left));
            Assert.That(Module.IsVisible, Is.False);
        }

        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnRightSide()
        {
            Module.IsVisible = true;
            Module.RightButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, MouseButton.Left));
            Assert.That(Module.IsVisible, Is.False);
        }

        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnRunButton()
        {
            Module.IsVisible = true;
            Module.RunButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, MouseButton.Left));
            Assert.That(Module.IsVisible, Is.False);
        }

        [Test]
        public void RunButtonIsBrightWhenMouseEnter()
        {
            Module.RunButton.Child = Module.RunImageDark;
            Module.RunButton.MouseEnter += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.RunButton.Child, Is.EqualTo(Module.RunImageBright));
        }

        [Test]
        public void RunButtonIsDarkWhenMouseLeave()
        {
            Module.RunButton.Child = Module.RunImageBright;
            Module.RunButton.MouseLeave += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.RunButton.Child, Is.EqualTo(Module.RunImageDark));
        }

        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnSneakButton()
        {
            Module.IsVisible = true;
            Module.SneakButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, MouseButton.Left));
            Assert.That(Module.IsVisible, Is.False);
        }

        [Test]
        public void SneakButtonIsBrightWhenMouseEnter()
        {
            Module.SneakButton.Child = Module.SneakImageDark;
            Module.SneakButton.MouseEnter += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.SneakButton.Child, Is.EqualTo(Module.SneakImageBright));
        }

        [Test]
        public void SneakButtonIsDarkWhenMouseLeave()
        {
            Module.SneakButton.Child = Module.SneakImageBright;
            Module.SneakButton.MouseLeave += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.SneakButton.Child, Is.EqualTo(Module.SneakImageDark));
        }

        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnCancelButton()
        {
            Services.UserInterfaces.Current.GetWindow<Rest>().Returns(Substitute.For<WindowModule>());
            Module.IsVisible = true;
            Module.SleepButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, MouseButton.Left));
            Assert.That(Module.IsVisible, Is.False);
        }

        [Test]
        public void CancelButtonIsBrightWhenMouseEnter()
        {
            Module.SleepButton.Child = Module.SleepImageDark;
            Module.SleepButton.MouseEnter += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.SleepButton.Child, Is.EqualTo(Module.SleepImageBright));
        }

        [Test]
        public void CancelButtonIsDarkWhenMouseLeave()
        {
            Module.SleepButton.Child = Module.SleepImageBright;
            Module.SleepButton.MouseLeave += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.SleepButton.Child, Is.EqualTo(Module.SleepImageDark));
        }

        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnStatsButton()
        {
            Module.IsVisible = true;
            Module.StatsButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, MouseButton.Left));
            Assert.That(Module.IsVisible, Is.False);
        }

        [Test]
        public void StatsButtonIsBrightWhenMouseEnter()
        {
            Module.StatsButton.Child = Module.StatsImageDark;
            Module.StatsButton.MouseEnter += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.StatsButton.Child, Is.EqualTo(Module.StatsImageBright));
        }

        [Test]
        public void StatsButtonIsDarkWhenMouseLeave()
        {
            Module.StatsButton.Child = Module.StatsImageBright;
            Module.StatsButton.MouseLeave += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.StatsButton.Child, Is.EqualTo(Module.StatsImageDark));
        }

        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnTimeButton()
        {
            Module.IsVisible = true;
            Module.TimeButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, MouseButton.Left));
            Assert.That(Module.IsVisible, Is.False);
        }

        [Test]
        public void TimeButtonIsBrightWhenMouseEnter()
        {
            Module.TimeButton.Child = Module.TimeImageDark;
            Module.TimeButton.MouseEnter += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.TimeButton.Child, Is.EqualTo(Module.TimeImageBright));
        }

        [Test]
        public void TimeButtonIsDarkWhenMouseLeave()
        {
            Module.TimeButton.Child = Module.TimeImageBright;
            Module.TimeButton.MouseLeave += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.TimeButton.Child, Is.EqualTo(Module.TimeImageDark));
        }

        protected override ExtensionBar MakeModule() => new ExtensionBar(Services.UserInterfaces);
    }
}
