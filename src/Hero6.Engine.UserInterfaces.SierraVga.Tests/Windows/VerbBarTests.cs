// <copyright file="VerbBarTests.cs" company="Late Start Studio">
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
    public class VerbBarTests
    {
        private SierraVgaServicesProvider services;
        private VerbBar verbBar;

        [SetUp]
        public void SetUp()
        {
            services = new SierraVgaServicesProvider();
            verbBar = services.UserInterfaces.Current.GetWindow<VerbBar>();
            verbBar.IsVisible = true;
        }

        [Test]
        public void ChangeCursorToWalkWhenLeftMouseButtonLiftOnWalkButton()
        {
            services.Mouse.Cursor = Cursor.Arrow;
            services.Mouse.Lift(verbBar.WalkButton, MouseButton.Left);
            Assert.That(services.Mouse.Cursor, Is.EqualTo(Cursor.Walk));
        }

        [TestCase(MouseButton.Middle)]
        [TestCase(MouseButton.Right)]
        public void DoNothingWhenAnyMouseButtonLiftOnWalkButtonExceptLeft(MouseButton button)
        {
            services.Mouse.Cursor = Cursor.Arrow;
            services.Mouse.Lift(verbBar.WalkButton, button);
            Assert.That(services.Mouse.Cursor, Is.EqualTo(Cursor.Arrow));
        }

        [Test]
        public void WalkButtonIsBrightWhenMouseEnter()
        {
            verbBar.WalkButton.Child = verbBar.WalkImageDark;
            services.Mouse.Enter(verbBar.WalkButton);
            Assert.That(verbBar.WalkButton.Child, Is.EqualTo(verbBar.WalkImageBright));
        }

        [Test]
        public void WalkButtonIsDarkWhenMouseLeave()
        {
            verbBar.WalkButton.Child = verbBar.WalkImageBright;
            services.Mouse.Leave(verbBar.WalkButton);
            Assert.That(verbBar.WalkButton.Child, Is.EqualTo(verbBar.WalkImageDark));
        }

        [Test]
        public void ChangeCursorToLookWhenLeftMouseButtonLiftOnLookButton()
        {
            services.Mouse.Cursor = Cursor.Arrow;
            services.Mouse.Lift(verbBar.LookButton, MouseButton.Left);
            Assert.That(services.Mouse.Cursor, Is.EqualTo(Cursor.Look));
        }

        [TestCase(MouseButton.Middle)]
        [TestCase(MouseButton.Right)]
        public void DoNothingWhenAnyMouseButtonLiftOnLookButtonExceptLeft(MouseButton button)
        {
            services.Mouse.Cursor = Cursor.Arrow;
            services.Mouse.Lift(verbBar.LookButton, button);
            Assert.That(services.Mouse.Cursor, Is.EqualTo(Cursor.Arrow));
        }

        [Test]
        public void LookButtonIsBrightWhenMouseEnter()
        {
            verbBar.LookButton.Child = verbBar.LookImageDark;
            services.Mouse.Enter(verbBar.LookButton);
            Assert.That(verbBar.LookButton.Child, Is.EqualTo(verbBar.LookImageBright));
        }

        [Test]
        public void LookButtonIsDarkWhenMouseLeave()
        {
            verbBar.LookButton.Child = verbBar.LookImageBright;
            services.Mouse.Leave(verbBar.LookButton);
            Assert.That(verbBar.LookButton.Child, Is.EqualTo(verbBar.LookImageDark));
        }

        [Test]
        public void ChangeCursorToHandWhenLeftMouseButtonLiftOnHandButton()
        {
            services.Mouse.Cursor = Cursor.Arrow;
            services.Mouse.Lift(verbBar.HandButton, MouseButton.Left);
            Assert.That(services.Mouse.Cursor, Is.EqualTo(Cursor.Hand));
        }

        [TestCase(MouseButton.Middle)]
        [TestCase(MouseButton.Right)]
        public void DoNothingWhenAnyMouseButtonLiftOnHandButtonExceptLeft(MouseButton button)
        {
            services.Mouse.Cursor = Cursor.Arrow;
            services.Mouse.Lift(verbBar.HandButton, button);
            Assert.That(services.Mouse.Cursor, Is.EqualTo(Cursor.Arrow));
        }

        [Test]
        public void HandButtonIsBrightWhenMouseEnter()
        {
            verbBar.HandButton.Child = verbBar.HandImageDark;
            services.Mouse.Enter(verbBar.HandButton);
            Assert.That(verbBar.HandButton.Child, Is.EqualTo(verbBar.HandImageBright));
        }

        [Test]
        public void HandButtonIsDarkWhenMouseLeave()
        {
            verbBar.HandButton.Child = verbBar.HandImageBright;
            services.Mouse.Leave(verbBar.HandButton);
            Assert.That(verbBar.HandButton.Child, Is.EqualTo(verbBar.HandImageDark));
        }

        [Test]
        public void ChangeCursorToTalkWhenLeftMouseButtonLiftOnTalkButton()
        {
            services.Mouse.Cursor = Cursor.Arrow;
            services.Mouse.Lift(verbBar.TalkButton, MouseButton.Left);
            Assert.That(services.Mouse.Cursor, Is.EqualTo(Cursor.Talk));
        }

        [TestCase(MouseButton.Middle)]
        [TestCase(MouseButton.Right)]
        public void DoNothingWhenAnyMouseButtonLiftOnTalkButtonExceptLeft(MouseButton button)
        {
            services.Mouse.Cursor = Cursor.Arrow;
            services.Mouse.Lift(verbBar.TalkButton, button);
            Assert.That(services.Mouse.Cursor, Is.EqualTo(Cursor.Arrow));
        }

        [Test]
        public void TalkButtonIsBrightWhenMouseEnter()
        {
            verbBar.TalkButton.Child = verbBar.TalkImageDark;
            services.Mouse.Enter(verbBar.TalkButton);
            Assert.That(verbBar.TalkButton.Child, Is.EqualTo(verbBar.TalkImageBright));
        }

        [Test]
        public void TalkButtonIsDarkWhenMouseLeave()
        {
            verbBar.TalkButton.Child = verbBar.TalkImageBright;
            services.Mouse.Leave(verbBar.TalkButton);
            Assert.That(verbBar.TalkButton.Child, Is.EqualTo(verbBar.TalkImageDark));
        }

        [Test]
        public void CursorCenterWhenLeftMouseButtonLiftOnSubMenuButton()
        {
            services.Mouse.Lift(verbBar.SubMenuButton, MouseButton.Left);
            services.Mouse.Received().Center();
        }

        [Test]
        public void ShowExtensionBarWhenLeftMouseButtonLiftOnSubMenuButton()
        {
            var extensionBar = services.UserInterfaces.Current.GetDialog<ExtensionBar>();
            extensionBar.IsVisible = false;
            services.Mouse.Lift(verbBar.SubMenuButton, MouseButton.Left);
            Assert.That(extensionBar.IsVisible, Is.True);
        }

        [TestCase(MouseButton.Middle)]
        [TestCase(MouseButton.Right)]
        public void DoNothingWhenAnyMouseButtonLiftOnSubMenuButtonExceptLeft(MouseButton button)
        {
            services.Mouse.Lift(verbBar.SubMenuButton, button);
            services.Mouse.DidNotReceive().Center();
        }

        [Test]
        public void SubMenuButtonIsBrightWhenMouseEnter()
        {
            verbBar.SubMenuButton.Child = verbBar.SubMenuImageDark;
            services.Mouse.Enter(verbBar.SubMenuButton);
            Assert.That(verbBar.SubMenuButton.Child, Is.EqualTo(verbBar.SubMenuImageBright));
        }

        [Test]
        public void SubMenuButtonIsDarkWhenMouseLeave()
        {
            verbBar.SubMenuButton.Child = verbBar.SubMenuImageBright;
            services.Mouse.Leave(verbBar.SubMenuButton);
            Assert.That(verbBar.SubMenuButton.Child, Is.EqualTo(verbBar.SubMenuImageDark));
        }

        [Test]
        public void CursorCenterWhenLeftMouseButtonLiftOnMagicButton()
        {
            services.Mouse.Lift(verbBar.MagicButton, MouseButton.Left);
            services.Mouse.Received().Center();
        }

        [TestCase(MouseButton.Middle)]
        [TestCase(MouseButton.Right)]
        public void DoNothingWhenAnyMouseButtonLiftOnMagicButtonExceptLeft(MouseButton button)
        {
            services.Mouse.Lift(verbBar.MagicButton, button);
            services.Mouse.DidNotReceive().Center();
        }

        [Test]
        public void MagicButtonIsBrightWhenMouseEnter()
        {
            verbBar.MagicButton.Child = verbBar.MagicImageDark;
            services.Mouse.Enter(verbBar.MagicButton);
            Assert.That(verbBar.MagicButton.Child, Is.EqualTo(verbBar.MagicImageBright));
        }

        [Test]
        public void MagicButtonIsDarkWhenMouseLeave()
        {
            verbBar.MagicButton.Child = verbBar.MagicImageBright;
            services.Mouse.Leave(verbBar.MagicButton);
            Assert.That(verbBar.MagicButton.Child, Is.EqualTo(verbBar.MagicImageDark));
        }

        [Test]
        public void CursorCenterWhenLeftMouseButtonLiftOnCurrentItemButton()
        {
            services.Mouse.Lift(verbBar.CurrentItemButton, MouseButton.Left);
            services.Mouse.Received().Center();
        }

        [TestCase(MouseButton.Middle)]
        [TestCase(MouseButton.Right)]
        public void DoNothingWhenAnyMouseButtonLiftOnCurrentItemButtonExceptLeft(MouseButton button)
        {
            services.Mouse.Lift(verbBar.CurrentItemButton, button);
            services.Mouse.DidNotReceive().Center();
        }

        [Test]
        public void CurrentItemButtonIsBrightWhenMouseEnter()
        {
            verbBar.CurrentItemButton.Child = verbBar.CurrentItemImageDark;
            services.Mouse.Enter(verbBar.CurrentItemButton);
            Assert.That(verbBar.CurrentItemButton.Child, Is.EqualTo(verbBar.CurrentItemImageBright));
        }

        [Test]
        public void CurrentItemButtonIsDarkWhenMouseLeave()
        {
            verbBar.CurrentItemButton.Child = verbBar.CurrentItemImageBright;
            services.Mouse.Leave(verbBar.CurrentItemButton);
            Assert.That(verbBar.CurrentItemButton.Child, Is.EqualTo(verbBar.CurrentItemImageDark));
        }

        [Test]
        public void CursorCenterWhenLeftMouseButtonLiftOnInventoryButton()
        {
            services.Mouse.Lift(verbBar.InventoryButton, MouseButton.Left);
            services.Mouse.Received().Center();
        }

        [TestCase(MouseButton.Middle)]
        [TestCase(MouseButton.Right)]
        public void DoNothingWhenAnyMouseButtonLiftOnInventoryButtonExceptLeft(MouseButton button)
        {
            services.Mouse.Lift(verbBar.InventoryButton, button);
            services.Mouse.DidNotReceive().Center();
        }

        [Test]
        public void InventoryButtonIsBrightWhenMouseEnter()
        {
            verbBar.InventoryButton.Child = verbBar.InventoryImageDark;
            services.Mouse.Enter(verbBar.InventoryButton);
            Assert.That(verbBar.InventoryButton.Child, Is.EqualTo(verbBar.InventoryImageBright));
        }

        [Test]
        public void InventoryButtonIsDarkWhenMouseLeave()
        {
            verbBar.InventoryButton.Child = verbBar.InventoryImageBright;
            services.Mouse.Leave(verbBar.InventoryButton);
            Assert.That(verbBar.InventoryButton.Child, Is.EqualTo(verbBar.InventoryImageDark));
        }

        [Test]
        public void CursorCenterWhenLeftMouseButtonLiftOnOptionsButton()
        {
            services.Mouse.Lift(verbBar.OptionsButton, MouseButton.Left);
            services.Mouse.Received().Center();
        }

        [TestCase(MouseButton.Middle)]
        [TestCase(MouseButton.Right)]
        public void DoNothingWhenAnyMouseButtonLiftOnOptionsButtonExceptLeft(MouseButton button)
        {
            services.Mouse.Lift(verbBar.OptionsButton, button);
            services.Mouse.DidNotReceive().Center();
        }

        [Test]
        public void OptionsButtonIsBrightWhenMouseEnter()
        {
            verbBar.OptionsButton.Child = verbBar.OptionsImageDark;
            services.Mouse.Enter(verbBar.OptionsButton);
            Assert.That(verbBar.OptionsButton.Child, Is.EqualTo(verbBar.OptionsImageBright));
        }

        [Test]
        public void OptionsButtonIsDarkWhenMouseLeave()
        {
            verbBar.OptionsButton.Child = verbBar.OptionsImageBright;
            services.Mouse.Leave(verbBar.OptionsButton);
            Assert.That(verbBar.OptionsButton.Child, Is.EqualTo(verbBar.OptionsImageDark));
        }

        [Test]
        public void ShowStatusBarOnMouseLeave()
        {
            var statusBar = services.UserInterfaces.Current.GetWindow<StatusBar>();
            statusBar.IsVisible = false;
            services.Mouse.Leave(verbBar);
            Assert.That(statusBar.IsVisible, Is.True);
        }

        [Test]
        public void HideOnMouseLeave()
        {
            verbBar.IsVisible = true;
            services.Mouse.Leave(verbBar);
            Assert.That(verbBar.IsVisible, Is.False);
        }

        [Test]
        public void UnpauseRendererOnMouseLeave()
        {
            services.Renderer.IsPaused = true;
            services.Mouse.Leave(verbBar);
            Assert.That(services.Renderer.IsPaused, Is.False);
        }

        [Test]
        public void DoNotUnpauseRendererOnMouseLeaveWhenAnyDialogVisible()
        {
            services.UserInterfaces.Current.GetDialog<TextBox>().IsVisible = true;
            services.Renderer.IsPaused = true;
            services.Mouse.Leave(verbBar);
            Assert.That(services.Renderer.IsPaused, Is.True);
        }

        [Test]
        public void LoadCursorOnMouseLeave()
        {
            services.Mouse.DidNotReceive().LoadCursor();
            services.Mouse.Leave(verbBar);
            services.Mouse.Received().LoadCursor();
        }
    }
}
