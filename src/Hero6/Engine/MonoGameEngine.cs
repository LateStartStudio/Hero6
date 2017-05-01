// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MonoGameEngine.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the MonoGameEngine type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Engine
{
    using AdventureGame.Engine;
    using AdventureGame.Engine.Graphics;
    using Graphics;
    using Microsoft.Xna.Framework.Graphics;

    public class MonoGameEngine : Engine
    {
        private readonly MonoGameGraphics graphics;

        public MonoGameEngine(SpriteBatch spriteBatch)
        {
            this.graphics = new MonoGameGraphics(spriteBatch);
        }

        public override GraphicsHandler Graphics
        {
            get { return this.graphics; }
        }
    }
}
