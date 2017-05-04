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
        public ExtensionBar(AssetManager assets)
            : base(assets)
        {
            StackPanel stack = new StackPanel(assets);

            Button left = new Button(assets, new Image(assets, $"Extension Bar{Path.DirectorySeparatorChar}Left"));
            left.MouseButtonUp += SideOnMouseButtonUp;

            Button right = new Button(assets, new Image(assets, $"Extension Bar{Path.DirectorySeparatorChar}Right"));
            right.MouseButtonUp += SideOnMouseButtonUp;

            Button run = new Button(assets, new Image(assets, $"Extension Bar{Path.DirectorySeparatorChar}Run"));
            run.MouseButtonUp += RunOnMouseButtonUp;

            Button sneak = new Button(assets, new Image(assets, $"Extension Bar{Path.DirectorySeparatorChar}Sneak"));
            sneak.MouseButtonUp += SneakOnMouseButtonUp;

            Button sleep = new Button(assets, new Image(assets, $"Extension Bar{Path.DirectorySeparatorChar}Sleep"));
            sleep.MouseButtonUp += SleepOnMouseButtonUp;

            Button stats = new Button(assets, new Image(assets, $"Extension Bar{Path.DirectorySeparatorChar}Stats"));
            stats.MouseButtonUp += StatsOnMouseButtonUp;

            Button time = new Button(assets, new Image(assets, $"Extension Bar{Path.DirectorySeparatorChar}Time"));
            time.MouseButtonUp += TimeOnMouseButtonUp;

            stack.Children.Add(left);
            stack.Children.Add(run);
            stack.Children.Add(sneak);
            stack.Children.Add(sleep);
            stack.Children.Add(stats);
            stack.Children.Add(time);
            stack.Children.Add(right);

            Child = stack;
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

        private void SneakOnMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            Hide();
            SierraVgaController.TextBox.Show("Work In Progress");
        }

        private void SleepOnMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            Hide();
            SierraVgaController.TextBox.Show("Work In Progress");
        }

        private void StatsOnMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            Hide();
            SierraVgaController.TextBox.Show("Work In Progress");
        }

        private void TimeOnMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            Hide();
            SierraVgaController.TextBox.Show("Work In Progress");
        }
    }
}
