// <copyright file="ImageController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Components
{
    using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;

    public abstract class ImageController : ComponentController<ImageController, IImageModule>
    {
        public ImageController(IImageModule module, string source, IServices services) : base(module, services)
        {
            Source = source;
        }

        public string Source { get; }
    }
}
