// <copyright file="MonoGameLabel.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using System;
    using System.Drawing;
    using GameLoop;
    using Input;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Color = Microsoft.Xna.Framework.Color;

    public class MonoGameLabel : Label, IXnaGameLoop
    {
        private readonly ContentManager content;
        private readonly SpriteBatch spriteBatch;

        private SpriteFont font;
        private Vector2 position;
        private Color foreground;

        public MonoGameLabel(ContentManager content, SpriteBatch spriteBatch, IMouse mouse, UserInterfaceElement parent = null)
            : base(mouse, parent)
        {
            this.content = content;
            this.spriteBatch = spriteBatch;
        }

        public override PointF MeasureString(string text) => font.MeasureString(text).ToDotNet();

        public void Initialize()
        {
        }

        public void Load()
        {
            font = content.Load<SpriteFont>("Gui/Sierra Vga/Fonts/DAYROM_11.25_Regular");
            var size = font.MeasureString(Text);
            Width = (int)size.X;
            Height = (int)size.Y;
        }

        public void Unload()
        {
        }

        public void Update(GameTime time)
        {
            position.X = X;
            position.Y = Y;
            foreground = new Color(Foreground.R, Foreground.G, Foreground.B, Foreground.A);
        }

        public void Draw(GameTime time)
        {
            switch (TextWrapping)
            {
                case TextWrapping.None:
                    spriteBatch.DrawString(font, Text, position, foreground);
                    break;
                case TextWrapping.Wrap:
                    spriteBatch.DrawString(font, Text, position, foreground);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
