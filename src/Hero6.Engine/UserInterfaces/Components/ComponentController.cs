// <copyright file="ComponentController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Engine.ModuleController;
using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Components
{
    public abstract class ComponentController<TController, TModule> : Controller<TController, TModule>
        where TController : ComponentController<TController, TModule>
        where TModule : IComponentModule
    {
        protected ComponentController(TModule module, IServices services)
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
