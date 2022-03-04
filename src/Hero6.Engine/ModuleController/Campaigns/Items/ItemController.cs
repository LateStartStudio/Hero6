// <copyright file="ItemController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Items
{
    /// <summary>
    /// API for item controller.
    /// </summary>
    public class ItemController : GameController<IItemController, IItemModule>, IItemController
    {
        private readonly ContentManager content;
        private readonly SpriteBatch spriteBatch;

        private Texture2D sprite;
        private Vector2 position;

        /// <summary>
        /// Makes a new instance of the <see cref="ItemController"/> class.
        /// </summary>
        /// <param name="module">The module for this controller.</param>
        public ItemController(IItemModule module, IServiceProvider services) : base(module, services)
        {
            content = services.GetService<ContentManager>();
            spriteBatch = services.GetService<SpriteBatch>();
        }

        public override int Width => sprite.Width;

        public override int Height => sprite.Height;

        public override bool Interact(int x, int y, Interaction interaction)
        {
            if (Intersects(x, y))
            {
                switch (interaction)
                {
                    case Interaction.Eye:
                        Module.Look?.Invoke();
                        break;
                    case Interaction.Mouth:
                        Module.Talk?.Invoke();
                        break;
                    case Interaction.Hand:
                        Module.Grab?.Invoke();
                        break;
                    case Interaction.Move:
                    default:
                        return false;
                }

                return true;
            }

            return false;
        }

        public override void Load()
        {
            sprite = content.Load<Texture2D>(Module.Sprite);
        }

        public override void Unload()
        {
        }

        public override void Update(GameTime time)
        {
            position.X = X;
            position.Y = Y;
        }

        public override void Draw(GameTime time)
        {
            if (Module.IsVisible)
            {
                spriteBatch.Draw(sprite, position, Color.White);
            }
        }
    }
}
