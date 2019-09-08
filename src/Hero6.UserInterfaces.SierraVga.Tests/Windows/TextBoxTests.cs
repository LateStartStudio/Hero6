// <copyright file="TextBoxTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.ModuleController.UserInterfaces.Components;
using LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse;
using LateStartStudio.Hero6.Tests.Categories;
using LateStartStudio.Hero6.UserInterfaces.SierraVga.Windows;
using NSubstitute;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Dialogs
{
    [TestFixture]
    [Unit]
    public class TextBoxTests : WindowTestBase<TextBox>
    {
        [TestCase(MouseButton.Left)]
        [TestCase(MouseButton.Middle)]
        [TestCase(MouseButton.Right)]
        public void IsNotVisbleOnAnyMouseButtonPress(MouseButton button)
        {
            Module.IsVisible = true;
            Services.Mouse.ButtonPress += Raise.EventWith(new MouseButtonInteraction(0, 0, button));
            Assert.That(Module.IsVisible, Is.False);
        }

        protected override TextBox MakeModule() => new TextBox(Services.Mouse);
    }
}
