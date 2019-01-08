// <copyright file="ExtensionBar.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Dialogs
{
    using System;
    using System.IO;
    using Controls;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using Utilities.Settings;

    public class ExtensionBar : Dialog
    {
        private readonly IUserInterfaces userInterfaces;

        public ExtensionBar(
            IUserInterfaces userInterfaces,
            IUserInterfaceGenerator userInterfaceGenerator,
            IMouse mouse,
            IGameSettings gameSettings)
            : base(mouse, gameSettings)
        {
            this.userInterfaces = userInterfaces;
            var stackPanel = userInterfaceGenerator.MakeStackPanel(this);
            var separator = Path.DirectorySeparatorChar;

            LeftButton = userInterfaceGenerator.MakeButton(stackPanel);
            var left = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Extension Bar{separator}Left", LeftButton);
            LeftButton.Child = left;
            LeftButton.MouseButtonUp += SideOnMouseButtonUp;

            RightButton = userInterfaceGenerator.MakeButton(stackPanel);
            var right = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Extension Bar{Path.DirectorySeparatorChar}Right", RightButton);
            RightButton.Child = right;
            RightButton.MouseButtonUp += SideOnMouseButtonUp;

            RunButton = userInterfaceGenerator.MakeButton(stackPanel);
            RunImageBright = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Extension Bar{Path.DirectorySeparatorChar}Run Light", RunButton);
            RunImageDark = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Extension Bar{Path.DirectorySeparatorChar}Run Dark", RunButton);
            RunButton.Child = RunImageDark;
            RunButton.MouseButtonUp += RunOnMouseButtonUp;
            RunButton.MouseEnter += RunBtnOnMouseEnter;
            RunButton.MouseLeave += RunBtnOnMouseLeave;

            SneakButton = userInterfaceGenerator.MakeButton(stackPanel);
            SneakImageBright = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Extension Bar{Path.DirectorySeparatorChar}Sneak Light", SneakButton);
            SneakImageDark = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Extension Bar{Path.DirectorySeparatorChar}Sneak Dark", SneakButton);
            SneakButton.Child = SneakImageDark;
            SneakButton.MouseButtonUp += SneakOnMouseButtonUp;
            SneakButton.MouseEnter += SneakBtnOnMouseEnter;
            SneakButton.MouseLeave += SneakBtnOnMouseLeave;

            SleepButton = userInterfaceGenerator.MakeButton(stackPanel);
            SleepImageBright = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Extension Bar{Path.DirectorySeparatorChar}Sleep Light", SleepButton);
            SleepImageDark = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Extension Bar{Path.DirectorySeparatorChar}Sleep Dark", SleepButton);
            SleepButton.Child = SleepImageDark;
            SleepButton.MouseButtonUp += SleepOnMouseButtonUp;
            SleepButton.MouseEnter += SleepBtnOnMouseEnter;
            SleepButton.MouseLeave += SleepBtnOnMouseLeave;

            StatsButton = userInterfaceGenerator.MakeButton(stackPanel);
            StatsImageBright = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Extension Bar{Path.DirectorySeparatorChar}Stats Light", StatsButton);
            StatsImageDark = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Extension Bar{Path.DirectorySeparatorChar}Stats Dark", StatsButton);
            StatsButton.Child = StatsImageDark;
            StatsButton.MouseButtonUp += StatsOnMouseButtonUp;
            StatsButton.MouseEnter += StatsBtnOnMouseEnter;
            StatsButton.MouseLeave += StatsBtnOnMouseLeave;

            TimeButton = userInterfaceGenerator.MakeButton(stackPanel);
            TimeImageBright = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Extension Bar{Path.DirectorySeparatorChar}Time Light", TimeButton);
            TimeImageDark = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Extension Bar{Path.DirectorySeparatorChar}Time Dark", TimeButton);
            TimeButton.Child = TimeImageDark;
            TimeButton.MouseButtonUp += TimeOnMouseButtonUp;
            TimeButton.MouseEnter += TimeBtnOnMouseEnter;
            TimeButton.MouseLeave += TimeBtnOnMouseLeave;

            stackPanel.Children.Add(LeftButton);
            stackPanel.Children.Add(RunButton);
            stackPanel.Children.Add(SneakButton);
            stackPanel.Children.Add(SleepButton);
            stackPanel.Children.Add(StatsButton);
            stackPanel.Children.Add(TimeButton);
            stackPanel.Children.Add(RightButton);

            Child = stackPanel;
        }

        public Button LeftButton { get; }

        public Button RightButton { get; }

        public Button RunButton { get; }

        public Image RunImageBright { get; }

        public Image RunImageDark { get; }

        public Button SneakButton { get; }

        public Image SneakImageBright { get; }

        public Image SneakImageDark { get; }

        public Button SleepButton { get; }

        public Image SleepImageBright { get; }

        public Image SleepImageDark { get; }

        public Button StatsButton { get; }

        public Image StatsImageBright { get; }

        public Image StatsImageDark { get; }

        public Button TimeButton { get; }

        public Image TimeImageBright { get; }

        public Image TimeImageDark { get; }

        private void SideOnMouseButtonUp(object s, EventArgs e)
        {
            Hide();
        }

        private void RunOnMouseButtonUp(object s, EventArgs e)
        {
            Hide();
            userInterfaces.Current.ShowTextBox("Work In Progress");
        }

        private void RunBtnOnMouseEnter(object s, EventArgs e)
        {
            RunButton.Child = RunImageBright;
        }

        private void RunBtnOnMouseLeave(object s, EventArgs e)
        {
            RunButton.Child = RunImageDark;
        }

        private void SneakOnMouseButtonUp(object s, EventArgs e)
        {
            Hide();
            userInterfaces.Current.ShowTextBox("Work In Progress");
        }

        private void SneakBtnOnMouseEnter(object s, EventArgs e)
        {
            SneakButton.Child = SneakImageBright;
        }

        private void SneakBtnOnMouseLeave(object s, EventArgs e)
        {
            SneakButton.Child = SneakImageDark;
        }

        private void SleepOnMouseButtonUp(object s, EventArgs e)
        {
            Hide();
            userInterfaces.Current.GetDialog<Rest>().Show();
        }

        private void SleepBtnOnMouseEnter(object s, EventArgs e)
        {
            SleepButton.Child = SleepImageBright;
        }

        private void SleepBtnOnMouseLeave(object s, EventArgs e)
        {
            SleepButton.Child = SleepImageDark;
        }

        private void StatsOnMouseButtonUp(object s, EventArgs e)
        {
            Hide();
            userInterfaces.Current.ShowTextBox("Work In Progress");
        }

        private void StatsBtnOnMouseEnter(object s, EventArgs e)
        {
            StatsButton.Child = StatsImageBright;
        }

        private void StatsBtnOnMouseLeave(object s, EventArgs e)
        {
            StatsButton.Child = StatsImageDark;
        }

        private void TimeOnMouseButtonUp(object s, EventArgs e)
        {
            Hide();
            userInterfaces.Current.ShowTextBox("Work In Progress");
        }

        private void TimeBtnOnMouseEnter(object s, EventArgs e)
        {
            TimeButton.Child = TimeImageBright;
        }

        private void TimeBtnOnMouseLeave(object s, EventArgs e)
        {
            TimeButton.Child = TimeImageDark;
        }
    }
}
