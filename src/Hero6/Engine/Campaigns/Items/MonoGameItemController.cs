// <copyright file="MonoGameItemController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Items
{
    using LateStartStudio.Hero6.Engine.GameLoop;
    using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class MonoGameItemController : ItemController, IXnaGameLoop
    {
        private readonly ContentManager content;
        private readonly SpriteBatch spriteBatch;

        private Texture2D sprite;
        private Vector2 position;

        public MonoGameItemController(ItemModule module, IServices services)
            : base(module)
        {
            content = services.Get<ContentManager>();
            spriteBatch = services.Get<SpriteBatch>();
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

        void IXnaGameLoop.Initialize()
        {
        }

        public void Load()
        {
            sprite = content.Load<Texture2D>(Module.Sprite);
            Initialize();
        }

        public void Unload()
        {
        }

        public void Update(GameTime time)
        {
            position.X = X;
            position.Y = Y;
        }

        public void Draw(GameTime time)
        {
            if (Module.IsVisible)
            {
                spriteBatch.Draw(sprite, position, Color.White);
            }
        }
    }
}
