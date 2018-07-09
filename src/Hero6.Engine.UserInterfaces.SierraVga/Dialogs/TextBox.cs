﻿// <copyright file="TextBox.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Dialogs
{
    using System;
    using Assets;
    using Assets.Graphics;
    using Controls;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using Utilities.Settings;

    public class TextBox : Dialog
    {
        private readonly Vector2 maxSize;
        private readonly Label label;

        public TextBox(IUserInterfaces userInterfaces, IGameSettings gameSettings, IRenderer renderer, IMouse mouse)
            : base(renderer, mouse, gameSettings)
        {
            maxSize.X = gameSettings.NativeWidth - (gameSettings.NativeWidth / 4);
            maxSize.Y = gameSettings.NativeHeight - (gameSettings.NativeHeight / 4);
            label = userInterfaces.Current.UserInterfaceGenerator.MakeLabel(this);
            label.TextWrapping = TextWrapping.Wrap;

            Child = label;
        }

        public string Text { get; set; }

        public override void Show()
        {
            var size = label.Font.MeasureString(Text);

            int rows;

            if (size.X > maxSize.X)
            {
                rows = (int)Math.Ceiling(size.X / maxSize.X);
                Width = (int)maxSize.X;
            }
            else
            {
                rows = 1;
                Width = (int)size.X;
            }

            Height = (int)(size.Y * rows);
            label.Width = Width;
            label.Height = Height;
            label.Text = Text;
            base.Show();
        }

        public override void Hide()
        {
            label.Text = string.Empty;
            base.Hide();
        }
    }
}
