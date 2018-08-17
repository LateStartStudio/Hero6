// <copyright file="MonoGameSpriteSheetController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Animations
{
    using LateStartStudio.Hero6.Engine.Assets;
    using LateStartStudio.Hero6.Engine.Assets.Graphics;
    using LateStartStudio.Hero6.Engine.GameLoop;
    using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;
    using Microsoft.Xna.Framework;

    public class MonoGameAnimationController : AnimationController, IXnaGameLoop
    {
        private readonly IRenderer renderer;
        private readonly IAssets assets;

        private Assets.Graphics.Point location;
        private int frame;
        private double elapsed;
        private Assets.Graphics.Rectangle destination;
        private Assets.Graphics.Rectangle source;
        private Texture2D texture;

        public MonoGameAnimationController(AnimationModule module, IServices services, IAssets assets)
            : base(module)
        {
            renderer = services.Get<IRenderer>();
            this.assets = assets;
            location = default(Assets.Graphics.Point);
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

        void IXnaGameLoop.Initialize()
        {
        }

        public void Load()
        {
            texture = assets.LoadTexture2D(Module.Sprite);
            Initialize();
        }

        public void Unload()
        {
        }

        public void Update(GameTime time)
        {
            elapsed += time.ElapsedGameTime.TotalSeconds;

            if (elapsed >= 1.0f / 16.0f)
            {
                frame++;
                elapsed = 0.0f;
                frame = frame >= Module.Cols * Module.Rows ? 0 : frame;
            }

            destination = new Assets.Graphics.Rectangle(X, Y, Width, Height);
            var frameCol = Width * (frame % Module.Cols);
            var frameRow = Height * (frame / Module.Cols);
            source = new Assets.Graphics.Rectangle(frameCol, frameRow, Width, Height);
        }

        public void Draw(GameTime time)
        {
            renderer.Draw(texture, destination, source, Assets.Graphics.Color.White);
        }
    }
}
