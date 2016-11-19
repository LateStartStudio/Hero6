// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KeyboardHandler.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the KeyboardHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Input.Keyboard
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class KeyboardHandler : IXnaGameLoop
    {
        private static readonly Keys[] ValidKeys = { };

        private KeyboardState previousState;
        private KeyboardState currentState;

        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        public void Initialize()
        {
        }

        public void Load()
        {
        }

        public void Unload()
        {
        }

        public void Update(GameTime gameTime)
        {
            this.previousState = this.currentState;
            this.currentState = Keyboard.GetState();

            foreach (Keys validKey in ValidKeys)
            {
                if (this.IsKeyPressed(validKey))
                {
                    this.InvokeKeyPressed(validKey);
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }

        private bool IsKeyPressed(Keys key)
        {
            return this.currentState.IsKeyDown(key) && !this.previousState.IsKeyDown(key);
        }

        private void InvokeKeyPressed(Keys key)
        {
            if (this.KeyPressed != null)
            {
                this.KeyPressed.Invoke(this, new KeyPressedEventArgs(key));
            }
        }
    }
}
