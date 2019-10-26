// <copyright file="UserInterfaceController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;
using LateStartStudio.Hero6.ModuleController.UserInterfaces.Components;
using LateStartStudio.Hero6.ModuleController.UserInterfaces.Input.Mouse;
using LateStartStudio.Hero6.Services.DependencyInjection;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces
{
    public abstract class UserInterfaceController : Controller<UserInterfaceController, UserInterfaceModule>
    {
        protected UserInterfaceController(UserInterfaceModule module, IServiceLocator services) : base(module, services)
        {
        }

        public abstract IEnumerable<WindowController> Windows { get; }

        public abstract WindowController GetWindow<T>() where T : IWindowModule;

        public abstract CursorController GetCursor<T>() where T : ICursorModule;
    }
}
