// <copyright file="SierraVgaTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.ModuleController.UserInterfaces;
using LateStartStudio.Hero6.ModuleController.UserInterfaces.Components;
using LateStartStudio.Hero6.ModuleController.UserInterfaces.Input.Mouse;
using LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse;
using LateStartStudio.Hero6.Tests.Categories;
using LateStartStudio.Hero6.UserInterfaces.SierraVga;
using LateStartStudio.Hero6.UserInterfaces.SierraVga.Input.Mouse;
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
            var expected = Substitute.For<ICursorModule>();
            var controller = Substitute.For<CursorController>(expected, Services.Services, Services.Mouse, null, null);
            Controller.GetCursor<Walk>().Returns(controller);
            Services.Mouse.ButtonPress += Raise.EventWith(new MouseButtonInteraction(0, 0, MouseButton.Middle));
            Services.Mouse.Received().Cursor = expected;
        }

        [Test]
        public void CursorCyclesFromWalkToLookOnRightButtonPress() => CursorCycle<Walk, Look>();

        [Test]
        public void CursorCyclesFromLookToHandOnRightButtonPress() => CursorCycle<Look, Hand>();

        [Test]
        public void CursorCyclesFromHandToTalkOnRightButtonPress() => CursorCycle<Hand, Talk>();

        [Test]
        public void CursorCyclesFromTalkTowalkOnRightButtonPress() => CursorCycle<Look, Hand>();

        protected override SierraVgaModule MakeModule() => new SierraVgaModule(Services.Mouse, Services.Campaigns);

        protected override void PreInitialize()
        {
            base.PreInitialize();
            var statusBar = Substitute.For<WindowController>(Substitute.For<IWindowModule>(), Services.Services, Services.GameSettings, null, null, null);
            Controller.GetWindow<StatusBar>().Returns(statusBar);
            var walk = Substitute.For<CursorController>(Substitute.For<ICursorModule>(), Services.Services, Services.Mouse, null, null);
            Controller.GetCursor<Walk>().Returns(walk);
        }

        private void CursorCycle<TBefore, TAfter>()
            where TBefore : class, ICursorModule
            where TAfter : class, ICursorModule
        {
            Services.Mouse.Cursor.Equals<TBefore>().Returns(true);
            var after = Substitute.For<CursorController>(Substitute.For<ICursorModule>(), Services.Services, Services.Mouse, null, null);
            Controller.GetCursor<TAfter>().Returns(after);
            Services.Mouse.ButtonPress += Raise.EventWith(new MouseButtonInteraction(0, 0, MouseButton.Right));
            Assert.That(Services.Mouse.Cursor, Is.EqualTo(after.Module));
        }
    }
}
