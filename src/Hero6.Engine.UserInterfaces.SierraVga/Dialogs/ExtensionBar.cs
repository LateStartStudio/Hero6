// <copyright file="ExtensionBar.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Dialogs
{
    using System;
    using System.IO;

    using LateStartStudio.Hero6.Engine.Assets;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Controls;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;

    public class ExtensionBar : Dialog
    {
        private readonly StackPanel stackPanel;

        private readonly Button leftBtn;
        private readonly Button rightBtn;
        private readonly Button runBtn;
        private readonly Button sneakBtn;
        private readonly Button sleepBtn;
        private readonly Button statsBtn;
        private readonly Button timeBtn;

        private readonly Image left;
        private readonly Image right;
        private readonly Image run;
        private readonly Image runDark;
        private readonly Image sneak;
        private readonly Image sneakDark;
        private readonly Image sleep;
        private readonly Image sleepDark;
        private readonly Image stats;
        private readonly Image statsDark;
        private readonly Image time;
        private readonly Image timeDark;

        public ExtensionBar(IAssets assets)
            : base(assets)
        {
            this.left = new Image(assets, $"Extension Bar{Path.DirectorySeparatorChar}Left");
            this.right = new Image(assets, $"Extension Bar{Path.DirectorySeparatorChar}Right");
            this.run = new Image(assets, $"Extension Bar{Path.DirectorySeparatorChar}Run Light");
            this.runDark = new Image(assets, $"Extension Bar{Path.DirectorySeparatorChar}Run Dark");
            this.sneak = new Image(assets, $"Extension Bar{Path.DirectorySeparatorChar}Sneak Light");
            this.sneakDark = new Image(assets, $"Extension Bar{Path.DirectorySeparatorChar}Sneak Dark");
            this.sleep = new Image(assets, $"Extension Bar{Path.DirectorySeparatorChar}Sleep Light");
            this.sleepDark = new Image(assets, $"Extension Bar{Path.DirectorySeparatorChar}Sleep Dark");
            this.stats = new Image(assets, $"Extension Bar{Path.DirectorySeparatorChar}Stats Light");
            this.statsDark = new Image(assets, $"Extension Bar{Path.DirectorySeparatorChar}Stats Dark");
            this.time = new Image(assets, $"Extension Bar{Path.DirectorySeparatorChar}Time Light");
            this.timeDark = new Image(assets, $"Extension Bar{Path.DirectorySeparatorChar}Time Dark");

            this.leftBtn = new Button(assets, this.left);
            this.leftBtn.MouseButtonUp += SideOnMouseButtonUp;

            this.rightBtn = new Button(assets, this.right);
            this.rightBtn.MouseButtonUp += SideOnMouseButtonUp;

            this.runBtn = new Button(assets, this.runDark);
            this.runBtn.MouseButtonUp += RunOnMouseButtonUp;
            this.runBtn.MouseEnter += RunBtnOnMouseEnter;
            this.runBtn.MouseLeave += RunBtnOnMouseLeave;

            this.sneakBtn = new Button(assets, this.sneakDark);
            this.sneakBtn.MouseButtonUp += SneakOnMouseButtonUp;
            this.sneakBtn.MouseEnter += SneakBtnOnMouseEnter;
            this.sneakBtn.MouseLeave += SneakBtnOnMouseLeave;

            this.sleepBtn = new Button(assets, this.sleepDark);
            this.sleepBtn.MouseButtonUp += SleepOnMouseButtonUp;
            this.sleepBtn.MouseEnter += SleepBtnOnMouseEnter;
            this.sleepBtn.MouseLeave += SleepBtnOnMouseLeave;

            this.statsBtn = new Button(assets, this.statsDark);
            this.statsBtn.MouseButtonUp += StatsOnMouseButtonUp;
            this.statsBtn.MouseEnter += StatsBtnOnMouseEnter;
            this.statsBtn.MouseLeave += StatsBtnOnMouseLeave;

            this.timeBtn = new Button(assets, this.timeDark);
            this.timeBtn.MouseButtonUp += TimeOnMouseButtonUp;
            this.timeBtn.MouseEnter += TimeBtnOnMouseEnter;
            this.timeBtn.MouseLeave += TimeBtnOnMouseLeave;

            this.stackPanel = new StackPanel(assets);
            this.stackPanel.Children.Add(leftBtn);
            this.stackPanel.Children.Add(runBtn);
            this.stackPanel.Children.Add(sneakBtn);
            this.stackPanel.Children.Add(sleepBtn);
            this.stackPanel.Children.Add(statsBtn);
            this.stackPanel.Children.Add(timeBtn);
            this.stackPanel.Children.Add(rightBtn);

            Child = this.stackPanel;
        }

        private void SideOnMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            Hide();
        }

        private void RunOnMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            Hide();
            SierraVgaController.TextBox.Show("Work In Progress");
        }

        private void RunBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            this.runBtn.Child = this.run;
        }

        private void RunBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            this.runBtn.Child = this.runDark;
        }

        private void SneakOnMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            Hide();
            SierraVgaController.TextBox.Show("Work In Progress");
        }

        private void SneakBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            this.sneakBtn.Child = sneak;
        }

        private void SneakBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            this.sneakBtn.Child = sneakDark;
        }

        private void SleepOnMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            Hide();
            SierraVgaController.Rest.Show();
        }

        private void SleepBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            this.sleepBtn.Child = sleep;
        }

        private void SleepBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            this.sleepBtn.Child = sleepDark;
        }

        private void StatsOnMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            Hide();
            SierraVgaController.TextBox.Show("Work In Progress");
        }

        private void StatsBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            this.statsBtn.Child = stats;
        }

        private void StatsBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            this.statsBtn.Child = statsDark;
        }

        private void TimeOnMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            Hide();
            SierraVgaController.TextBox.Show("Work In Progress");
        }

        private void TimeBtnOnMouseEnter(object sender, EventArgs eventArgs)
        {
            this.timeBtn.Child = time;
        }

        private void TimeBtnOnMouseLeave(object sender, EventArgs eventArgs)
        {
            this.timeBtn.Child = timeDark;
        }
    }
}
