// <copyright file="IController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.ModuleController
{
    using System;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;

    /// <summary>
    /// Interface to the controller type. This is just a helper tool to define the relationship for the
    /// controller-module. For the actual documentation refer to the <see cref="Controller{TController,TModule}"/>.
    /// </summary>
    public interface IController
    {
        event EventHandler MouseEnter;

        event EventHandler MouseLeave;

        event EventHandler<MouseButtonInteraction> MouseButtonUp;

        /// <summary>
        /// Gets or sets the x coordinate.
        /// </summary>
        int X { get; set; }

        /// <summary>
        /// Gets or sets the y coordinate.
        /// </summary>
        int Y { get; set; }

        /// <summary>
        /// Gets the width.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Gets the height.
        /// </summary>
        int Height { get; }

        bool IsVisible { get; set; }

        /// <summary>
        /// The pre initialize event.
        /// </summary>
        void PreInitialize();

        /// <summary>
        /// The initialize event.
        /// </summary>
        void Initialize();

        void InvokeMouseEnter();

        void InvokeMouseLeave();

        void InvokeMouseButtonUp(MouseButtonInteraction e);
    }
}
