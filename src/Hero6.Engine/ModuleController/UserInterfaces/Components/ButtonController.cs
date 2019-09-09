// <copyright file="ButtonController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Services.DependencyInjection;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Components
{
    public abstract class ButtonController : ComponentController<ButtonController, IButtonModule>
    {
        protected ButtonController(IButtonModule module, IServiceLocator services) : base(module, services)
        {
        }
    }
}
