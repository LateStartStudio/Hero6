// <copyright file="MonoGameWindow.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using GameLoop;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Utilities.DependencyInjection;

    public class MonoGameWindow : IXnaGameLoop
    {
        private readonly GraphicsDeviceManager graphics;
        private readonly SpriteBatch spriteBatch;
        private readonly Window inner;

        private Texture2D background;
        private Rectangle destination;

        public MonoGameWindow(IServices services, Window inner)
        {
            graphics = services.Get<GraphicsDeviceManager>();
            spriteBatch = services.Get<SpriteBatch>();
            this.inner = inner;
        }

        public static implicit operator Window(MonoGameWindow window)
        {
            return window.inner;
        }

        public void Initialize() => inner.Child.AsXnaGameLoop()?.Initialize();

        public void Load()
        {
            background = new Texture2D(graphics.GraphicsDevice, 1, 1);
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
            this.destination = new Rectangle(inner.X, inner.Y, inner.Width, inner.Height);
        }

        public void Draw(GameTime time)
        {
            if (!inner.IsVisible)
            {
                return;
            }

            spriteBatch.Draw(background, destination, new Color(inner.Background.R, inner.Background.G, inner.Background.B, inner.Background.A));
            inner.Child.AsXnaGameLoop()?.Draw(time);
        }
    }
}
