// <copyright file="WindowModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Components
{
    public abstract class WindowModule : ComponentModule<IWindowController, IWindowModule>, IWindowModule
    {
        public IComponent Child { get; set; }

        public abstract bool IsDialog { get; }

        public virtual bool PauseGame => true;

        public IImageModule MakeImage(IComponent parent, string source) => Controller.MakeImage(parent, source).Module;

        public IStackPanelModule MakeStackPanel(IComponent parent) => Controller.MakeStackPanel(parent).Module;

        public IButtonModule MakeButton(IComponent parent) => Controller.MakeButton(parent).Module;

        public ILabelModule MakeLabel(IComponent parent, string text) => Controller.MakeLabel(parent, text).Module;
    }
}
