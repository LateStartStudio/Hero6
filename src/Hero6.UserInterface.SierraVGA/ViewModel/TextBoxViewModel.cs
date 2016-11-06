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

namespace LateStartStudio.Hero6.UserInterface.SierraVGA.ViewModel
{
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
    }
}
