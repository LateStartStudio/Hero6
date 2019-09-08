// <copyright file="LabelController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Services.DependencyInjection;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Components
{
    public abstract class LabelController : ComponentController<LabelController, ILabelModule>
    {
        protected LabelController(ILabelModule module, IServiceLocator services) : base(module, services)
        {
        }

        public virtual string Text { get; set; }
    }
}
