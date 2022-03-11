// <copyright file="CursorController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Input.Mouse
{
    public class CursorController : Controller<ICursorController, ICursorModule>, ICursorController
    {
        private readonly IMouse mouse;
        private readonly ContentManager content;
        private readonly SpriteBatch spriteBatch;

        private Texture2D cursor;

        public CursorController(
            ICursorModule module,
            IServiceProvider services,
            IMouse mouse,
            ContentManager content,
            SpriteBatch spriteBatch) : base(module, services)
        {
            this.mouse = mouse;
            this.content = content;
            this.spriteBatch = spriteBatch;
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

        public bool Equals<T>() => typeof(T) == Module.GetType();
    }
}
