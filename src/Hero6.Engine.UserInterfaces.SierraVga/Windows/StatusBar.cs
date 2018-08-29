// <copyright file="StatusBar.cs" company="Late Start Studio">
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
    using Input;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using LateStartStudio.Hero6.Engine.Utilities.Settings;

    public class StatusBar : Window
    {
        private readonly IUserInterfaces userInterfaces;
        private readonly IMouse mouse;
        private readonly IGameSettings gameSettings;

        public StatusBar(
            IUserInterfaces userInterfaces,
            IUserInterfaceGenerator userInterfaceGenerator,
            IMouse mouse,
            IGameSettings gameSettings)
            : base(mouse)
        {
            this.userInterfaces = userInterfaces;
            this.mouse = mouse;
            this.gameSettings = gameSettings;
            var separator = Path.DirectorySeparatorChar;
            Child = userInterfaceGenerator.MakeImage($"Gui{separator}Sierra Vga{separator}Status Bar{separator}Background", this);
            MouseEnter += OnMouseEnter;
        }

        private void OnMouseEnter(object s, EventArgs e)
        {
            if (userInterfaces.Current.Dialogs.Any(d => d.Value.IsVisible))
            {
                return;
            }

            userInterfaces.Current.GetWindow<StatusBar>().IsVisible = false;
            userInterfaces.Current.GetWindow<VerbBar>().IsVisible = true;
            mouse.SaveCursor();
            mouse.Cursor = Cursor.Arrow;
            gameSettings.IsPaused = true;
        }
    }
}
