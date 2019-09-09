// <copyright file="IComponentModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Drawing;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Components
{
    public interface IComponentModule : IModule, IComponent
    {
        Color Background { get; set; }
    }
}
