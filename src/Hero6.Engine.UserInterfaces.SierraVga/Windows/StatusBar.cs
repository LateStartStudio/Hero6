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
    using Assets;
    using Controls;
    using Input;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;

    public class StatusBar : Window
    {
        private readonly IUserInterfaces userInterfaces;
        private readonly IRenderer renderer;
        private readonly IMouse mouse;

        public StatusBar(IUserInterfaces userInterfaces, IRenderer renderer, IMouse mouse)
            : base(mouse)
        {
            this.userInterfaces = userInterfaces;
            this.renderer = renderer;
            this.mouse = mouse;
            Child = userInterfaces.Current.UserInterfaceGenerator.MakeImage($"Status Bar{Path.DirectorySeparatorChar}Background", this);
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
            renderer.IsPaused = true;
        }
    }
}
