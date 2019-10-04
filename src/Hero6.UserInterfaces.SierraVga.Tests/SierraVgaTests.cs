// <copyright file="SierraVgaTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.ModuleController.UserInterfaces;
using LateStartStudio.Hero6.ModuleController.UserInterfaces.Components;
using LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse;
using LateStartStudio.Hero6.Tests.Categories;
using LateStartStudio.Hero6.UserInterfaces.SierraVga;
using LateStartStudio.Hero6.UserInterfaces.SierraVga.Input;
using LateStartStudio.Hero6.UserInterfaces.SierraVga.Windows;
using NSubstitute;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga
{
    [TestFixture]
    [UnitCategory]
    public class SierraVgaTests : UserInterfaceTestBase<SierraVgaModule>
    {
        [Test]
        public void NameIsCorrect()
        {
            Assert.That(Module.Name, Is.EqualTo("Sierra VGA"));
        }

        [Test]
        public void CursorResetToWalkOnMiddleMouseButtonPress()
        {
            Services.Mouse.Cursor = Cursor.Hand;
            Services.Mouse.ButtonPress += Raise.EventWith(new MouseButtonInteraction(0, 0, MouseButton.Middle));
            Assert.That(Services.Mouse.Cursor, Is.EqualTo(Cursor.Walk));
        }

        [Test]
        public void CursorCyclesOnRightMouseButtonPress()
        {
            Services.Mouse.Cursor = Cursor.Walk;
            Services.Mouse.ButtonPress += Raise.EventWith(new MouseButtonInteraction(0, 0, MouseButton.Right));
            Assert.That(Services.Mouse.Cursor, Is.EqualTo(Cursor.Look));
            Services.Mouse.ButtonPress += Raise.EventWith(new MouseButtonInteraction(0, 0, MouseButton.Right));
            Assert.That(Services.Mouse.Cursor, Is.EqualTo(Cursor.Hand));
            Services.Mouse.ButtonPress += Raise.EventWith(new MouseButtonInteraction(0, 0, MouseButton.Right));
            Assert.That(Services.Mouse.Cursor, Is.EqualTo(Cursor.Talk));
            Services.Mouse.ButtonPress += Raise.EventWith(new MouseButtonInteraction(0, 0, MouseButton.Right));
            Assert.That(Services.Mouse.Cursor, Is.EqualTo(Cursor.Walk));
        }

        protected override SierraVgaModule MakeModule() => new SierraVgaModule(Services.Mouse, Services.Campaigns);

        protected override void PreInitialize()
        {
            base.PreInitialize();
            var controller = Substitute.For<WindowController>(Substitute.For<IWindowModule>(), Services.Services);
            Controller.GetWindow<StatusBar>().Returns(controller);
        }
    }
}
