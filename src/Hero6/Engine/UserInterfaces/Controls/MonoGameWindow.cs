// <copyright file="MonoGameWindow.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using Assets;
    using Assets.Graphics;
    using GameLoop;
    using Microsoft.Xna.Framework;
    using Utilities.DependencyInjection;

    public class MonoGameWindow : IXnaGameLoop
    {
        private readonly IRenderer renderer;
        private readonly IAssets assets;
        private readonly Window inner;

        private Texture2D background;
        private Assets.Graphics.Rectangle destination;

        public MonoGameWindow(IServices services, IAssets assets, Window inner)
        {
            this.renderer = services.Get<IRenderer>();
            this.assets = assets;
            this.inner = inner;
        }

        public static implicit operator Window(MonoGameWindow window)
        {
            return window.inner;
        }

        public void Initialize() => inner.Child.AsXnaGameLoop()?.Initialize();

        public void Load()
        {
            this.background = assets.CreateTexture2D(1, 1);
            background.SetData(new[] { inner.Background });
            inner.Child.AsXnaGameLoop()?.Load();
            inner.Width = inner.Child.Width;
            inner.Height = inner.Child.Height;
        }

        public void Unload() => inner.Child.AsXnaGameLoop()?.Unload();

        public void Update(GameTime time)
        {
            inner.Child.X = inner.X;
            inner.Child.Y = inner.Y;
            inner.Child.AsXnaGameLoop()?.Update(time);
            this.destination = new Assets.Graphics.Rectangle(inner.X, inner.Y, inner.Width, inner.Height);
        }

        public void Draw(GameTime time)
        {
            if (!inner.IsVisible)
            {
                return;
            }

            renderer.Draw(background, destination, inner.Background);
            inner.Child.AsXnaGameLoop()?.Draw(time);
        }
    }
}
