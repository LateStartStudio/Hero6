// <copyright file="IUserInterfaceModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;
using LateStartStudio.Hero6.ModuleController.UserInterfaces.Components;
using LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces
{
    public interface IUserInterfaceModule : IModule
    {
        IEnumerable<WindowController> Windows { get; }

        void ShowTextBox(string text);

        IWindowModule GetWindow<T>() where T : IWindowModule;

        IEnumerable<ICursor> GenerateCursors();
    }
}
