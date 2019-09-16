// <copyright file="MonoGameButtonController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.MonoGame.GameLoop;
using LateStartStudio.Hero6.Services.ControllerRepository;
using LateStartStudio.Hero6.Services.DependencyInjection;
using Microsoft.Xna.Framework;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Components
{
    public class MonoGameButtonController : ButtonController, IXnaGameLoop
    {
        private readonly IControllerRepository controllerRepository;

        public MonoGameButtonController(IButtonModule module, IServiceLocator services) : base(module, services)
        {
            controllerRepository = services.Get<IControllerRepository>();
        }

        public override int Width => Module.Child.Width;

        public override int Height => Module.Child.Height;

        private IController ChildAsController => controllerRepository[Module.Child];

        void IXnaGameLoop.Initialize() => ChildAsController.ToXnaGameLoop().Initialize();

        public void Load() => ChildAsController.ToXnaGameLoop().Load();

        public void Unload() => ChildAsController.ToXnaGameLoop().Unload();

        public void Update(GameTime time)
        {
            ChildAsController.ToXnaGameLoop().Update(time);
            Module.Child.X = X;
            Module.Child.Y = Y;
        }

        public void Draw(GameTime time)
        {
            if (IsVisible)
            {
                ChildAsController.ToXnaGameLoop().Draw(time);
            }
        }
    }
}
