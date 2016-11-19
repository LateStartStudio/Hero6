// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IXnaGameLoop.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the IXnaGameLoop type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IXnaGameLoop
    {
        void Initialize();

        void Load();

        void Unload();

        void Update(GameTime gameTime);

        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
