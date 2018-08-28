// <copyright file="Controller.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.ModuleController
{
    /// <summary>
    /// Controller type. This is where we write all engine logic to any game entities. Controllers communicate with
    /// modules, where we keep the game logic.
    /// </summary>
    /// <typeparam name="TController">The controller that corresponds to the module.</typeparam>
    /// <typeparam name="TModule">The module that corresponds to the controller.</typeparam>
    public abstract class Controller<TController, TModule> : IController
        where TController : class, IController
        where TModule : Module<TController>
    {
        /// <summary>
        /// Makes a new <see cref="Controller{TController,TModule}"/> instance.
        /// </summary>
        /// <param name="module">The module to this controller.</param>
        protected Controller(TModule module)
        {
            Module = module;
        }

        /// <summary>
        /// Gets or sets the x coordinate.
        /// </summary>
        public virtual int X { get; set; }

        /// <summary>
        /// Gets or sets the y coordinate.
        /// </summary>
        public virtual int Y { get; set; }

        /// <summary>
        /// Gets the width.
        /// </summary>
        public abstract int Width { get; }

        /// <summary>
        /// Gets the height.
        /// </summary>
        public abstract int Height { get; }

        /// <summary>
        /// Gets the module for this controller.
        /// </summary>
        public TModule Module { get; }

        /// <summary>
        /// Implicit conversion to the module corresponding to this controller. To save time since we get the module
        /// from the controller often.
        /// </summary>
        /// <param name="controller">The controller to convert from.</param>
        public static implicit operator TModule(Controller<TController, TModule> controller)
        {
            return controller.Module;
        }

        /// <summary>
        /// Pre-Initialize event in the controller-module lifecycle.
        /// </summary>
        public void PreInitialize() => Module.PreInitialize(this);

        /// <summary>
        /// Initialize event in the controller-module lifecycle.
        /// </summary>
        public void Initialize() => Module.Initialize();

        /// <summary>
        /// Checks if the coordinates intersects with this controller.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>True if it intersects. False if not.</returns>
        public bool Intersects(int x, int y) => x >= X && x < X + Width && y >= Y && y < Y + Height;
    }
}
