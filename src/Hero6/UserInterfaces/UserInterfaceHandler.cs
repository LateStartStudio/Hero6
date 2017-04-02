// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserInterfaceHandler.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the UserInterfaceHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.UserInterfaces
{
    using System.Collections.Generic;
    using AdventureGame.UserInterfaces;
    using Engine;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using SierraVga;
    using Engine = AdventureGame.Engine.Engine;
    using MonoGameEngine = EmptyKeys.UserInterface.MonoGameEngine;
    using Vector2 = AdventureGame.Engine.Graphics.Vector2;
    using XnaContentManager = Microsoft.Xna.Framework.Content.ContentManager;

    public class UserInterfaceHandler : IXnaGameLoop
    {
        private readonly Engine engine;
        private readonly GraphicsDevice graphicsDevice;
        private readonly IList<UserInterface> userInterfaces;

        public UserInterfaceHandler(
            Engine engine,
            GraphicsDevice graphicsDevice,
            XnaContentManager content,
            int width,
            int height,
            Matrix scale)
        {
            this.Width = width;
            this.Height = height;
            this.Scale = new Vector2(scale.M11, scale.M22);
            this.engine = engine;
            this.graphicsDevice = graphicsDevice;

            this.userInterfaces = new List<UserInterface>
            {
                new SierraVgaController(
                    this.Width,
                    this.Height,
                    this.Scale,
                    this.engine,
                    new MonoGameContentManager(content))
            };
            this.CurrentUI = this.userInterfaces[0];
        }

        public int Width
        {
            get; set;
        }

        public int Height
        {
            get; set;
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

        public void Update(GameTime gameTime)
        {
            this.CurrentUI.Update(
                gameTime.TotalGameTime,
                gameTime.ElapsedGameTime,
                gameTime.IsRunningSlowly);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            this.CurrentUI.Draw(
                gameTime.TotalGameTime,
                gameTime.ElapsedGameTime,
                gameTime.IsRunningSlowly);
        }
    }
}
