﻿// <copyright file="IUserInterfaceModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using System.Collections.Generic;
using LateStartStudio.Hero6.Engine.ModuleController;
using LateStartStudio.Hero6.Engine.UserInterfaces.Components;
using LateStartStudio.Hero6.Engine.UserInterfaces.Input;

namespace LateStartStudio.Hero6.Engine.UserInterfaces
{
    public interface IUserInterfaceModule : IModule
    {
        IEnumerable<WindowController> Windows { get; }

        void ShowTextBox(string text);

        IWindowModule GetWindow<T>() where T : IWindowModule;

        IEnumerable<Type> GenerateWindows();

        IEnumerable<ICursor> GenerateCursors();
    }
}
