// <copyright file="UserInterfaceModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using System.Collections.Generic;
using LateStartStudio.Hero6.ModuleController.UserInterfaces.Components;
using LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces
{
    public abstract class UserInterfaceModule : Module<UserInterfaceController, UserInterfaceModule>, IUserInterfaceModule
    {
        public IEnumerable<WindowController> Windows => Controller.Windows;

        public abstract void ShowTextBox(string text);

        public IWindowModule GetWindow<T>() where T : IWindowModule => Controller.GetWindow<T>().Module;

        public abstract IEnumerable<Type> GenerateWindows();

        public abstract IEnumerable<ICursor> GenerateCursors();
    }
}
