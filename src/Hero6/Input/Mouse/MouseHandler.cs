// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MouseHandler.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the MouseHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Input.Mouse
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class MouseHandler : IXnaGameLoop
    {
        private readonly ContentManager content;

        private MouseState previousState;
        private MouseState currentState;
        private Point position;
        private Texture2D texture;

        public MouseHandler(ContentManager content)
        {
            this.content = content;
            this.position = Vector2.Zero.ToPoint();
            this.Scale = Vector2.One;
        }

        public event EventHandler<MouseButtonUpEventArgs> MouseButtonUp;

        public Vector2 Scale
        {
            get; set;
        }

        public void Initialize()
        {
        }

        public void Load()
        {
            this.texture = this.content.Load<Texture2D>("Sprites/GUIs/Cursors/Arrow");
        }

        public void Unload()
        {
        }

        public void Update(GameTime gameTime)
        {
            this.previousState = this.currentState;
            this.currentState = Mouse.GetState();

            this.position = this.currentState.Position / this.Scale.ToPoint();

            if (this.previousState.LeftButton == ButtonState.Pressed
                && this.currentState.LeftButton != ButtonState.Pressed)
            {
                this.InvokeMouseButtonUp(MouseButton.Left);
            }
            else if (this.previousState.MiddleButton == ButtonState.Pressed
                && this.currentState.MiddleButton != ButtonState.Pressed)
            {
                this.InvokeMouseButtonUp(MouseButton.Middle);
            }
            else if (this.previousState.RightButton == ButtonState.Pressed
                     && this.currentState.RightButton != ButtonState.Pressed)
            {
                this.InvokeMouseButtonUp(MouseButton.Right);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.position.ToVector2());
        }

        private void InvokeMouseButtonUp(MouseButton mouseButton)
        {
            if (this.MouseButtonUp != null)
            {
                this.MouseButtonUp.Invoke(
                    this,
                    new MouseButtonUpEventArgs(this.position, mouseButton));
            }
        }
    }
}
