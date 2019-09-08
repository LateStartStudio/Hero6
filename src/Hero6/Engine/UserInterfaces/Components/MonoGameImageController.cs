// <copyright file="MonoGameImageController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Engine.GameLoop;
using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Components
{
    public class MonoGameImageController : ImageController, IXnaGameLoop
    {
        private readonly ContentManager content;
        private readonly SpriteBatch spriteBatch;

        private Texture2D image;
        private Vector2 position;

        public MonoGameImageController(IImageModule module, string source, IServices services)
            : base(module, source, services)
        {
            content = services.Get<ContentManager>();
            spriteBatch = services.Get<SpriteBatch>();
        }

        public override int X
        {
            get { return (int)position.X; }
            set { position.X = value; }
        }

        public override int Y
        {
            get { return (int)position.Y; }
            set { position.Y = value; }
        }

        public override int Width => image?.Width ?? 0;

        public override int Height => image?.Height ?? 0;

        void IXnaGameLoop.Initialize()
        {
        }

        public void Load() => image = content.Load<Texture2D>(Source);

        public void Unload()
        {
        }

        public void Update(GameTime time)
        {
        }

        public void Draw(GameTime time)
        {
            if (IsVisible)
            {
                spriteBatch.Draw(image, position, Color.White);
            }
        }
    }
}
