// <copyright file="VerbBar.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.Engine.UserInterfaces.Components;
using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
using LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Dialogs;
using LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Input;

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Windows
{
    public class VerbBar : WindowModule
    {
        private readonly IUserInterfaces userInterfaces;
        private readonly IMouse mouse;

        private IStackPanelModule stackPanel;
        private IImageModule sideLeft;
        private IImageModule sideRight;

        public VerbBar(IUserInterfaces userInterfaces, IMouse mouse)
        {
            this.userInterfaces = userInterfaces;
            this.mouse = mouse;
        }

        public override string Name => "Verb Bar";

        public override bool IsDialog => false;

        public IButtonModule WalkButton { get; private set; }

        public IImageModule WalkImageBright { get; private set; }

        public IImageModule WalkImageDark { get; private set; }

        public IButtonModule LookButton { get; private set; }

        public IImageModule LookImageBright { get; private set; }

        public IImageModule LookImageDark { get; private set; }

        public IButtonModule HandButton { get; private set; }

        public IImageModule HandImageBright { get; private set; }

        public IImageModule HandImageDark { get; private set; }

        public IButtonModule TalkButton { get; private set; }

        public IImageModule TalkImageBright { get; private set; }

        public IImageModule TalkImageDark { get; private set; }

        public IButtonModule SubMenuButton { get; private set; }

        public IImageModule SubMenuImageBright { get; private set; }

        public IImageModule SubMenuImageDark { get; private set; }

        public IButtonModule MagicButton { get; private set; }

        public IImageModule MagicImageBright { get; private set; }

        public IImageModule MagicImageDark { get; private set; }

        public IButtonModule CurrentItemButton { get; private set; }

        public IImageModule CurrentItemImageBright { get; private set; }

        public IImageModule CurrentItemImageDark { get; private set; }

        public IButtonModule InventoryButton { get; private set; }

        public IImageModule InventoryImageBright { get; private set; }

        public IImageModule InventoryImageDark { get; private set; }

        public IButtonModule OptionsButton { get; private set; }

        public IImageModule OptionsImageBright { get; private set; }

        public IImageModule OptionsImageDark { get; private set; }

        public override void Initialize()
        {
            base.Initialize();

            IsVisible = false;
            stackPanel = MakeStackPanel(this);
            Child = stackPanel;
            stackPanel.Add(
                sideLeft = MakeImage(stackPanel, "Gui/Sierra Vga/Verb Bar/Side Left"),
                WalkButton = MakeButton(stackPanel),
                LookButton = MakeButton(stackPanel),
                HandButton = MakeButton(stackPanel),
                TalkButton = MakeButton(stackPanel),
                SubMenuButton = MakeButton(stackPanel),
                MagicButton = MakeButton(stackPanel),
                CurrentItemButton = MakeButton(stackPanel),
                InventoryButton = MakeButton(stackPanel),
                OptionsButton = MakeButton(stackPanel),
                sideRight = MakeImage(stackPanel, "Gui/Sierra Vga/Verb Bar/Side Right"));

            WalkImageBright = MakeImage(WalkButton, "Gui/Sierra Vga/Verb Bar/Walk Light");
            WalkImageDark = MakeImage(WalkButton, "Gui/Sierra Vga/Verb Bar/Walk Dark");
            WalkButton.Child = WalkImageDark;
            WalkButton.MouseButtonUp += WalkBtnOnLeftMouseButtonUp;
            WalkButton.MouseEnter += WalkBtnOnMouseEnter;
            WalkButton.MouseLeave += WalkBtnOnMouseLeave;

            LookImageBright = MakeImage(LookButton, "Gui/Sierra Vga/Verb Bar/Look Light");
            LookImageDark = MakeImage(LookButton, "Gui/Sierra Vga/Verb Bar/Look Dark");
            LookButton.Child = LookImageDark;
            LookButton.MouseButtonUp += LookBtnOnLeftMouseButtonUp;
            LookButton.MouseEnter += LookBtnOnMouseEnter;
            LookButton.MouseLeave += LookBtnOnMouseLeave;

            HandImageBright = MakeImage(HandButton, "Gui/Sierra Vga/Verb Bar/Hand Light");
            HandImageDark = MakeImage(HandButton, "Gui/Sierra Vga/Verb Bar/Hand Dark");
            HandButton.Child = HandImageDark;
            HandButton.MouseButtonUp += HandBtnOnLeftMouseButtonUp;
            HandButton.MouseEnter += HandBtnOnMouseEnter;
            HandButton.MouseLeave += HandBtnOnMouseLeave;

            TalkImageBright = MakeImage(TalkButton, "Gui/Sierra Vga/Verb Bar/Talk Light");
            TalkImageDark = MakeImage(TalkButton, "Gui/Sierra Vga/Verb Bar/Talk Dark");
            TalkButton.Child = TalkImageDark;
            TalkButton.MouseButtonUp += TalkBtnOnLeftMouseButtonUp;
            TalkButton.MouseEnter += TalkBtnOnMouseEnter;
            TalkButton.MouseLeave += TalkBtnOnMouseLeave;

            SubMenuImageBright = MakeImage(SubMenuButton, "Gui/Sierra Vga/Verb Bar/Sub Menu Light");
            SubMenuImageDark = MakeImage(SubMenuButton, "Gui/Sierra Vga/Verb Bar/Sub Menu Dark");
            SubMenuButton.Child = SubMenuImageDark;
            SubMenuButton.MouseButtonUp += SubMenuBtnOnLeftMouseButtonUp;
            SubMenuButton.MouseEnter += SubMenuBtnOnMouseEnter;
            SubMenuButton.MouseLeave += SubMenuBtnOnMouseLeave;

            MagicImageBright = MakeImage(MagicButton, "Gui/Sierra Vga/Verb Bar/Magic Light");
            MagicImageDark = MakeImage(MagicButton, "Gui/Sierra Vga/Verb Bar/Magic Dark");
            MagicButton.Child = MagicImageDark;
            MagicButton.MouseButtonUp += MagicBtnOnLeftMouseButtonUp;
            MagicButton.MouseEnter += MagicBtnOnMouseEnter;
            MagicButton.MouseLeave += MagicBtnOnMouseLeave;

            CurrentItemImageBright = MakeImage(CurrentItemButton, "Gui/Sierra Vga/Verb Bar/Current Item Light");
            CurrentItemImageDark = MakeImage(CurrentItemButton, "Gui/Sierra Vga/Verb Bar/Current Item Dark");
            CurrentItemButton.Child = CurrentItemImageDark;
            CurrentItemButton.MouseButtonUp += CurrentItemBtnOnLeftMouseButtonUp;
            CurrentItemButton.MouseEnter += CurrentItemBtnOnMouseEnter;
            CurrentItemButton.MouseLeave += CurrentItemBtnOnMouseLeave;

            InventoryImageBright = MakeImage(InventoryButton, "Gui/Sierra Vga/Verb Bar/Inventory Light");
            InventoryImageDark = MakeImage(InventoryButton, "Gui/Sierra Vga/Verb Bar/Inventory Dark");
            InventoryButton.Child = InventoryImageDark;
            InventoryButton.MouseButtonUp += InventoryBtnOnLeftMouseButtonUp;
            InventoryButton.MouseEnter += InventoryBtnOnMouseEnter;
            InventoryButton.MouseLeave += InventoryBtnOnMouseLeave;

            OptionsImageBright = MakeImage(OptionsButton, "Gui/Sierra Vga/Verb Bar/Options Light");
            OptionsImageDark = MakeImage(OptionsButton, "Gui/Sierra Vga/Verb Bar/Options Dark");
            OptionsButton.Child = OptionsImageDark;
            OptionsButton.MouseButtonUp += OptionsBtnOnLeftMouseButtonUp;
            OptionsButton.MouseEnter += OptionsBtnOnMouseEnter;
            OptionsButton.MouseLeave += OptionsBtnOnMouseLeave;

            MouseLeave += OnMouseLeave;
        }

        private void WalkBtnOnLeftMouseButtonUp(object sender, MouseButtonInteraction e)
        {
            if (e.Button != MouseButton.Left)
            {
                return;
            }

            ChangeMouseCursor(Cursor.Walk);
        }

        private void WalkBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            WalkButton.Child = WalkImageBright;
        }

        private void WalkBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            WalkButton.Child = WalkImageDark;
        }

        private void LookBtnOnLeftMouseButtonUp(object sender, MouseButtonInteraction e)
        {
            if (e.Button != MouseButton.Left)
            {
                return;
            }

            ChangeMouseCursor(Cursor.Look);
        }

        private void LookBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            LookButton.Child = LookImageBright;
        }

        private void LookBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            LookButton.Child = LookImageDark;
        }

        private void HandBtnOnLeftMouseButtonUp(object sender, MouseButtonInteraction e)
        {
            if (e.Button != MouseButton.Left)
            {
                return;
            }

            ChangeMouseCursor(Cursor.Hand);
        }

        private void HandBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            HandButton.Child = HandImageBright;
        }

        private void HandBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            HandButton.Child = HandImageDark;
        }

        private void TalkBtnOnLeftMouseButtonUp(object sender, MouseButtonInteraction e)
        {
            if (e.Button != MouseButton.Left)
            {
                return;
            }

            ChangeMouseCursor(Cursor.Talk);
        }

        private void TalkBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            TalkButton.Child = TalkImageBright;
        }

        private void TalkBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            TalkButton.Child = TalkImageDark;
        }

        private void SubMenuBtnOnLeftMouseButtonUp(object sender, MouseButtonInteraction e)
        {
            if (e.Button != MouseButton.Left)
            {
                return;
            }

            mouse.Center();
            userInterfaces.Current.GetWindow<ExtensionBar>().IsVisible = true;
        }

        private void SubMenuBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            SubMenuButton.Child = SubMenuImageBright;
        }

        private void SubMenuBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            SubMenuButton.Child = SubMenuImageDark;
        }

        private void MagicBtnOnLeftMouseButtonUp(object sender, MouseButtonInteraction e)
        {
            if (e.Button != MouseButton.Left)
            {
                return;
            }

            mouse.Center();
            userInterfaces.Current.ShowTextBox("Work In Progress");
        }

        private void MagicBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            MagicButton.Child = MagicImageBright;
        }

        private void MagicBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            MagicButton.Child = MagicImageDark;
        }

        private void CurrentItemBtnOnLeftMouseButtonUp(object sender, MouseButtonInteraction e)
        {
            if (e.Button != MouseButton.Left)
            {
                return;
            }

            mouse.Center();
            userInterfaces.Current.ShowTextBox("Work In Progress");
        }

        private void CurrentItemBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            CurrentItemButton.Child = CurrentItemImageBright;
        }

        private void CurrentItemBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            CurrentItemButton.Child = CurrentItemImageDark;
        }

        private void InventoryBtnOnLeftMouseButtonUp(object sender, MouseButtonInteraction e)
        {
            if (e.Button != MouseButton.Left)
            {
                return;
            }

            mouse.Center();
            userInterfaces.Current.ShowTextBox("Work In Progress");
        }

        private void InventoryBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            InventoryButton.Child = InventoryImageBright;
        }

        private void InventoryBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            InventoryButton.Child = InventoryImageDark;
        }

        private void OptionsBtnOnLeftMouseButtonUp(object sender, MouseButtonInteraction e)
        {
            if (e.Button != MouseButton.Left)
            {
                return;
            }

            mouse.Center();
            userInterfaces.Current.ShowTextBox("Work In Progress");
        }

        private void OptionsBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            OptionsButton.Child = OptionsImageBright;
        }

        private void OptionsBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            OptionsButton.Child = OptionsImageDark;
        }

        private void ChangeMouseCursor(ICursor cursor)
        {
            mouse.Cursor = cursor;
            mouse.SaveCursor();
            mouse.Y = Height;
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            IsVisible = false;
            userInterfaces.Current.GetWindow<StatusBar>().IsVisible = true;
            mouse.LoadCursor();
        }
    }
}
