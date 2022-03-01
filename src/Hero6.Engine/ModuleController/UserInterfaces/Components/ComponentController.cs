// <copyright file="ComponentController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Components
{
    public abstract class ComponentController<TController, TModule> : Controller<TController, TModule>
        where TController : IController
        where TModule : IComponentModule
    {
        protected ComponentController(TModule module, IServiceProvider services)
            : base(module, services)
        {
        }

        public override bool IsVisible
        {
            get
            {
                return base.IsVisible && (Module.Parent?.IsVisible ?? true);
            }

            set
            {
                base.IsVisible = value;
            }
        }
    }
}
