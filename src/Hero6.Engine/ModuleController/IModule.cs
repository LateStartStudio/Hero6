﻿// <copyright file="IModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse;

namespace LateStartStudio.Hero6.ModuleController
{
    /// <summary>
    /// Interface to the module type. This is just a helper tool to define the relationship for the controller-module.
    /// For actual documentation refer to <see cref="Module{TController, TModule}"/>.
    /// </summary>
    public interface IModule
    {
        event EventHandler MouseEnter;

        event EventHandler MouseLeave;

        event EventHandler<MouseButtonInteraction> MouseButtonUp;

        string Name { get; }

        int X { get; set; }

        int Y { get; set; }

        int Width { get; }

        int Height { get; }

        bool IsVisible { get; set; }

        void PreInitialize(IController controller);

        void Initialize();
    }
}
