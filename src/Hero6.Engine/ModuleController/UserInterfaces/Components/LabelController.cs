// <copyright file="LabelController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Extensions;
using LateStartStudio.Hero6.Services.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Components
{
    public class LabelController : ComponentController<ILabelController, ILabelModule>, ILabelController
    {
        private readonly ContentManager content;
        private readonly SpriteBatch spriteBatch;

        private SpriteFont font;
        private Vector2 position;
        private Vector2 size;
        private string text;

        public LabelController(ILabelModule module, IServiceLocator services) : base(module, services)
        {
            content = services.Get<ContentManager>();
            spriteBatch = services.Get<SpriteBatch>();
        }

        public override int X
        {
            get { return (int)position.X; }
            set { position.X = value; }
        }

        public override int Y
        {
            get { return (int)position.Y; }
            set { position.Y = value; }
        }

        public override int Width => (int)size.X;

        public override int Height => (int)size.Y;

        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
                size = font?.MeasureString(Module.Text) ?? Vector2.One;
            }
        }

        public override void Load()
        {
            font = content.Load<SpriteFont>("Gui/Sierra Vga/Fonts/DAYROM_11.25_Regular");
            size = font.MeasureString(Module.Text);
        }

        public override void Unload()
        {
        }

        public override void Update(GameTime time)
        {
        }

        public override void Draw(GameTime time)
        {
            if (IsVisible)
            {
                spriteBatch.DrawString(font, Module.Text, position, Module.Foreground.ToMonoGame());
            }
        }
    }
}
