// <copyright file="ExtensionBar.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Dialogs
{
    using System;
    using System.IO;
    using Assets;
    using Controls;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using Utilities.Settings;

    public class ExtensionBar : Dialog
    {
        private readonly IUserInterfaces userInterfaces;

        public ExtensionBar(IUserInterfaces userInterfaces, IRenderer renderer, IMouse mouse, IGameSettings gameSettings)
            : base(renderer, mouse, gameSettings)
        {
            this.userInterfaces = userInterfaces;
            var stackPanel = userInterfaces.Current.UserInterfaceGenerator.MakeStackPanel(this);

            LeftButton = userInterfaces.Current.UserInterfaceGenerator.MakeButton(stackPanel);
            var left = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Extension Bar{Path.DirectorySeparatorChar}Left", LeftButton);
            LeftButton.Child = left;
            LeftButton.MouseButtonUp += SideOnMouseButtonUp;

            RightButton = userInterfaces.Current.UserInterfaceGenerator.MakeButton(stackPanel);
            var right = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Extension Bar{Path.DirectorySeparatorChar}Right", RightButton);
            RightButton.Child = right;
            RightButton.MouseButtonUp += SideOnMouseButtonUp;

            RunButton = userInterfaces.Current.UserInterfaceGenerator.MakeButton(stackPanel);
            RunImageBright = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Extension Bar{Path.DirectorySeparatorChar}Run Light", RunButton);
            RunImageDark = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Extension Bar{Path.DirectorySeparatorChar}Run Dark", RunButton);
            RunButton.Child = RunImageDark;
            RunButton.MouseButtonUp += RunOnMouseButtonUp;
            RunButton.MouseEnter += RunBtnOnMouseEnter;
            RunButton.MouseLeave += RunBtnOnMouseLeave;

            SneakButton = userInterfaces.Current.UserInterfaceGenerator.MakeButton(stackPanel);
            SneakImageBright = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Extension Bar{Path.DirectorySeparatorChar}Sneak Light", SneakButton);
            SneakImageDark = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Extension Bar{Path.DirectorySeparatorChar}Sneak Dark", SneakButton);
            SneakButton.Child = SneakImageDark;
            SneakButton.MouseButtonUp += SneakOnMouseButtonUp;
            SneakButton.MouseEnter += SneakBtnOnMouseEnter;
            SneakButton.MouseLeave += SneakBtnOnMouseLeave;

            SleepButton = userInterfaces.Current.UserInterfaceGenerator.MakeButton(stackPanel);
            SleepImageBright = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Extension Bar{Path.DirectorySeparatorChar}Sleep Light", SleepButton);
            SleepImageDark = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Extension Bar{Path.DirectorySeparatorChar}Sleep Dark", SleepButton);
            SleepButton.Child = SleepImageDark;
            SleepButton.MouseButtonUp += SleepOnMouseButtonUp;
            SleepButton.MouseEnter += SleepBtnOnMouseEnter;
            SleepButton.MouseLeave += SleepBtnOnMouseLeave;

            StatsButton = userInterfaces.Current.UserInterfaceGenerator.MakeButton(stackPanel);
            StatsImageBright = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Extension Bar{Path.DirectorySeparatorChar}Stats Light", StatsButton);
            StatsImageDark = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Extension Bar{Path.DirectorySeparatorChar}Stats Dark", StatsButton);
            StatsButton.Child = StatsImageDark;
            StatsButton.MouseButtonUp += StatsOnMouseButtonUp;
            StatsButton.MouseEnter += StatsBtnOnMouseEnter;
            StatsButton.MouseLeave += StatsBtnOnMouseLeave;

            TimeButton = userInterfaces.Current.UserInterfaceGenerator.MakeButton(stackPanel);
            TimeImageBright = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Extension Bar{Path.DirectorySeparatorChar}Time Light", TimeButton);
            TimeImageDark = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Extension Bar{Path.DirectorySeparatorChar}Time Dark", TimeButton);
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
