// <copyright file="MonoGameSpriteFont.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets.Graphics
{
    using XnaSpriteFont = Microsoft.Xna.Framework.Graphics.SpriteFont;

    public class MonoGameSpriteFont : SpriteFont
    {
        private readonly XnaSpriteFont spriteFont;

        public MonoGameSpriteFont(XnaSpriteFont spriteFont)
        {
            this.spriteFont = spriteFont;
        }

        public override object GetSpriteFont
        {
            get { return this.spriteFont; }
        }
    }
}
