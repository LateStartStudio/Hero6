// <copyright file="TextBox.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Dialogs
{
    using System;

    using LateStartStudio.Hero6.Engine.Assets;
    using LateStartStudio.Hero6.Engine.Assets.Graphics;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Controls;

    public class TextBox : Dialog
    {
        private readonly Vector2 maxSize;
        private readonly Label label;

        public TextBox(AssetManager assets)
            : base(assets)
        {
            this.maxSize.X = UserInterface.Width - (UserInterface.Width / 4);
            this.maxSize.Y = UserInterface.Height - (UserInterface.Height / 4);
            this.label = new Label(assets)
            {
                TextWrapping = TextWrapping.Wrap
            };
            this.Child = label;
        }

        public void Show(string text)
        {
            Vector2 size = label.Font.MeasureString(text);

            int rows;

            if (size.X > maxSize.X)
            {
                rows = (int)Math.Ceiling(size.X / maxSize.X);
                this.Width = (int)maxSize.X;
            }
            else
            {
                rows = 1;
                this.Width = (int)size.X;
            }

            this.Height = (int)(size.Y * rows);
            this.label.Width = Width;
            this.label.Height = Height;
            this.label.Text = text;

            Show();
        }

        public new void Hide()
        {
            this.label.Text = string.Empty;

            base.Hide();
        }
    }
}
