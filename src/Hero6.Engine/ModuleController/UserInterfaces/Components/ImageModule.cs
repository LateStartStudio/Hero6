// <copyright file="ImageModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Components
{
    public class ImageModule : ComponentModule<IImageController, IImageModule>, IImageModule
    {
        public override string Name => "Image Module";

        public string Source => Controller.Source;
    }
}
