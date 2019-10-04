// <copyright file="VerbBarTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.ModuleController.UserInterfaces.Components;
using LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse;
using LateStartStudio.Hero6.Tests.Categories;
using LateStartStudio.Hero6.UserInterfaces.SierraVga.Input;
using LateStartStudio.Hero6.UserInterfaces.SierraVga.Windows;
using NSubstitute;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Windows
{
    [TestFixture]
    [UnitCategory]
    public class VerbBarTests : WindowTestBase<VerbBar>
    {
        [Test]
        public void ChangeCursorToWalkWhenLeftMouseButtonLiftOnWalkButton()
        {
            Services.Mouse.Cursor = Cursor.Arrow;
            Module.WalkButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, MouseButton.Left));
            Assert.That(Services.Mouse.Cursor, Is.EqualTo(Cursor.Walk));
        }

        [TestCase(MouseButton.Middle)]
        [TestCase(MouseButton.Right)]
        public void DoNothingWhenAnyMouseButtonLiftOnWalkButtonExceptLeft(MouseButton button)
        {
            Services.Mouse.Cursor = Cursor.Arrow;
            Module.WalkButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, button));
            Assert.That(Services.Mouse.Cursor, Is.EqualTo(Cursor.Arrow));
        }

        [Test]
        public void WalkButtonIsBrightWhenMouseEnter()
        {
            Module.WalkButton.Child = Module.WalkImageDark;
            Module.WalkButton.MouseEnter += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.WalkButton.Child, Is.EqualTo(Module.WalkImageBright));
        }

        [Test]
        public void WalkButtonIsDarkWhenMouseLeave()
        {
            Module.WalkButton.Child = Module.WalkImageBright;
            Module.WalkButton.MouseLeave += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.WalkButton.Child, Is.EqualTo(Module.WalkImageDark));
        }

        [Test]
        public void ChangeCursorToLookWhenLeftMouseButtonLiftOnLookButton()
        {
            Services.Mouse.Cursor = Cursor.Arrow;
            Module.LookButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, MouseButton.Left));
            Assert.That(Services.Mouse.Cursor, Is.EqualTo(Cursor.Look));
        }

        [TestCase(MouseButton.Middle)]
        [TestCase(MouseButton.Right)]
        public void DoNothingWhenAnyMouseButtonLiftOnLookButtonExceptLeft(MouseButton button)
        {
            Services.Mouse.Cursor = Cursor.Arrow;
            Module.LookButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, button));
            Assert.That(Services.Mouse.Cursor, Is.EqualTo(Cursor.Arrow));
        }

        [Test]
        public void LookButtonIsBrightWhenMouseEnter()
        {
            Module.LookButton.Child = Module.LookImageDark;
            Module.LookButton.MouseEnter += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.LookButton.Child, Is.EqualTo(Module.LookImageBright));
        }

        [Test]
        public void LookButtonIsDarkWhenMouseLeave()
        {
            Module.LookButton.Child = Module.LookImageBright;
            Module.LookButton.MouseLeave += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.LookButton.Child, Is.EqualTo(Module.LookImageDark));
        }

        [Test]
        public void ChangeCursorToHandWhenLeftMouseButtonLiftOnHandButton()
        {
            Services.Mouse.Cursor = Cursor.Arrow;
            Module.HandButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, MouseButton.Left));
            Assert.That(Services.Mouse.Cursor, Is.EqualTo(Cursor.Hand));
        }

        [TestCase(MouseButton.Middle)]
        [TestCase(MouseButton.Right)]
        public void DoNothingWhenAnyMouseButtonLiftOnHandButtonExceptLeft(MouseButton button)
        {
            Services.Mouse.Cursor = Cursor.Arrow;
            Module.HandButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, button));
            Assert.That(Services.Mouse.Cursor, Is.EqualTo(Cursor.Arrow));
        }

        [Test]
        public void HandButtonIsBrightWhenMouseEnter()
        {
            Module.HandButton.Child = Module.HandImageDark;
            Module.HandButton.MouseEnter += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.HandButton.Child, Is.EqualTo(Module.HandImageBright));
        }

        [Test]
        public void HandButtonIsDarkWhenMouseLeave()
        {
            Module.HandButton.Child = Module.HandImageBright;
            Module.HandButton.MouseLeave += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.HandButton.Child, Is.EqualTo(Module.HandImageDark));
        }

        [Test]
        public void ChangeCursorToTalkWhenLeftMouseButtonLiftOnTalkButton()
        {
            Services.Mouse.Cursor = Cursor.Arrow;
            Module.TalkButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, MouseButton.Left));
            Assert.That(Services.Mouse.Cursor, Is.EqualTo(Cursor.Talk));
        }

        [TestCase(MouseButton.Middle)]
        [TestCase(MouseButton.Right)]
        public void DoNothingWhenAnyMouseButtonLiftOnTalkButtonExceptLeft(MouseButton button)
        {
            Services.Mouse.Cursor = Cursor.Arrow;
            Module.TalkButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, button));
            Assert.That(Services.Mouse.Cursor, Is.EqualTo(Cursor.Arrow));
        }

        [Test]
        public void TalkButtonIsBrightWhenMouseEnter()
        {
            Module.TalkButton.Child = Module.TalkImageDark;
            Module.TalkButton.MouseEnter += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.TalkButton.Child, Is.EqualTo(Module.TalkImageBright));
        }

        [Test]
        public void TalkButtonIsDarkWhenMouseLeave()
        {
            Module.TalkButton.Child = Module.TalkImageBright;
            Module.TalkButton.MouseLeave += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.TalkButton.Child, Is.EqualTo(Module.TalkImageDark));
        }

        [Test]
        public void CursorCenterWhenLeftMouseButtonLiftOnSubMenuButton()
        {
            Module.SubMenuButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, MouseButton.Left));
            Services.Mouse.Received().Center();
        }

        [Test]
        public void ShowExtensionBarWhenLeftMouseButtonLiftOnSubMenuButton()
        {
            var extensionBar = Services.UserInterfaces.Current.GetWindow<ExtensionBar>();
            extensionBar.IsVisible = false;
            Module.SubMenuButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, MouseButton.Left));
            Assert.That(extensionBar.IsVisible, Is.True);
        }

        [TestCase(MouseButton.Middle)]
        [TestCase(MouseButton.Right)]
        public void DoNothingWhenAnyMouseButtonLiftOnSubMenuButtonExceptLeft(MouseButton button)
        {
            Module.SubMenuButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, button));
            Services.Mouse.DidNotReceive().Center();
        }

        [Test]
        public void SubMenuButtonIsBrightWhenMouseEnter()
        {
            Module.SubMenuButton.Child = Module.SubMenuImageDark;
            Module.SubMenuButton.MouseEnter += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.SubMenuButton.Child, Is.EqualTo(Module.SubMenuImageBright));
        }

        [Test]
        public void SubMenuButtonIsDarkWhenMouseLeave()
        {
            Module.SubMenuButton.Child = Module.SubMenuImageBright;
            Module.SubMenuButton.MouseLeave += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.SubMenuButton.Child, Is.EqualTo(Module.SubMenuImageDark));
        }

        [Test]
        public void CursorCenterWhenLeftMouseButtonLiftOnMagicButton()
        {
            Module.MagicButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, MouseButton.Left));
            Services.Mouse.Received().Center();
        }

        [TestCase(MouseButton.Middle)]
        [TestCase(MouseButton.Right)]
        public void DoNothingWhenAnyMouseButtonLiftOnMagicButtonExceptLeft(MouseButton button)
        {
            Module.MagicButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, button));
            Services.Mouse.DidNotReceive().Center();
        }

        [Test]
        public void MagicButtonIsBrightWhenMouseEnter()
        {
            Module.MagicButton.Child = Module.MagicImageDark;
            Module.MagicButton.MouseEnter += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.MagicButton.Child, Is.EqualTo(Module.MagicImageBright));
        }

        [Test]
        public void MagicButtonIsDarkWhenMouseLeave()
        {
            Module.MagicButton.Child = Module.MagicImageBright;
            Module.MagicButton.MouseLeave += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.MagicButton.Child, Is.EqualTo(Module.MagicImageDark));
        }

        [Test]
        public void CursorCenterWhenLeftMouseButtonLiftOnCurrentItemButton()
        {
            Module.CurrentItemButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, MouseButton.Left));
            Services.Mouse.Received().Center();
        }

        [TestCase(MouseButton.Middle)]
        [TestCase(MouseButton.Right)]
        public void DoNothingWhenAnyMouseButtonLiftOnCurrentItemButtonExceptLeft(MouseButton button)
        {
            Module.CurrentItemButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, button));
            Services.Mouse.DidNotReceive().Center();
        }

        [Test]
        public void CurrentItemButtonIsBrightWhenMouseEnter()
        {
            Module.CurrentItemButton.Child = Module.CurrentItemImageDark;
            Module.CurrentItemButton.MouseEnter += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.CurrentItemButton.Child, Is.EqualTo(Module.CurrentItemImageBright));
        }

        [Test]
        public void CurrentItemButtonIsDarkWhenMouseLeave()
        {
            Module.CurrentItemButton.Child = Module.CurrentItemImageBright;
            Module.CurrentItemButton.MouseLeave += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.CurrentItemButton.Child, Is.EqualTo(Module.CurrentItemImageDark));
        }

        [Test]
        public void CursorCenterWhenLeftMouseButtonLiftOnInventoryButton()
        {
            Module.InventoryButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, MouseButton.Left));
            Services.Mouse.Received().Center();
        }

        [TestCase(MouseButton.Middle)]
        [TestCase(MouseButton.Right)]
        public void DoNothingWhenAnyMouseButtonLiftOnInventoryButtonExceptLeft(MouseButton button)
        {
            Module.InventoryButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, button));
            Services.Mouse.DidNotReceive().Center();
        }

        [Test]
        public void InventoryButtonIsBrightWhenMouseEnter()
        {
            Module.InventoryButton.Child = Module.InventoryImageDark;
            Module.InventoryButton.MouseEnter += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.InventoryButton.Child, Is.EqualTo(Module.InventoryImageBright));
        }

        [Test]
        public void InventoryButtonIsDarkWhenMouseLeave()
        {
            Module.InventoryButton.Child = Module.InventoryImageBright;
            Module.InventoryButton.MouseLeave += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.InventoryButton.Child, Is.EqualTo(Module.InventoryImageDark));
        }

        [Test]
        public void CursorCenterWhenLeftMouseButtonLiftOnOptionsButton()
        {
            Module.OptionsButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, MouseButton.Left));
            Services.Mouse.Received().Center();
        }

        [TestCase(MouseButton.Middle)]
        [TestCase(MouseButton.Right)]
        public void DoNothingWhenAnyMouseButtonLiftOnOptionsButtonExceptLeft(MouseButton button)
        {
            Module.OptionsButton.MouseButtonUp += Raise.EventWith(Module, new MouseButtonInteraction(0, 0, button));
            Services.Mouse.DidNotReceive().Center();
        }

        [Test]
        public void OptionsButtonIsBrightWhenMouseEnter()
        {
            Module.OptionsButton.Child = Module.OptionsImageDark;
            Module.OptionsButton.MouseEnter += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.OptionsButton.Child, Is.EqualTo(Module.OptionsImageBright));
        }

        [Test]
        public void OptionsButtonIsDarkWhenMouseLeave()
        {
            Module.OptionsButton.Child = Module.OptionsImageBright;
            Module.OptionsButton.MouseLeave += Raise.EventWith(Module, EventArgs.Empty);
            Assert.That(Module.OptionsButton.Child, Is.EqualTo(Module.OptionsImageDark));
        }

        [Test]
        public void ShowStatusBarOnMouseLeave()
        {
            var statusBar = Services.UserInterfaces.Current.GetWindow<StatusBar>();
            statusBar.IsVisible = false;
            Controller.InvokeMouseLeave();
            Assert.That(statusBar.IsVisible, Is.True);
        }

        [Test]
        public void HideOnMouseLeave()
        {
            Module.IsVisible = true;
            Controller.InvokeMouseLeave();
            Assert.That(Module.IsVisible, Is.False);
        }

        [Test]
        public void LoadCursorOnMouseLeave()
        {
            Services.Mouse.DidNotReceive().LoadCursor();
            Controller.InvokeMouseLeave();
            Services.Mouse.Received().LoadCursor();
        }

        protected override VerbBar MakeModule() => new VerbBar(Services.UserInterfaces, Services.Mouse);
    }
}
