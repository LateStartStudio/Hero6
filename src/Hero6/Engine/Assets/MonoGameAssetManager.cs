// <copyright file="MonoGameAssetManager.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets
{
    using Graphics;
    using XnaContentManager = Microsoft.Xna.Framework.Content.ContentManager;
    using XnaSpriteFont = Microsoft.Xna.Framework.Graphics.SpriteFont;
    using XnaTexture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

    public class MonoGameAssetManager : AssetManager
    {
        private readonly XnaContentManager content;

        public MonoGameAssetManager(XnaContentManager content)
        {
            this.content = new XnaContentManager(content.ServiceProvider, content.RootDirectory);
        }

        public override string RootDirectory
        {
            get { return content.RootDirectory; }
            set { this.content.RootDirectory = value; }
        }

        public override object NativeAssetManager => content;

        public override void Dispose()
        {
            content.Dispose();
        }

        public override Texture2D CreateTexture2D(int width, int height)
        {
            return new MonoGameTexture2D(new XnaTexture2D(Game.Graphics.GraphicsDevice, width, height));
        }

        public override Texture2D LoadTexture2D(string id)
        {
            return new MonoGameTexture2D(this.content.Load<XnaTexture2D>(id));
        }

        public override SpriteFont LoadSpriteFont(string id)
        {
            return new MonoGameSpriteFont(this.content.Load<XnaSpriteFont>(id));
        }

        public override void Unload()
        {
            this.content.Unload();
        }
    }
}
