// <copyright file="RestTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Dialogs
{
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class RestTests
    {
        private SierraVgaServicesProvider services;
        private Rest rest;

        [SetUp]
        public void SetUp()
        {
            services = new SierraVgaServicesProvider();
            rest = services.UserInterfaces.Current.GetDialog<Rest>();
            rest.IsVisible = true;
        }

        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnTenButton()
        {
            services.Mouse.Lift(rest.TenButton, MouseButton.Left);
            Assert.That(rest.IsVisible, Is.False);
        }

        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnThirtyButton()
        {
            services.Mouse.Lift(rest.ThirtyButton, MouseButton.Left);
            Assert.That(rest.IsVisible, Is.False);
        }

        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnSixtyButton()
        {
            services.Mouse.Lift(rest.SixtyButton, MouseButton.Left);
            Assert.That(rest.IsVisible, Is.False);
        }

        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnSleepButton()
        {
            services.Mouse.Lift(rest.SleepButton, MouseButton.Left);
            Assert.That(rest.IsVisible, Is.False);
        }

        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnCancelButton()
        {
            services.Mouse.Lift(rest.CancelButton, MouseButton.Left);
            Assert.That(rest.IsVisible, Is.False);
        }
    }
}
