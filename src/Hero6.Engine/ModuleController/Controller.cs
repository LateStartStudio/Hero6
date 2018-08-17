// <copyright file="Controller.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.ModuleController
{
    public abstract class Controller<TController, TModule> : IController
        where TController : class, IController
        where TModule : Module<TController>
    {
        protected Controller(TModule module)
        {
            Module = module;
        }

        public virtual int X { get; set; }

        public virtual int Y { get; set; }

        public abstract int Width { get; }

        public abstract int Height { get; }

        public TModule Module { get; }

        public static implicit operator TModule(Controller<TController, TModule> controller)
        {
            return controller.Module;
        }

        public void PreInitialize() => Module.PreInitialize(this);

        public void Initialize() => Module.Initialize();

        public bool Intersects(int x, int y) => x >= X && x < X + Width && y >= Y && y < Y + Height;
    }
}
