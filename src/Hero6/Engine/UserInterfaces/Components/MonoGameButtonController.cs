// <copyright file="MonoGameButtonController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Components
{
    using LateStartStudio.Hero6.Engine.GameLoop;
    using LateStartStudio.Hero6.Engine.ModuleController;
    using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;
    using Microsoft.Xna.Framework;

    public class MonoGameButtonController : ButtonController, IXnaGameLoop
    {
        private readonly IControllerRepository controllerRepository;

        public MonoGameButtonController(IButtonModule module, IServices services) : base(module, services)
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
