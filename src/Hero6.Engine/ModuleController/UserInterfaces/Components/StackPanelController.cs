// <copyright file="StackPanelController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;
using LateStartStudio.Hero6.Services.DependencyInjection;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Components
{
    public abstract class StackPanelController : ComponentController<IStackPanelController, IStackPanelModule>, IStackPanelController
    {
        protected StackPanelController(IStackPanelModule module, IServiceLocator services) : base(module, services)
        {
        }

        public abstract IEnumerable<IComponent> Children { get; }

        public abstract void Add(IComponent child);
    }
}
