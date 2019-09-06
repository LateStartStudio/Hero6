// <copyright file="StackPanelController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Components
{
    using System.Collections.Generic;
    using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;

    public abstract class StackPanelController : ComponentController<StackPanelController, IStackPanelModule>
    {
        protected StackPanelController(IStackPanelModule module, IServices services) : base(module, services)
        {
        }

        public abstract IEnumerable<IComponent> Children { get; }

        public abstract void Add(IComponent child);
    }
}
