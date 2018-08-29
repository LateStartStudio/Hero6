// <copyright file="StatusBarTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Windows
{
    using Dialogs;
    using Input;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using LateStartStudio.Hero6.Tests.HelperTools;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class StatusBarTests
    {
        private SierraVgaServicesProvider services;
        private StatusBar statusBar;

        [SetUp]
        public void SetUp()
        {
            services = new SierraVgaServicesProvider();
            statusBar = services.UserInterfaces.Current.GetWindow<StatusBar>();
            statusBar.IsVisible = true;
        }

        [Test]
        public void OnMouseEnterDoesNothingIfAnyDialogIsVisible()
        {
            services.UserInterfaces.Current.GetDialog<TextBox>().IsVisible = true;
            services.Mouse.Enter(statusBar);
            Assert.That(statusBar.IsVisible, Is.EqualTo(true));
        }

        [Test]
        public void HideStatusBarOnMouseEnter()
        {
            services.Mouse.Enter(statusBar);
            Assert.That(statusBar.IsVisible, Is.False);
        }

        [Test]
        public void ShowVerbBarOnMouseEnter()
        {
            var verbBar = services.UserInterfaces.Current.GetWindow<VerbBar>();
            verbBar.IsVisible = false;
            services.Mouse.Enter(statusBar);
            Assert.That(verbBar.IsVisible, Is.True);
        }

        [Test]
        public void ChangesCursorToArrowOnMouseEnter()
        {
            services.Mouse.Cursor = Cursor.Walk;
            services.Mouse.Enter(statusBar);
            Assert.That(services.Mouse.Cursor, Is.EqualTo(Cursor.Arrow));
        }

        [Test]
        public void PauseRendererOnMouseEnter()
        {
            services.Renderer.IsPaused = false;
            services.Mouse.Enter(statusBar);
            Assert.That(services.Renderer.IsPaused, Is.True);
        }

        [Test]
        public void SaveCursorOnMouseEnter()
        {
            services.Mouse.DidNotReceive().SaveCursor();
            services.Mouse.Enter(statusBar);
            services.Mouse.Received().SaveCursor();
        }
    }
}
