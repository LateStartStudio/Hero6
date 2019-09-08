// <copyright file="LabelModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Drawing;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Components
{
    public class LabelModule : ComponentModule<LabelController, ILabelModule>, ILabelModule
    {
        public override string Name => "Label Module";

        public string Text
        {
            get { return Controller.Text; }
            set { Controller.Text = value; }
        }

        public Color Foreground { get; set; } = Color.Black;

        public TextWrapping TextWrapping { get; set; }
    }
}
