// <copyright file="VerbBar.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Windows
{
    using System;
    using System.IO;
    using System.Linq;
    using Assets;
    using Controls;
    using Dialogs;
    using Input;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;

    public class VerbBar : Window
    {
        private readonly IUserInterfaces userInterfaces;
        private readonly IRenderer renderer;
        private readonly IMouse mouse;
        private readonly StackPanel stackPanel;

        private readonly Image sideLeft;
        private readonly Image sideRight;

        public VerbBar(IUserInterfaces userInterfaces, IRenderer renderer, IMouse mouse)
            : base(mouse)
        {
            this.userInterfaces = userInterfaces;
            this.renderer = renderer;
            this.mouse = mouse;
            IsVisible = false;

            stackPanel = userInterfaces.Current.UserInterfaceGenerator.MakeStackPanel(this);
            sideLeft = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Verb Bar{Path.DirectorySeparatorChar}Side Left", stackPanel);
            sideRight = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Verb Bar{Path.DirectorySeparatorChar}Side Right", stackPanel);

            WalkButton = userInterfaces.Current.UserInterfaceGenerator.MakeButton(stackPanel);
            WalkImageBright = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Verb Bar{Path.DirectorySeparatorChar}Walk Light", WalkButton);
            WalkImageDark = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Verb Bar{Path.DirectorySeparatorChar}Walk Dark", WalkButton);
            WalkButton.Child = WalkImageDark;
            WalkButton.MouseButtonUp += WalkBtnOnLeftMouseButtonUp;
            WalkButton.MouseEnter += WalkBtnOnMouseEnter;
            WalkButton.MouseLeave += WalkBtnOnMouseLeave;

            LookButton = userInterfaces.Current.UserInterfaceGenerator.MakeButton(stackPanel);
            LookImageBright = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Verb Bar{Path.DirectorySeparatorChar}Look Light", LookButton);
            LookImageDark = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Verb Bar{Path.DirectorySeparatorChar}Look Dark", LookButton);
            LookButton.Child = LookImageDark;
            LookButton.MouseButtonUp += LookBtnOnLeftMouseButtonUp;
            LookButton.MouseEnter += LookBtnOnMouseEnter;
            LookButton.MouseLeave += LookBtnOnMouseLeave;

            HandButton = userInterfaces.Current.UserInterfaceGenerator.MakeButton(stackPanel);
            HandImageBright = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Verb Bar{Path.DirectorySeparatorChar}Hand Light", HandButton);
            HandImageDark = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Verb Bar{Path.DirectorySeparatorChar}Hand Dark", HandButton);
            HandButton.Child = HandImageDark;
            HandButton.MouseButtonUp += HandBtnOnLeftMouseButtonUp;
            HandButton.MouseEnter += HandBtnOnMouseEnter;
            HandButton.MouseLeave += HandBtnOnMouseLeave;

            TalkButton = userInterfaces.Current.UserInterfaceGenerator.MakeButton(stackPanel);
            TalkImageBright = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Verb Bar{Path.DirectorySeparatorChar}Talk Light", TalkButton);
            TalkImageDark = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Verb Bar{Path.DirectorySeparatorChar}Talk Dark", TalkButton);
            TalkButton.Child = TalkImageDark;
            TalkButton.MouseButtonUp += TalkBtnOnLeftMouseButtonUp;
            TalkButton.MouseEnter += TalkBtnOnMouseEnter;
            TalkButton.MouseLeave += TalkBtnOnMouseLeave;

            SubMenuButton = userInterfaces.Current.UserInterfaceGenerator.MakeButton(stackPanel);
            SubMenuImageBright = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Verb Bar{Path.DirectorySeparatorChar}Sub Menu Light", SubMenuButton);
            SubMenuImageDark = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Verb Bar{Path.DirectorySeparatorChar}Sub Menu Dark", SubMenuButton);
            SubMenuButton.Child = SubMenuImageDark;
            SubMenuButton.MouseButtonUp += SubMenuBtnOnLeftMouseButtonUp;
            SubMenuButton.MouseEnter += SubMenuBtnOnMouseEnter;
            SubMenuButton.MouseLeave += SubMenuBtnOnMouseLeave;

            MagicButton = userInterfaces.Current.UserInterfaceGenerator.MakeButton(stackPanel);
            MagicImageBright = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Verb Bar{Path.DirectorySeparatorChar}Magic Light", MagicButton);
            MagicImageDark = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Verb Bar{Path.DirectorySeparatorChar}Magic Dark", MagicButton);
            MagicButton.Child = MagicImageDark;
            MagicButton.MouseButtonUp += MagicBtnOnLeftMouseButtonUp;
            MagicButton.MouseEnter += MagicBtnOnMouseEnter;
            MagicButton.MouseLeave += MagicBtnOnMouseLeave;

            CurrentItemButton = userInterfaces.Current.UserInterfaceGenerator.MakeButton(stackPanel);
            CurrentItemImageBright = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Verb Bar{Path.DirectorySeparatorChar}Current Item Light", CurrentItemButton);
            CurrentItemImageDark = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Verb Bar{Path.DirectorySeparatorChar}Current Item Dark", CurrentItemButton);
            CurrentItemButton.Child = CurrentItemImageDark;
            CurrentItemButton.MouseButtonUp += CurrentItemBtnOnLeftMouseButtonUp;
            CurrentItemButton.MouseEnter += CurrentItemBtnOnMouseEnter;
            CurrentItemButton.MouseLeave += CurrentItemBtnOnMouseLeave;

            InventoryButton = userInterfaces.Current.UserInterfaceGenerator.MakeButton(stackPanel);
            InventoryImageBright = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Verb Bar{Path.DirectorySeparatorChar}Inventory Light", InventoryButton);
            InventoryImageDark = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Verb Bar{Path.DirectorySeparatorChar}Inventory Dark", InventoryButton);
            InventoryButton.Child = InventoryImageDark;
            InventoryButton.MouseButtonUp += InventoryBtnOnLeftMouseButtonUp;
            InventoryButton.MouseEnter += InventoryBtnOnMouseEnter;
            InventoryButton.MouseLeave += InventoryBtnOnMouseLeave;

            OptionsButton = userInterfaces.Current.UserInterfaceGenerator.MakeButton(stackPanel);
            OptionsImageBright = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Verb Bar{Path.DirectorySeparatorChar}Options Light", OptionsButton);
            OptionsImageDark = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Verb Bar{Path.DirectorySeparatorChar}Options Dark", OptionsButton);
            OptionsButton.Child = OptionsImageDark;
            OptionsButton.MouseButtonUp += OptionsBtnOnLeftMouseButtonUp;
            OptionsButton.MouseEnter += OptionsBtnOnMouseEnter;
            OptionsButton.MouseLeave += OptionsBtnOnMouseLeave;

            stackPanel.Children.Add(sideLeft);
            stackPanel.Children.Add(WalkButton);
            stackPanel.Children.Add(LookButton);
            stackPanel.Children.Add(HandButton);
            stackPanel.Children.Add(TalkButton);
            stackPanel.Children.Add(SubMenuButton);
            stackPanel.Children.Add(MagicButton);
            stackPanel.Children.Add(CurrentItemButton);
            stackPanel.Children.Add(InventoryButton);
            stackPanel.Children.Add(OptionsButton);
            stackPanel.Children.Add(sideRight);

            Child = stackPanel;
            MouseLeave += OnMouseLeave;
        }

        public Button WalkButton { get; }

        public Image WalkImageBright { get; }

        public Image WalkImageDark { get; }

        public Button LookButton { get; }

        public Image LookImageBright { get; }

        public Image LookImageDark { get; }

        public Button HandButton { get; }

        public Image HandImageBright { get; }

        public Image HandImageDark { get; }

        public Button TalkButton { get; }

        public Image TalkImageBright { get; }

        public Image TalkImageDark { get; }

        public Button SubMenuButton { get; }

        public Image SubMenuImageBright { get; }

        public Image SubMenuImageDark { get; }

        public Button MagicButton { get; }

        public Image MagicImageBright { get; }

        public Image MagicImageDark { get; }

        public Button CurrentItemButton { get; }

        public Image CurrentItemImageBright { get; }

        public Image CurrentItemImageDark { get; }

        public Button InventoryButton { get; }

        public Image InventoryImageBright { get; }

        public Image InventoryImageDark { get; }

        public Button OptionsButton { get; }

        public Image OptionsImageBright { get; }

        public Image OptionsImageDark { get; }

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
            userInterfaces.Current.GetDialog<ExtensionBar>().Show();
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
            userInterfaces.Current.GetWindow<StatusBar>().IsVisible = true;
            userInterfaces.Current.GetWindow<VerbBar>().IsVisible = false;
            renderer.IsPaused = userInterfaces.Current.Dialogs.Any(d => d.Value.IsVisible);
            mouse.LoadCursor();
        }
    }
}
