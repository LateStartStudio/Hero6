// <copyright file="UserInterfaceHandler.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces
{
    using System.Collections.Generic;

    using LateStartStudio.Hero6.Engine.Assets;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Game = Game;
    using XnaContentManager = Microsoft.Xna.Framework.Content.ContentManager;

    public class UserInterfaceHandler : IXnaGameLoop
    {
        private readonly IList<UserInterface> userInterfaces;

        public UserInterfaceHandler(XnaContentManager content)
        {
            IMouse mouse = new MonoGameMouse();

            UserInterface.Width = (int)Game.NativeGameResolution.X;
            UserInterface.Height = (int)Game.NativeGameResolution.Y;

            this.userInterfaces = new List<UserInterface>
            {
                new SierraVgaController(new MonoGameAssetManager(content), mouse)
            };
            this.CurrentUi = userInterfaces[0];
        }

        public UserInterface CurrentUi
        {
            get; private set;
        }

        public void Initialize()
        {
        }

        public void Load()
        {
            CurrentUi.Load();
        }

        public void Unload()
        {
            CurrentUi.Unload();
        }

        public void Update(GameTime time)
        {
            CurrentUi.Update(time.TotalGameTime, time.ElapsedGameTime, time.IsRunningSlowly);
        }

        public void Draw(GameTime time, SpriteBatch spriteBatch)
        {
            CurrentUi.Draw(time.TotalGameTime, time.ElapsedGameTime, time.IsRunningSlowly);
        }
    }
}
