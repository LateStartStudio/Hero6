// <copyright file="TextBoxTests.cs" company="Late Start Studio">
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
    public class TextBoxTests
    {
        private SierraVgaServicesProvider services;
        private TextBox textBox;

        [SetUp]
        public void SetUp()
        {
            services = new SierraVgaServicesProvider();
            textBox = services.UserInterfaces.Current.GetDialog<TextBox>();
        }

        [Test]
        public void IsVisibleWhenInvokeShowTextBoxFromApi()
        {
            textBox.IsVisible = false;
            services.UserInterfaces.Current.ShowTextBox(string.Empty);
            Assert.That(textBox.IsVisible, Is.True);
        }

        [Test]
        public void ShowsTextInputWhenInvokeShowTextBoxFromApi()
        {
            textBox.Text = string.Empty;
            services.UserInterfaces.Current.ShowTextBox("test");
            Assert.That(textBox.Text, Is.EqualTo("test"));
        }

        [TestCase(MouseButton.Left)]
        [TestCase(MouseButton.Middle)]
        [TestCase(MouseButton.Right)]
        public void IsNotVisbleOnAnyMouseButtonPress(MouseButton button)
        {
            textBox.IsVisible = true;
            services.Mouse.ButtonPress += Raise.EventWith(new MouseButtonInteraction(0, 0, button));
            Assert.That(textBox.IsVisible, Is.False);
        }
    }
}
