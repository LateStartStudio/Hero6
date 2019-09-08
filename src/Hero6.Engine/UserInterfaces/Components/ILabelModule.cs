// <copyright file="ILabelModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Components
{
    using System.Drawing;

    public interface ILabelModule : IComponentModule
    {
        string Text { get; set; }

        Color Foreground { get; set; }

        TextWrapping TextWrapping { get; set; }
    }
}
