// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextBoxViewModel.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the TextBoxViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.UserInterfaces.SierraVga.ViewModel
{
    using System;
    using AdventureGame.Assets.Graphics;
    using EmptyKeys.UserInterface;
    using EmptyKeys.UserInterface.Mvvm;

    public class TextBoxViewModel : WindowViewModel
    {
        private readonly int nativeWidth;
        private readonly int nativeHeight;
        private readonly Vector2 scale;

        private string text;
        private Thickness padding;

        public TextBoxViewModel(int nativeWidth, int nativeHeight, Vector2 scale) : base("TextBoxWindow")
        {
            this.nativeWidth = nativeWidth;
            this.nativeHeight = nativeHeight;
            this.scale = scale;
            this.Opacity = 1.0f;
            this.IsOnTop = true;
            this.Text = string.Empty;
            this.Padding = new Thickness(1f);
        }

        public event EventHandler<EventArgs> OnShow;

        public event EventHandler<EventArgs> OnHide;

        public string Text
        {
            get { return this.text; }
            set { this.SetProperty(ref this.text, value); }
        }

        public Thickness Padding
        {
            get { return this.padding; }
            set { this.SetProperty(ref this.padding, value); }
        }

        public void Show(string input)
        {
            Size size = FontManager.DefaultFont.MeasureString(input, 1, 1);
            int screenWidth = this.nativeWidth * (int)this.scale.X;
            int screenHeight = this.nativeHeight * (int)this.scale.Y;
            int screenColumnWidth = screenWidth / 8;
            int displayAreaColumnWidth = screenWidth - (screenColumnWidth * 2);
            int rowCount = (int)Math.Ceiling(size.Width / (displayAreaColumnWidth - this.Padding.Left - this.Padding.Right));

            this.MinHeight = size.Height + this.Padding.Top + this.Padding.Bottom;
            this.MinWidth = size.Width + this.Padding.Left + this.Padding.Right;
            this.Height = size.Height * rowCount;
            this.Top = (screenHeight - this.Height) / 2;

            if (rowCount == 1)
            {
                this.Left = (screenWidth - size.Width) / 2;
                this.Width = size.Width;
            }
            else
            {
                this.Left = screenColumnWidth;
                this.Width = displayAreaColumnWidth;
            }

            this.Text = input;
            this.IsVisible = true;
            this.OnShow?.Invoke(this, EventArgs.Empty);
        }

        public void Hide()
        {
            this.IsVisible = false;
            this.Text = string.Empty;
            this.OnHide?.Invoke(this, EventArgs.Empty);
        }
    }
}
