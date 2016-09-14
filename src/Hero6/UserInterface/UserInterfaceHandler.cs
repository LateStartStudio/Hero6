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

namespace LateStartStudio.Hero6.UserInterface
{
    using System.Collections.Generic;
    using AdventureGame.UI;
    using EmptyKeys.UserInterface;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using SierraVGA;
    using Engine = AdventureGame.Engine.Engine;

    public class UserInterfaceHandler : IXnaGameLoop
    {
        private readonly Engine engine;
        private readonly GraphicsDevice graphicsDevice;
        private readonly IList<UserInterface> userInterfaces;

        public UserInterfaceHandler(Engine engine, GraphicsDevice graphicsDevice)
        {
            this.engine = engine;
            this.graphicsDevice = graphicsDevice;

            this.userInterfaces = new List<UserInterface>
            {
                new SierraVGAController(this.engine)
            };
            this.CurrentUI = this.userInterfaces[0];
        }

        public UserInterface CurrentUI
        {
            get; private set;
        }

        public void Initialize()
        {
            this.CurrentUI.UserInterfaceEngine = new MonoGameEngine(this.graphicsDevice, 320, 240);
        }

        public void Load(ContentManager contentManager)
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
