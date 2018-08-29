// <copyright file="Module.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.ModuleController
{
    /// <summary>
    /// Module type. This is where we write all game logic to any game entities. Modules communicate with
    /// controllers, where we keep the engine logic.
    /// </summary>
    /// <typeparam name="TController">The controller that corresponds to the module.</typeparam>
    public abstract class Module<TController> : IModule
        where TController : class, IController
    {
        /// <summary>
        /// Gets the module name.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets or sets the x coordinate.
        /// </summary>
        public int X
        {
            get { return Controller.X; }
            set { Controller.X = value; }
        }

        /// <summary>
        /// Gets or sets the y coordinate.
        /// </summary>
        public int Y
        {
            get { return Controller.Y; }
            set { Controller.Y = value; }
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        public int Width => Controller.Width;

        /// <summary>
        /// Gets the height.
        /// </summary>
        public int Height => Controller.Height;

        /// <summary>
        /// Gets or sets a value indicating whether this module is visible.
        /// </summary>
        public bool IsVisible { get; set; } = true;

        /// <summary>
        /// Gets the controller for this module.
        /// </summary>
        internal TController Controller { get; private set; }

        /// <summary>
        /// Pre-Initialize event in the controller-module lifecycle.
        /// </summary>
        /// <param name="controller">The controller to save into this module.</param>
        internal void PreInitialize(IController controller) => Controller = controller as TController;

        /// <summary>
        /// Initialize event in the controller-module lifecycle.
        /// </summary>
        protected internal virtual void Initialize()
        {
        }
    }
}
