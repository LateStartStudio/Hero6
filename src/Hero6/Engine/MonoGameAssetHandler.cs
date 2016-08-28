// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MonoGameAssetHandler.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the MonoGameAssetHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Engine
{
    using AdventureGame.Engine;
    using AdventureGame.Engine.Graphics;
    using Graphics;
    using Microsoft.Xna.Framework.Content;
    using XnaTexture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

    public class MonoGameAssetHandler : AssetHandler
    {
        private readonly ContentManager contentManager;

        public MonoGameAssetHandler(ContentManager contentManager)
        {
            this.contentManager = contentManager;
        }

        public override Texture2D LoadTexture2D(string id)
        {
            return new MonoGameTexture2D(this.contentManager.Load<XnaTexture2D>(id));
        }
    }
}
