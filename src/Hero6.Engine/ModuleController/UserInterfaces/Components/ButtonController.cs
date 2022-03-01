// <copyright file="ButtonController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.Services.ControllerRepository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Components
{
    public class ButtonController : ComponentController<IButtonController, IButtonModule>, IButtonController
    {
        private readonly IControllerRepository controllerRepository;

        public ButtonController(IButtonModule module, IServiceProvider services) : base(module, services)
        {
            controllerRepository = services.GetService<IControllerRepository>();
        }

        public override int Width => Module.Child.Width;

        public override int Height => Module.Child.Height;

        private IController ChildAsController => controllerRepository[Module.Child];

        public override void Initialize()
        {
            ChildAsController.ToXnaGameLoop().Initialize();
            base.Initialize();
        }

        public override void Load() => ChildAsController.ToXnaGameLoop().Load();

        public override void Unload() => ChildAsController.ToXnaGameLoop().Unload();

        public override void Update(GameTime time)
        {
            ChildAsController.ToXnaGameLoop().Update(time);
            Module.Child.X = X;
            Module.Child.Y = Y;
        }

        public override void Draw(GameTime time)
        {
            if (IsVisible)
            {
                ChildAsController.ToXnaGameLoop().Draw(time);
            }
        }
    }
}
