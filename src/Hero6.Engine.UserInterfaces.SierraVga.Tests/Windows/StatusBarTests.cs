// <copyright file="StatusBarTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Input;
using LateStartStudio.Hero6.Tests.HelperTools;
using LateStartStudio.Hero6.Tests.HelperTools.Categories;
using NSubstitute;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Windows
{
    [TestFixture]
    [Unit]
    public class StatusBarTests : WindowTestBase<StatusBar>
    {
        [Test]
        public void OnMouseEnterDoesNothingIfAnyDialogIsVisible()
        {
            Services.GameSettings.IsPaused.Returns(true);
            Controller.InvokeMouseEnter();
            Assert.That(Module.IsVisible, Is.True);
        }

        [Test]
        public void HideStatusBarOnMouseEnter()
        {
            Controller.InvokeMouseEnter();
            Assert.That(Module.IsVisible, Is.False);
        }

        [Test]
        public void ShowVerbBarOnMouseEnter()
        {
            var verbBar = Services.UserInterfaces.Current.GetWindow<VerbBar>();
            verbBar.IsVisible = false;
            Controller.InvokeMouseEnter();
            Assert.That(verbBar.IsVisible, Is.True);
        }

        [Test]
        public void ChangesCursorToArrowOnMouseEnter()
        {
            Services.Mouse.Cursor = Cursor.Walk;
            Controller.InvokeMouseEnter();
            Assert.That(Services.Mouse.Cursor, Is.EqualTo(Cursor.Arrow));
        }

        [Test]
        public void SaveCursorOnMouseEnter()
        {
            Controller.InvokeMouseEnter();
            Services.Mouse.Received().SaveCursor();
        }

        protected override StatusBar MakeModule() => new StatusBar(Services.UserInterfaces, Services.Mouse, Services.GameSettings);
    }
}
