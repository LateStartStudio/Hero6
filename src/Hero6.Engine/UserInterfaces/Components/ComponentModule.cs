// <copyright file="ComponentModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Drawing;
using LateStartStudio.Hero6.Engine.ModuleController;

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Components
{
    public abstract class ComponentModule<TController, TModule> : Module<TController, TModule>, IComponentModule
        where TController : ComponentController<TController, TModule>
        where TModule : IComponentModule
    {
        public IComponent Parent { get; set; }

        public Color Background { get; set; } = Color.FromArgb(255, 242, 242, 242);

        public override void Initialize()
        {
            base.Initialize();
            IsVisible = true;
        }
    }
}
