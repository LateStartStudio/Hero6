// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InputHandler.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the InputHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Input
{
    using Keyboard;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Mouse;
    using TouchSurface;

    public class InputHandler : IXnaGameLoop
    {
        private Vector2 scale;

        public InputHandler(Matrix scale, ContentManager content)
        {
            this.Keyboard = new KeyboardHandler();
            this.Mouse = new MouseHandler();
            this.Touch = new TouchHandler();
            this.Scale = new Vector2(scale.M11, scale.M22);
        }

        public Vector2 Scale
        {
            get
            {
                return this.scale;
            }

            set
            {
                this.scale = value;
                this.Mouse.Scale = value;
                this.Touch.Scale = value;
            }
        }

        public KeyboardHandler Keyboard
        {
            get; private set;
        }

        public MouseHandler Mouse
        {
            get; private set;
        }

        public TouchHandler Touch
        {
            get; private set;
        }

        public void Initialize()
        {
            this.Keyboard.Initialize();
            this.Mouse.Initialize();
            this.Touch.Initialize();
        }

        public void Load()
        {
            this.Keyboard.Load();
            this.Mouse.Load();
            this.Touch.Load();
        }

        public void Unload()
        {
            this.Keyboard.Unload();
            this.Mouse.Unload();
            this.Touch.Unload();
        }

        public void Update(GameTime gameTime)
        {
            this.Keyboard.Update(gameTime);
            this.Mouse.Update(gameTime);
            this.Touch.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            this.Keyboard.Draw(gameTime, spriteBatch);
            this.Mouse.Draw(gameTime, spriteBatch);
            this.Touch.Draw(gameTime, spriteBatch);
        }
    }
}
