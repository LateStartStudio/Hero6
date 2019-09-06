// <copyright file="IComponent.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Components
{
    using LateStartStudio.Hero6.Engine.ModuleController;

    public interface IComponent : IModule
    {
        IComponent Parent { get; set; }
    }
}
