// <copyright file="ExtensionBar.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.Engine.UserInterfaces.Components;

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Dialogs
{
    public class ExtensionBar : WindowModule
    {
        private readonly IUserInterfaces userInterfaces;

        public ExtensionBar(IUserInterfaces userInterfaces)
        {
            this.userInterfaces = userInterfaces;
        }

        public override string Name => "Extension Bar";

        public override bool IsDialog => true;

        public IButtonModule LeftButton { get; private set; }

        public IButtonModule RightButton { get; private set; }

        public IButtonModule RunButton { get; private set; }

        public IImageModule RunImageBright { get; private set; }

        public IImageModule RunImageDark { get; private set; }

        public IButtonModule SneakButton { get; private set; }

        public IImageModule SneakImageBright { get; private set; }

        public IImageModule SneakImageDark { get; private set; }

        public IButtonModule SleepButton { get; private set; }

        public IImageModule SleepImageBright { get; private set; }

        public IImageModule SleepImageDark { get; private set; }

        public IButtonModule StatsButton { get; private set; }

        public IImageModule StatsImageBright { get; private set; }

        public IImageModule StatsImageDark { get; private set; }

        public IButtonModule TimeButton { get; private set; }

        public IImageModule TimeImageBright { get; private set; }

        public IImageModule TimeImageDark { get; private set; }

        public override void Initialize()
        {
            base.Initialize();
            IsVisible = false;

            var stackPanel = MakeStackPanel(this);

            LeftButton = MakeButton(stackPanel);
            var left = MakeImage(LeftButton, "Gui/Sierra Vga/Extension Bar/Left");
            LeftButton.Child = left;
            LeftButton.MouseButtonUp += SideOnMouseButtonUp;

            RightButton = MakeButton(stackPanel);
            var right = MakeImage(RightButton, "Gui/Sierra Vga/Extension Bar/Right");
            RightButton.Child = right;
            RightButton.MouseButtonUp += SideOnMouseButtonUp;

            RunButton = MakeButton(stackPanel);
            RunImageBright = MakeImage(RunButton, "Gui/Sierra Vga/Extension Bar/Run Light");
            RunImageDark = MakeImage(RunButton, "Gui/Sierra Vga/Extension Bar/Run Dark");
            RunButton.Child = RunImageDark;
            RunButton.MouseButtonUp += RunOnMouseButtonUp;
            RunButton.MouseEnter += RunBtnOnMouseEnter;
            RunButton.MouseLeave += RunBtnOnMouseLeave;

            SneakButton = MakeButton(stackPanel);
            SneakImageBright = MakeImage(SneakButton, "Gui/Sierra Vga/Extension Bar/Sneak Light");
            SneakImageDark = MakeImage(SneakButton, "Gui/Sierra Vga/Extension Bar/Sneak Dark");
            SneakButton.Child = SneakImageDark;
            SneakButton.MouseButtonUp += SneakOnMouseButtonUp;
            SneakButton.MouseEnter += SneakBtnOnMouseEnter;
            SneakButton.MouseLeave += SneakBtnOnMouseLeave;

            SleepButton = MakeButton(stackPanel);
            SleepImageBright = MakeImage(SleepButton, "Gui/Sierra Vga/Extension Bar/Sleep Light");
            SleepImageDark = MakeImage(SleepButton, "Gui/Sierra Vga/Extension Bar/Sleep Dark");
            SleepButton.Child = SleepImageDark;
            SleepButton.MouseButtonUp += SleepOnMouseButtonUp;
            SleepButton.MouseEnter += SleepBtnOnMouseEnter;
            SleepButton.MouseLeave += SleepBtnOnMouseLeave;

            StatsButton = MakeButton(stackPanel);
            StatsImageBright = MakeImage(StatsButton, "Gui/Sierra Vga/Extension Bar/Stats Light");
            StatsImageDark = MakeImage(StatsButton, "Gui/Sierra Vga/Extension Bar/Stats Dark");
            StatsButton.Child = StatsImageDark;
            StatsButton.MouseButtonUp += StatsOnMouseButtonUp;
            StatsButton.MouseEnter += StatsBtnOnMouseEnter;
            StatsButton.MouseLeave += StatsBtnOnMouseLeave;

            TimeButton = MakeButton(stackPanel);
            TimeImageBright = MakeImage(TimeButton, "Gui/Sierra Vga/Extension Bar/Time Light");
            TimeImageDark = MakeImage(TimeButton, "Gui/Sierra Vga/Extension Bar/Time Dark");
            TimeButton.Child = TimeImageDark;
            TimeButton.MouseButtonUp += TimeOnMouseButtonUp;
            TimeButton.MouseEnter += TimeBtnOnMouseEnter;
            TimeButton.MouseLeave += TimeBtnOnMouseLeave;

            stackPanel.Add(LeftButton);
            stackPanel.Add(RunButton);
            stackPanel.Add(SneakButton);
            stackPanel.Add(SleepButton);
            stackPanel.Add(StatsButton);
            stackPanel.Add(TimeButton);
            stackPanel.Add(RightButton);

            Child = stackPanel;
        }

        private void SideOnMouseButtonUp(object s, EventArgs e)
        {
            IsVisible = false;
        }

        private void RunOnMouseButtonUp(object s, EventArgs e)
        {
            IsVisible = false;
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
            IsVisible = false;
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
            IsVisible = false;
            userInterfaces.Current.GetWindow<Rest>().IsVisible = true;
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
            IsVisible = false;
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
            IsVisible = false;
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
