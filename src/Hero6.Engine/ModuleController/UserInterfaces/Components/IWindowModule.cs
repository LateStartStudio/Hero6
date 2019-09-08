// <copyright file="IWindowModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Components
{
    public interface IWindowModule : IComponentModule, IComponentWithChild
    {
        bool IsDialog { get; }

        bool PauseGame { get; }

        IImageModule MakeImage(IComponent parent, string source);

        IStackPanelModule MakeStackPanel(IComponent parent);

        IButtonModule MakeButton(IComponent parent);

        ILabelModule MakeLabel(IComponent parent, string text);
    }
}
