// <copyright file="StackPanelModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Components
{
    using System.Collections.Generic;

    public class StackPanelModule : ComponentModule<StackPanelController, IStackPanelModule>, IStackPanelModule
    {
        public override string Name => "Stack Panel";

        public IEnumerable<IComponent> Children => Controller.Children;

        public Orientation Orientation { get; set; }

        public void Add(IComponent child) => Controller.Add(child);

        public void Add(params IComponent[] children) => children.ForEach(c => Add(c));
    }
}
