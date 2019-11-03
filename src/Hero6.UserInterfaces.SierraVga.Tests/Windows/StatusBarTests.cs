﻿// <copyright file="StatusBarTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.ModuleController.UserInterfaces.Components;
using LateStartStudio.Hero6.ModuleController.UserInterfaces.Input.Mouse;
using LateStartStudio.Hero6.Tests.Categories;
using LateStartStudio.Hero6.UserInterfaces.SierraVga.Input.Mouse;
using LateStartStudio.Hero6.UserInterfaces.SierraVga.Windows;
using NSubstitute;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Windows
{
    [TestFixture]
    [UnitCategory]
    public class StatusBarTests : WindowTestBase<StatusBar>
    {
        [Test]
        public void OnMouseEnterDoesNothingIfAnyDialogIsVisible()
        {
            Services.GameSettings.IsPaused.Returns(true);
            Module.MouseEnter += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.IsVisible, Is.True);
        }

        [Test]
        public void HideStatusBarOnMouseEnter()
        {
            Module.MouseEnter += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.IsVisible, Is.False);
        }

        [Test]
        public void ShowVerbBarOnMouseEnter()
        {
            var verbBar = Services.UserInterfaces.Current.GetWindow<VerbBar>();
            verbBar.IsVisible = false;
            Module.MouseEnter += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(verbBar.IsVisible, Is.True);
        }

        [Test]
        public void ChangesCursorToArrowOnMouseEnter()
        {
            var expected = Substitute.For<ICursorModule>();
            Services.UserInterfaces.Current.GetCursor<Arrow>().Returns(expected);
            Module.MouseEnter += Raise.EventWith(Module, EventArgs.Empty);
            Services.Mouse.Received().Cursor = expected;
        }

        [Test]
        public void SaveCursorOnMouseEnter()
        {
            Module.MouseEnter += Raise.EventWith(Module, EventArgs.Empty);
            Services.Mouse.Received().SaveCursor();
        }

        protected override StatusBar MakeModule() => new StatusBar(Services.UserInterfaces, Services.Mouse, Services.GameSettings);
    }
}
