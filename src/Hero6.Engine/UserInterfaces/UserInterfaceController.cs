// <copyright file="UserInterfaceController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces
{
    using System.Collections.Generic;
    using LateStartStudio.Hero6.Engine.ModuleController;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Components;
    using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;

    public abstract class UserInterfaceController : Controller<UserInterfaceController, UserInterfaceModule>
    {
        protected UserInterfaceController(UserInterfaceModule module, IServices services) : base(module, services)
        {
        }

        public abstract IEnumerable<WindowController> Windows { get; }

        public abstract WindowController GetWindow<T>() where T : IWindowModule;

        public abstract void ShowTextBox(string text);
    }
}
