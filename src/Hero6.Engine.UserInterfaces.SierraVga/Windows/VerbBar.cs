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
    using Controls;
    using Dialogs;
    using Input;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using LateStartStudio.Hero6.Engine.Utilities.Settings;

    public class VerbBar : Window
    {
        private readonly IUserInterfaces userInterfaces;
        private readonly IMouse mouse;
        private readonly IGameSettings gameSettings;
        private readonly StackPanel stackPanel;

        private readonly Image sideLeft;
        private readonly Image sideRight;

        public VerbBar(
            IUserInterfaces userInterfaces,
            IUserInterfaceGenerator userInterfaceGenerator,
            IMouse mouse,
            IGameSettings gameSettings)
            : base(mouse)
        {
            this.userInterfaces = userInterfaces;
            this.mouse = mouse;
            this.gameSettings = gameSettings;
            IsVisible = false;
            var separator = Path.DirectorySeparatorChar;

            stackPanel = userInterfaceGenerator.MakeStackPanel(this);
            sideLeft = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Verb Bar{separator}Side Left", stackPanel);
            sideRight = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Verb Bar{separator}Side Right", stackPanel);

            WalkButton = userInterfaceGenerator.MakeButton(stackPanel);
            WalkImageBright = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Verb Bar{separator}Walk Light", WalkButton);
            WalkImageDark = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Verb Bar{separator}Walk Dark", WalkButton);
            WalkButton.Child = WalkImageDark;
            WalkButton.MouseButtonUp += WalkBtnOnLeftMouseButtonUp;
            WalkButton.MouseEnter += WalkBtnOnMouseEnter;
            WalkButton.MouseLeave += WalkBtnOnMouseLeave;

            LookButton = userInterfaceGenerator.MakeButton(stackPanel);
            LookImageBright = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Verb Bar{separator}Look Light", LookButton);
            LookImageDark = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Verb Bar{separator}Look Dark", LookButton);
            LookButton.Child = LookImageDark;
            LookButton.MouseButtonUp += LookBtnOnLeftMouseButtonUp;
            LookButton.MouseEnter += LookBtnOnMouseEnter;
            LookButton.MouseLeave += LookBtnOnMouseLeave;

            HandButton = userInterfaceGenerator.MakeButton(stackPanel);
            HandImageBright = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Verb Bar{separator}Hand Light", HandButton);
            HandImageDark = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Verb Bar{separator}Hand Dark", HandButton);
            HandButton.Child = HandImageDark;
            HandButton.MouseButtonUp += HandBtnOnLeftMouseButtonUp;
            HandButton.MouseEnter += HandBtnOnMouseEnter;
            HandButton.MouseLeave += HandBtnOnMouseLeave;

            TalkButton = userInterfaceGenerator.MakeButton(stackPanel);
            TalkImageBright = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Verb Bar{separator}Talk Light", TalkButton);
            TalkImageDark = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Verb Bar{separator}Talk Dark", TalkButton);
            TalkButton.Child = TalkImageDark;
            TalkButton.MouseButtonUp += TalkBtnOnLeftMouseButtonUp;
            TalkButton.MouseEnter += TalkBtnOnMouseEnter;
            TalkButton.MouseLeave += TalkBtnOnMouseLeave;

            SubMenuButton = userInterfaceGenerator.MakeButton(stackPanel);
            SubMenuImageBright = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Verb Bar{separator}Sub Menu Light", SubMenuButton);
            SubMenuImageDark = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Verb Bar{separator}Sub Menu Dark", SubMenuButton);
            SubMenuButton.Child = SubMenuImageDark;
            SubMenuButton.MouseButtonUp += SubMenuBtnOnLeftMouseButtonUp;
            SubMenuButton.MouseEnter += SubMenuBtnOnMouseEnter;
            SubMenuButton.MouseLeave += SubMenuBtnOnMouseLeave;

            MagicButton = userInterfaceGenerator.MakeButton(stackPanel);
            MagicImageBright = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Verb Bar{separator}Magic Light", MagicButton);
            MagicImageDark = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Verb Bar{separator}Magic Dark", MagicButton);
            MagicButton.Child = MagicImageDark;
            MagicButton.MouseButtonUp += MagicBtnOnLeftMouseButtonUp;
            MagicButton.MouseEnter += MagicBtnOnMouseEnter;
            MagicButton.MouseLeave += MagicBtnOnMouseLeave;

            CurrentItemButton = userInterfaceGenerator.MakeButton(stackPanel);
            CurrentItemImageBright = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Verb Bar{separator}Current Item Light", CurrentItemButton);
            CurrentItemImageDark = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Verb Bar{separator}Current Item Dark", CurrentItemButton);
            CurrentItemButton.Child = CurrentItemImageDark;
            CurrentItemButton.MouseButtonUp += CurrentItemBtnOnLeftMouseButtonUp;
            CurrentItemButton.MouseEnter += CurrentItemBtnOnMouseEnter;
            CurrentItemButton.MouseLeave += CurrentItemBtnOnMouseLeave;

            InventoryButton = userInterfaceGenerator.MakeButton(stackPanel);
            InventoryImageBright = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Verb Bar{separator}Inventory Light", InventoryButton);
            InventoryImageDark = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Verb Bar{separator}Inventory Dark", InventoryButton);
            InventoryButton.Child = InventoryImageDark;
            InventoryButton.MouseButtonUp += InventoryBtnOnLeftMouseButtonUp;
            InventoryButton.MouseEnter += InventoryBtnOnMouseEnter;
            InventoryButton.MouseLeave += InventoryBtnOnMouseLeave;

            OptionsButton = userInterfaceGenerator.MakeButton(stackPanel);
            OptionsImageBright = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Verb Bar{separator}Options Light", OptionsButton);
            OptionsImageDark = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Verb Bar{separator}Options Dark", OptionsButton);
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
            gameSettings.IsPaused = userInterfaces.Current.Dialogs.Any(d => d.Value.IsVisible);
            mouse.LoadCursor();
        }
    }
}
