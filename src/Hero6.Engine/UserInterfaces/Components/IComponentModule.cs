// <copyright file="IComponentModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Drawing;
using LateStartStudio.Hero6.Engine.ModuleController;

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Components
{
    public interface IComponentModule : IModule, IComponent
    {
        Color Background { get; set; }
    }
}
