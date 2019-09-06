// <copyright file="TextBoxTests.cs" company="Late Start Studio">
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
