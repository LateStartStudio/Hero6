﻿// <copyright file="TextBox.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.ModuleController.UserInterfaces.Components;
using LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse;

namespace LateStartStudio.Hero6.UserInterfaces.SierraVga.Windows
{
    public class TextBox : WindowModule
    {
        private ILabelModule label;

        public TextBox(IMouse mouse)
        {
            mouse.ButtonPress += MouseButtonLift;
        }

        public override string Name => "Text Box";

        public override bool IsDialog => true;

        public string Text
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        public override bool IsVisible
        {
            get
            {
                return base.IsVisible;
            }

            set
            {
                base.IsVisible = value;
                if (label != null && !IsVisible)
                {
                    label.Text = string.Empty;
                }
            }
        }

        public override void Initialize()
        {
            base.Initialize();
            IsVisible = false;
            Child = label = MakeLabel(this, string.Empty);
            label.TextWrapping = TextWrapping.Wrap;
        }

        private void MouseButtonLift(object sender, MouseButtonInteraction e)
        {
            IsVisible = false;
        }
    }
}
