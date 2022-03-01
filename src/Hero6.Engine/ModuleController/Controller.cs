// <copyright file="Controller.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using LateStartStudio.Hero6.MonoGame.GameLoop;
using LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;

namespace LateStartStudio.Hero6.ModuleController
{
    /// <summary>
    /// Controller type. This is where we write all engine logic to any game entities. Controllers communicate with
    /// modules, where we keep the game logic.
    /// </summary>
    /// <typeparam name="TController">The controller that corresponds to the module.</typeparam>
    /// <typeparam name="TModule">The module that corresponds to the controller.</typeparam>
    public abstract class Controller<TController, TModule> : IController, IXnaGameLoop
        where TController : IController
        where TModule : IModule
    {
        private bool mouseOverOnPreviousFrame = false;
        private bool mouseOverOnThisFrame = true;

        /// <summary>
        /// Makes a new <see cref="Controller{TController,TModule}"/> instance.
        /// </summary>
        /// <param name="module">The module to this controller.</param>
        protected Controller(TModule module, IServiceProvider services)
        {
            Module = module;
            var mouse = services.GetService<IMouse>();
            mouse.Move += MouseMove;
            mouse.ButtonLift += MouseButtonLift;
        }

        public event EventHandler MouseEnter;

        public event EventHandler MouseLeave;

        public event EventHandler<MouseButtonInteraction> MouseButtonUp;

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

        public virtual bool IsVisible { get; set; } = true;

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
        public virtual void Initialize() => Module.Initialize();

        void IXnaGameLoop.Initialize() => Initialize();

        public abstract void Load();

        public abstract void Unload();

        public abstract void Update(GameTime time);

        public abstract void Draw(GameTime time);

        /// <summary>
        /// Checks if the coordinates intersects with this controller.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>True if it intersects. False if not.</returns>
        public bool Intersects(int x, int y) => x >= X && x < X + Width && y >= Y && y < Y + Height;

        public void InvokeMouseEnter() => MouseEnter?.Invoke(this, EventArgs.Empty);

        public void InvokeMouseLeave() => MouseLeave?.Invoke(this, EventArgs.Empty);

        public void InvokeMouseButtonUp(MouseButtonInteraction e) => MouseButtonUp?.Invoke(this, e);

        public override string ToString() => $"Controller: {Module.Name}";

        protected IEnumerable<Type> FindModules<T>() where T : IModule =>
            Module.GetType().Assembly.GetTypes().Where(t => t.BaseType == typeof(T));

        private void MouseMove(object sender, MouseMove e)
        {
            if (IsVisible)
            {
                mouseOverOnPreviousFrame = mouseOverOnThisFrame;
                mouseOverOnThisFrame = Intersects(e.X, e.Y);

                if (mouseOverOnThisFrame && !mouseOverOnPreviousFrame)
                {
                    InvokeMouseEnter();
                }
                else if (!mouseOverOnThisFrame && mouseOverOnPreviousFrame)
                {
                    InvokeMouseLeave();
                }
            }
        }

        private void MouseButtonLift(object sender, MouseButtonInteraction e)
        {
            if (IsVisible && Intersects(e.X, e.Y))
            {
                InvokeMouseButtonUp(e);
            }
        }
    }
}
