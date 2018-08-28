// <copyright file="MonoGameItemController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Items
{
    using LateStartStudio.Hero6.Engine.Assets;
    using LateStartStudio.Hero6.Engine.Assets.Graphics;
    using LateStartStudio.Hero6.Engine.GameLoop;
    using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;
    using Microsoft.Xna.Framework;

    public class MonoGameItemController : ItemController, IXnaGameLoop
    {
        private readonly IRenderer renderer;
        private readonly IAssets assets;

        private Texture2D sprite;

        public MonoGameItemController(ItemModule module, IServices services, IAssets assets)
            : base(module)
        {
            renderer = services.Get<IRenderer>();
            this.assets = assets;
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
            sprite = assets.LoadTexture2D(Module.Sprite);
            Initialize();
        }

        public void Unload()
        {
        }

        public void Update(GameTime time)
        {
        }

        public void Draw(GameTime time)
        {
            if (Module.IsVisible)
            {
                renderer.Draw(sprite, new Assets.Graphics.Point(X, Y));
            }
        }
    }
}
