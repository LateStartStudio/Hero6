// <copyright file="SierraVgaController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga
{
    using LateStartStudio.Hero6.Engine.Assets;

    public class SierraVgaController : UserInterface
    {
        public SierraVgaController(AssetManager assets)
            : base(assets)
        {
            this.Assets.RootDirectory = "Content/Gui/Sierra Vga";
        }

        public override string Name => "Sierra VGA";

        public override void ShowTextBox(string text)
        {
        }
    }
}
