// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MonoGameContentManager.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the MonoGameContentManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Engine
{
    using AdventureGame.Engine.Graphics;
    using Graphics;
    using ContentManager = AdventureGame.Engine.ContentManager;
    using XnaContentManager = Microsoft.Xna.Framework.Content.ContentManager;
    using XnaSpriteFont = Microsoft.Xna.Framework.Graphics.SpriteFont;
    using XnaTexture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

    public class MonoGameContentManager : ContentManager
    {
        private readonly XnaContentManager content;

        public MonoGameContentManager(XnaContentManager content)
        {
            this.content = new XnaContentManager(content.ServiceProvider, content.RootDirectory);
        }

        public override string RootDirectory
        {
            get { return this.content.RootDirectory; }
            set { this.content.RootDirectory = value; }
        }

        public override object NativeContentManager
        {
            get { return this.content; }
        }

        public override void Dispose()
        {
            this.content.Dispose();
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
