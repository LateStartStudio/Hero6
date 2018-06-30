// <copyright file="MonoGameImage.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using Assets;
    using Assets.Graphics;
    using GameLoop;
    using Input;
    using Microsoft.Xna.Framework;
    using Utilities.Logger;
    using Point = Assets.Graphics.Point;

    public class MonoGameImage : Image, IXnaGameLoop
    {
        private readonly IRenderer renderer;
        private readonly ILogger logger;
        private readonly IAssets assets;

        private Texture2D image;

        public MonoGameImage(
            string source,
            IMouse mouse,
            IRenderer renderer,
            ILogger logger,
            IAssets assets,
            UserInterfaceElement parent = null)
            : base(source, mouse, parent)
        {
            this.renderer = renderer;
            this.logger = logger;
            this.assets = assets;
        }

        public void Initialize()
        {
        }

        public void Load()
        {
            image = assets.LoadTexture2D(Source);
            Width = image.Width;
            Height = image.Height;
        }

        public void Unload()
        {
        }

        public void Update(GameTime time)
        {
            if (image != null)
            {
                return;
            }

            logger.Warning($"Image {Source} was not loaded before update tick in {nameof(MonoGameImage)}");
            Load();
        }

        public void Draw(GameTime time)
        {
            renderer.Draw(image, new Point(X, Y));
        }
    }
}
