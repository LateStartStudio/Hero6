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

namespace LateStartStudio.Hero6.UserInterface.SierraVga.ViewModel
{
    using System;
    using AdventureGame.Engine.Graphics;
    using EmptyKeys.UserInterface;
    using EmptyKeys.UserInterface.Mvvm;

    public class TextBoxViewModel : WindowViewModel
    {
        private string text;

        public TextBoxViewModel() : base("TextBoxWindow")
        {
            this.Opacity = 1.0f;
            this.IsOnTop = true;
            this.Text = string.Empty;
        }

        public string Text
        {
            get { return this.text; }
            set { this.SetProperty(ref this.text, value); }
        }

        public void Show(string input, int nativeWidth, int nativeHeight, Vector2 scale)
        {
            Size size = FontManager.DefaultFont.MeasureString(input, 1, 1);
            int screenWidth = nativeWidth * (int)scale.X;
            int screenHeight = nativeHeight * (int)scale.Y;
            int horizontalEmptySpace = screenWidth / 8;
            int rowSize = screenWidth - (horizontalEmptySpace * 2);
            int rowCount = (int)Math.Ceiling(size.Width / rowSize);

            if (rowCount == 1)
            {
                this.Left = (screenWidth - size.Width) / 2;
                this.Top = (screenHeight - size.Height) / 2;
                this.Width = size.Width;
                this.Height = size.Height;
            }
            else
            {
                this.Left = horizontalEmptySpace;
                this.Top = (screenHeight - size.Height) / 2;
                this.Width = rowSize;
                this.Height = size.Height * rowCount;
            }

            this.Text = input;
            this.IsVisible = true;
        }

        public void Hide()
        {
            this.IsVisible = false;
            this.Text = string.Empty;
        }
    }
}
