// <copyright file="UserInterfaceHandler.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces
{
    using System.Collections.Generic;
    using Assets;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using SierraVga;
    using Game = Game;
    using MonoGameEngine = EmptyKeys.UserInterface.MonoGameEngine;
    using Vector2 = Assets.Graphics.Vector2;
    using XnaContentManager = Microsoft.Xna.Framework.Content.ContentManager;

    public class UserInterfaceHandler : IXnaGameLoop
    {
        private readonly GraphicsDevice graphicsDevice;
        private readonly IList<UserInterface> userInterfaces;

        public UserInterfaceHandler(GraphicsDevice graphicsDevice, XnaContentManager content)
        {
            this.Scale = new Vector2(Game.Transform.Scale.X, Game.Transform.Scale.Y);
            this.graphicsDevice = graphicsDevice;

            this.userInterfaces = new List<UserInterface>
            {
                new SierraVgaController(
                    (int)Game.NativeGameResolution.X,
                    (int)Game.NativeGameResolution.Y,
                    this.Scale,
                    Game.Renderer,
                    new MonoGameAssetManager(content))
            };
            this.CurrentUI = this.userInterfaces[0];
        }

        public Vector2 Scale
        {
            get; set;
        }

        public UserInterface CurrentUI
        {
            get; private set;
        }

        public void Initialize()
        {
            this.CurrentUI.UserInterfaceEngine = new MonoGameEngine(this.graphicsDevice, 320, 240);
        }

        public void Load()
        {
            this.CurrentUI.Load();
        }

        public void Unload()
        {
            this.CurrentUI.Unload();
        }

        public void Update(GameTime time)
        {
            this.CurrentUI.Update(time.TotalGameTime, time.ElapsedGameTime, time.IsRunningSlowly);
        }

        public void Draw(GameTime time, SpriteBatch spriteBatch)
        {
            this.CurrentUI.Draw(time.TotalGameTime, time.ElapsedGameTime, time.IsRunningSlowly);
        }
    }
}
