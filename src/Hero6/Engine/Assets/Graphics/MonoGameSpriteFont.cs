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
