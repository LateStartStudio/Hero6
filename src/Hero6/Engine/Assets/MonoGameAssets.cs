// <copyright file="MonoGameAssets.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions;

namespace LateStartStudio.Hero6.Engine.Assets
{
    using Graphics;
    using Microsoft.Xna.Framework.Content;
    using XnaSpriteFont = Microsoft.Xna.Framework.Graphics.SpriteFont;
    using XnaTexture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

    public class MonoGameAssets : IAssets
    {
        private readonly ContentManager content;

        public MonoGameAssets(ContentManager content)
        {
            this.content = new ContentManager(content.ServiceProvider, content.RootDirectory);
        }

        public string Directory
        {
            get { return content.RootDirectory; }
            set { this.content.RootDirectory = value; }
        }

        public void Dispose()
        {
            content.Dispose();
        }

        public Texture2D CreateTexture2D(int width, int height)
        {
            return new MonoGameTexture2D(new XnaTexture2D(Game.Graphics.GraphicsDevice, width, height));
        }

        public Texture2D LoadTexture2D(string id)
        {
            return new MonoGameTexture2D(this.content.Load<XnaTexture2D>(id));
        }

        public SpriteFont LoadSpriteFont(string id)
        {
            return new MonoGameSpriteFont(this.content.Load<XnaSpriteFont>(id));
        }

        public WalkAreasModule LoadWalkAreas(string id)
        {
            return content.Load<WalkAreasModule>(id);
        }

        public void Unload()
        {
            this.content.Unload();
        }
    }
}
