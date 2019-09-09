// <copyright file="IStackPanelModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Components
{
    public interface IStackPanelModule : IComponentModule
    {
        IEnumerable<IComponent> Children { get; }

        Orientation Orientation { get; set; }

        void Add(IComponent child);

        void Add(params IComponent[] children);
    }
}
