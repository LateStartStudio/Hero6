// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MonoGameSpriteFont.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the MonoGameSpriteFont type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Assets.Graphics
{
    using Microsoft.Xna.Framework.Graphics;

    public class MonoGameSpriteFont : AdventureGame.Assets.Graphics.SpriteFont
    {
        private readonly SpriteFont spriteFont;

        public MonoGameSpriteFont(SpriteFont spriteFont)
        {
            this.spriteFont = spriteFont;
        }

        public override object GetSpriteFont
        {
            get { return this.spriteFont; }
        }
    }
}
