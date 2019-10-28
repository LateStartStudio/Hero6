// <copyright file="UserInterfaceModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;
using LateStartStudio.Hero6.ModuleController.UserInterfaces.Components;
using LateStartStudio.Hero6.ModuleController.UserInterfaces.Input.Mouse;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces
{
    public abstract class UserInterfaceModule : Module<IUserInterfaceController, IUserInterfaceModule>, IUserInterfaceModule
    {
        public IEnumerable<IWindowController> Windows => Controller.Windows;

        public abstract void ShowTextBox(string text);

        public IWindowModule GetWindow<T>() where T : IWindowModule => Controller.GetWindow<T>().Module;

        public ICursorModule GetCursor<T>() where T : ICursorModule => Controller.GetCursor<T>().Module;
    }
}
