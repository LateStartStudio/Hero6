// <copyright file="MonoGameCursorController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.MonoGame.GameLoop;
using LateStartStudio.Hero6.Services.DependencyInjection;
using LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Input.Mouse
{
    public class MonoGameCursorController : CursorController
    {
        private readonly ContentManager content;
        private readonly SpriteBatch spriteBatch;
        private readonly IMouse mouse;

        private Texture2D cursor;

        public MonoGameCursorController(CursorModule module, IServiceLocator services) : base(module, services)
        {
            content = services.Get<ContentManager>();
            spriteBatch = services.Get<SpriteBatch>();
            mouse = services.Get<IMouse>();
        }

        public override int Width => cursor.Width;

        public override int Height => cursor.Height;

        public override void Load() => cursor = content.Load<Texture2D>(Module.Source);

        public override void Unload()
        {
        }

        public override void Update(GameTime time)
        {
            X = mouse.X;
            Y = mouse.Y;
        }

        public override void Draw(GameTime time) => spriteBatch.Draw(cursor, new Vector2(X, Y), Color.White);
    }
}
