// <copyright file="StatusBar.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.ModuleController.UserInterfaces.Components;
using LateStartStudio.Hero6.Services.Settings;
using LateStartStudio.Hero6.Services.UserInterfaces;
using LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse;
using LateStartStudio.Hero6.UserInterfaces.SierraVga.Input.Mouse;

namespace LateStartStudio.Hero6.UserInterfaces.SierraVga.Windows
{
    public class StatusBar : WindowModule
    {
        private readonly IUserInterfaces userInterfaces;
        private readonly IMouse mouse;
        private readonly IGameSettings gameSettings;

        public StatusBar(IUserInterfaces userInterfaces, IMouse mouse, IGameSettings gameSettings)
        {
            this.userInterfaces = userInterfaces;
            this.mouse = mouse;
            this.gameSettings = gameSettings;
        }

        public override string Name => "Status Bar";

        public override bool IsDialog => false;

        public override bool PauseGame => false;

        public override void Initialize()
        {
            base.Initialize();
            var background = MakeImage(this, "Gui/Sierra Vga/Status Bar/Background");
            Child = background;
            MouseEnter += OnMouseEnter;
        }

        private void OnMouseEnter(object s, EventArgs e)
        {
            // If the game is paused it's probably because some other dialog is showing or event is happening
            if (gameSettings.IsPaused)
            {
                return;
            }

            IsVisible = false;
            userInterfaces.Current.GetWindow<VerbBar>().IsVisible = true;
            mouse.SaveCursor();
            mouse.Cursor = userInterfaces.Current.GetCursor<Arrow>();
        }
    }
}
