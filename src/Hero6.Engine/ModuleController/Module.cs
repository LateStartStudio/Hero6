// <copyright file="Module.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.ModuleController
{
    public abstract class Module<TController> : IModule
        where TController : class, IController
    {
        public abstract string Name { get; }

        public int X
        {
            get { return Controller.X; }
            set { Controller.X = value; }
        }

        public int Y
        {
            get { return Controller.Y; }
            set { Controller.Y = value; }
        }

        public int Width => Controller.Width;

        public int Height => Controller.Height;

        public bool IsVisible { get; set; } = true;

        internal TController Controller { get; private set; }

        internal void PreInitialize(IController controller) => Controller = controller as TController;

        protected internal virtual void Initialize()
        {
        }
    }
}
