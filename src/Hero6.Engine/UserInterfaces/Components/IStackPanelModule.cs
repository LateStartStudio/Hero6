// <copyright file="IStackPanelModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Components
{
    using System.Collections.Generic;

    public interface IStackPanelModule : IComponentModule
    {
        IEnumerable<IComponent> Children { get; }

        Orientation Orientation { get; set; }

        void Add(IComponent child);

        void Add(params IComponent[] children);
    }
}
