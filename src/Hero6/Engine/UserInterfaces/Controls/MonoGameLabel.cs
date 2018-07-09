// <copyright file="MonoGameLabel.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using System;
    using Assets;
    using GameLoop;
    using Input;
    using Microsoft.Xna.Framework;

    public class MonoGameLabel : Label, IXnaGameLoop
    {
        private readonly IAssets assets;
        private readonly IRenderer renderer;

        public MonoGameLabel(IAssets assets, IRenderer renderer, IMouse mouse, UserInterfaceElement parent = null)
            : base(mouse, parent)
        {
            this.assets = assets;
            this.renderer = renderer;
        }

        public void Initialize()
        {
        }

        public void Load()
        {
            Font = assets.LoadSpriteFont("Fonts/Arial_11.25_Regular");
            var size = Font.MeasureString(Text);
            Width = (int)size.X;
            Height = (int)size.Y;
        }

        public void Unload()
        {
        }

        public void Update(GameTime time)
        {
        }

        public void Draw(GameTime time)
        {
            switch (TextWrapping)
            {
                case TextWrapping.None:
                    renderer.DrawString(Font, Text, new Assets.Graphics.Point(X, Y), Foreground);
                    break;
                case TextWrapping.Wrap:
                    renderer.DrawString(Font, Text, new Assets.Graphics.Point(X, Y), Foreground);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
