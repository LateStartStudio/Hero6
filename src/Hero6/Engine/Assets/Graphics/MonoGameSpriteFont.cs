// <copyright file="MonoGameSpriteFont.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets.Graphics
{
    using System.Text;

    using XnaSpriteFont = Microsoft.Xna.Framework.Graphics.SpriteFont;
    using XnaVector2 = Microsoft.Xna.Framework.Vector2;

    public class MonoGameSpriteFont : SpriteFont
    {
        private readonly XnaSpriteFont spriteFont;

        public MonoGameSpriteFont(XnaSpriteFont spriteFont)
        {
            this.spriteFont = spriteFont;
        }

        public override object GetSpriteFont => spriteFont;

        public override Vector2 MeasureString(string text)
        {
            XnaVector2 vector = spriteFont.MeasureString(text);

            return new Vector2(vector.X, vector.Y);
        }

        public override Vector2 MeasureString(StringBuilder text)
        {
            XnaVector2 vector = spriteFont.MeasureString(text);

            return new Vector2(vector.X, vector.Y);
        }
    }
}
