// <copyright file="StackPanelModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Components
{
    public class StackPanelModule : ComponentModule<IStackPanelController, IStackPanelModule>, IStackPanelModule
    {
        public override string Name => "Stack Panel";

        public IEnumerable<IComponent> Children => Controller.Children;

        public Orientation Orientation { get; set; }

        public void Add(IComponent child) => Controller.Add(child);

        public void Add(params IComponent[] children) => children.ForEach(c => Add(c));
    }
}
