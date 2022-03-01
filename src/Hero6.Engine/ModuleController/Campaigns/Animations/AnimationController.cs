// <copyright file="AnimationController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Animations
{
    /// <summary>
    /// API for for animation controllers.
    /// </summary>
    public class AnimationController : GameController<IAnimationController, IAnimationModule>, IAnimationController
    {
        private readonly ContentManager content;
        private readonly SpriteBatch spriteBatch;

        private Point location;
        private int frame;
        private double elapsed;
        private Rectangle destination;
        private Rectangle source;
        private Texture2D texture;

        /// <summary>
        /// Makes an new instance of the <see cref="AnimationController"/> class.
        /// </summary>
        /// <param name="module">The module corresponding to this controller.</param>
        public AnimationController(IAnimationModule module, IServiceProvider services) : base(module, services)
        {
            content = services.GetService<ContentManager>();
            spriteBatch = services.GetService<SpriteBatch>();
            location = default;
        }

        public override int X
        {
            get { return location.X; }
            set { location.X = value - (Width / 2); }
        }

        public override int Y
        {
            get { return location.Y; }
            set { location.Y = value - Height; }
        }

        public override int Width => texture.Width / Module.Cols;

        public override int Height => texture.Height / Module.Rows;

        public override bool Interact(int x, int y, Interaction interaction) => Intersects(x, y);

        public override void Load()
        {
            texture = content.Load<Texture2D>(Module.Sprite);
        }

        public override void Unload()
        {
        }

        public override void Update(GameTime time)
        {
            elapsed += time.ElapsedGameTime.TotalSeconds;

            if (elapsed >= 1.0f / 16.0f)
            {
                frame++;
                elapsed = 0.0f;
                frame = frame >= Module.Cols * Module.Rows ? 0 : frame;
            }

            destination = new Rectangle(X, Y, Width, Height);
            var frameCol = Width * (frame % Module.Cols);
            var frameRow = Height * (frame / Module.Cols);
            source = new Rectangle(frameCol, frameRow, Width, Height);
        }

        public override void Draw(GameTime time)
        {
            spriteBatch.Draw(texture, destination, source, Color.White);
        }
    }
}
