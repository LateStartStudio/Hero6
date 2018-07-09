// <copyright file="SierraVgaTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga
{
    using System.Linq;
    using Input;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class SierraVgaTests
    {
        private SierraVgaServicesProvider services;
        private SierraVgaController sierraVga;

        [SetUp]
        public void SetUp()
        {
            services = new SierraVgaServicesProvider();
            sierraVga = services.UserInterfaces.Current as SierraVgaController;
        }

        [Test]
        public void NameIsCorrect()
        {
            Assert.That(sierraVga.Name, Is.EqualTo("Sierra VGA"));
        }

        [Test]
        public void DirectoryIsCorrect()
        {
            Assert.That(sierraVga.Directory, Is.EqualTo("Content/Gui/Sierra Vga"));
        }

        [Test]
        public void DialogsAreNotVisibleAtStart()
        {
            sierraVga.Dialogs.Values.ToList().ForEach(d => Assert.That(d.IsVisible, Is.False, d.ToString()));
        }

        [Test]
        public void WindowsAreNotVisibleAtStart()
        {
            sierraVga.Windows.Values.ToList().ForEach(w => Assert.That(w.IsVisible, Is.False, w.ToString()));
        }

        [Test]
        public void CursorResetToWalkOnMiddleMouseButtonPress()
        {
            services.Mouse.Cursor = Cursor.Hand;
            services.Mouse.ButtonPress += Raise.EventWith(new MouseButtonInteraction(0, 0, MouseButton.Middle));
            Assert.That(services.Mouse.Cursor, Is.EqualTo(Cursor.Walk));
        }

        [Test]
        public void CursorCyclesOnRightMouseButtonPress()
        {
            services.Mouse.Cursor = Cursor.Walk;
            services.Mouse.ButtonPress += Raise.EventWith(new MouseButtonInteraction(0, 0, MouseButton.Right));
            Assert.That(services.Mouse.Cursor, Is.EqualTo(Cursor.Look));
            services.Mouse.ButtonPress += Raise.EventWith(new MouseButtonInteraction(0, 0, MouseButton.Right));
            Assert.That(services.Mouse.Cursor, Is.EqualTo(Cursor.Hand));
            services.Mouse.ButtonPress += Raise.EventWith(new MouseButtonInteraction(0, 0, MouseButton.Right));
            Assert.That(services.Mouse.Cursor, Is.EqualTo(Cursor.Talk));
            services.Mouse.ButtonPress += Raise.EventWith(new MouseButtonInteraction(0, 0, MouseButton.Right));
            Assert.That(services.Mouse.Cursor, Is.EqualTo(Cursor.Walk));
        }
    }
}
