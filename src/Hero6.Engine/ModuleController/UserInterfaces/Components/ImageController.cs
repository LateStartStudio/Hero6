// <copyright file="ImageController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Components
{
    public class ImageController : ComponentController<IImageController, IImageModule>, IImageController
    {
        private readonly ContentManager content;
        private readonly SpriteBatch spriteBatch;

        private Texture2D image;
        private Vector2 position;

        public ImageController(IImageModule module, string source, IServiceProvider services) : base(module, services)
        {
            Source = source;
            content = services.GetService<ContentManager>();
            spriteBatch = services.GetService<SpriteBatch>();
        }

        public string Source { get; }

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

        public override void Load() => image = content.Load<Texture2D>(Source);

        public override void Unload()
        {
        }

        public override void Update(GameTime time)
        {
        }

        public override void Draw(GameTime time)
        {
            if (IsVisible)
            {
                spriteBatch.Draw(image, position, Color.White);
            }
        }
    }
}
