﻿// --------------------------------------------------------------------------------------------------------------------
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
        private MouseState previousState;
        private MouseState currentState;
        private Point position;
        private Texture2D texture;

        public event EventHandler<MouseButtonPressedEventArgs> MouseButtonPressed;

        public Vector2 Scale
        {
            get; set;
        }

        public void Initialize()
        {
            this.position = Vector2.Zero.ToPoint();
            this.Scale = Vector2.One;
        }

        public void Load(ContentManager contentManager)
        {
            this.texture = contentManager.Load<Texture2D>("Sprites/GUIs/Cursors/Arrow");
        }

        public void Unload()
        {
        }

        public void Update(GameTime gameTime)
        {
            this.previousState = this.currentState;
            this.currentState = Mouse.GetState();

            this.position = this.currentState.Position / this.Scale.ToPoint();

            if (this.previousState.LeftButton != ButtonState.Pressed
                && this.currentState.LeftButton == ButtonState.Pressed)
            {
                this.InvokeMouseButtonPressed(MouseButton.Left);
            }
            else if (this.previousState.MiddleButton != ButtonState.Pressed
                && this.currentState.MiddleButton == ButtonState.Pressed)
            {
                this.InvokeMouseButtonPressed(MouseButton.Middle);
            }
            else if (this.previousState.RightButton != ButtonState.Pressed
                     && this.currentState.RightButton == ButtonState.Pressed)
            {
                this.InvokeMouseButtonPressed(MouseButton.Right);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.position.ToVector2());
        }

        private void InvokeMouseButtonPressed(MouseButton mouseButton)
        {
            if (this.MouseButtonPressed != null)
            {
                this.MouseButtonPressed.Invoke(
                    this,
                    new MouseButtonPressedEventArgs(this.position, mouseButton));
            }
        }
    }
}
