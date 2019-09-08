// <copyright file="RestTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Dialogs
{
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using LateStartStudio.Hero6.Tests.HelperTools;
    using LateStartStudio.Hero6.Tests.HelperTools.Categories;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    [Unit]
    public class RestTests : WindowTestBase<Rest>
    {
        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnTenButton()
        {
            Module.TenButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, MouseButton.Left));
            Assert.That(Module.IsVisible, Is.False);
        }

        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnThirtyButton()
        {
            Module.ThirtyButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, MouseButton.Left));
            Assert.That(Module.IsVisible, Is.False);
        }

        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnSixtyButton()
        {
            Module.SixtyButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, MouseButton.Left));
            Assert.That(Module.IsVisible, Is.False);
        }

        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnSleepButton()
        {
            Module.SleepButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, MouseButton.Left));
            Assert.That(Module.IsVisible, Is.False);
        }

        [Test]
        public void IsNotVisibleWhenLeftMouseButtonLiftOnCancelButton()
        {
            Module.CancelButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, MouseButton.Left));
            Assert.That(Module.IsVisible, Is.False);
        }

        protected override Rest MakeModule() => new Rest(Services.UserInterfaces);
    }
}
