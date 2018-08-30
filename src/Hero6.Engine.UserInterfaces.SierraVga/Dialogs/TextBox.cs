// <copyright file="TextBox.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Dialogs
{
    using System;
    using System.Drawing;
    using Controls;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using Utilities.Settings;

    public class TextBox : Dialog
    {
        private readonly PointF maxSize;
        private readonly Label label;

        public TextBox(
            IUserInterfaceGenerator userInterfaceGenerator,
            IGameSettings gameSettings,
            IMouse mouse)
            : base(mouse, gameSettings)
        {
            var width = gameSettings.NativeWidth - (gameSettings.NativeWidth / 4);
            var height = gameSettings.NativeHeight - (gameSettings.NativeHeight / 4);
            maxSize = new PointF(width, height);
            label = userInterfaceGenerator.MakeLabel(this);
            label.TextWrapping = TextWrapping.Wrap;

            Child = label;
        }

        public string Text { get; set; }

        public override void Show()
        {
            var size = label.MeasureString(Text);

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
