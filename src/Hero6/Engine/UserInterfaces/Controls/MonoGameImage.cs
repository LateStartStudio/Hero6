// <copyright file="MonoGameImage.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using GameLoop;
    using Input;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Utilities.Logger;

    public class MonoGameImage : Image, IXnaGameLoop
    {
        private readonly ILogger logger;
        private readonly ContentManager content;
        private readonly SpriteBatch spriteBatch;

        private Texture2D image;
        private Vector2 location;

        public MonoGameImage(
            string source,
            IMouse mouse,
            ILogger logger,
            ContentManager content,
            SpriteBatch spriteBatch,
            UserInterfaceElement parent = null)
            : base(source, mouse, parent)
        {
            this.logger = logger;
            this.content = content;
            this.spriteBatch = spriteBatch;
        }

        public void Initialize()
        {
        }

        public void Load()
        {
            image = content.Load<Texture2D>(Source);
            Width = image.Width;
            Height = image.Height;
        }

        public void Unload()
        {
        }

        public void Update(GameTime time)
        {
            location.X = X;
            location.Y = Y;

            if (image != null)
            {
                return;
            }

            logger.Warning($"Image {Source} was not loaded before update tick in {nameof(MonoGameImage)}");
            Load();
        }

        public void Draw(GameTime time)
        {
            spriteBatch.Draw(image, location, Color.White);
        }
    }
}
