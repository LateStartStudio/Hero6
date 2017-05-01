// <copyright file="TopBar.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga.Windows
{
    using System.IO;

    using LateStartStudio.Hero6.Engine.Assets;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Controls;

    public class TopBar : Window
    {
        public TopBar(AssetManager assets)
            : base(assets)
        {
            this.IsVisible = true;
            this.Child = new Image(assets, $"Top Bar{Path.DirectorySeparatorChar}Background");
        }
    }
}
