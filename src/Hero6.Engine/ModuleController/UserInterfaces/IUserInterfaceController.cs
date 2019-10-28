// <copyright file="IUserInterfaceController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;
using LateStartStudio.Hero6.ModuleController.UserInterfaces.Components;
using LateStartStudio.Hero6.ModuleController.UserInterfaces.Input.Mouse;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces
{
    public interface IUserInterfaceController : IController
    {
        IEnumerable<IWindowController> Windows { get; }

        IWindowController GetWindow<T>() where T : IWindowModule;

        ICursorController GetCursor<T>() where T : ICursorModule;
    }
}
