// <copyright file="MonoGameWindowController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Extensions;
using LateStartStudio.Hero6.MonoGame.GameLoop;
using LateStartStudio.Hero6.Services.ControllerRepository;
using LateStartStudio.Hero6.Services.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Components
{
    public class MonoGameWindowController : WindowController
    {
        private readonly IServiceLocator services;
        private readonly IControllerRepository controllerRepository;
        private readonly SpriteBatch spriteBatch;
        private readonly GraphicsDeviceManager graphicsDeviceManager;

        private Texture2D background;
        private Rectangle destination;

        public MonoGameWindowController(WindowModule module, IServiceLocator services) : base(module, services)
        {
            this.services = services;
            controllerRepository = services.Get<IControllerRepository>();
            spriteBatch = services.Get<SpriteBatch>();
            graphicsDeviceManager = services.Get<GraphicsDeviceManager>();
        }

        public override int X
        {
            get
            {
                return base.X;
            }

            set
            {
                base.X = value;

                if (Module.Child != null)
                {
                    Module.Child.X = value;
                }
            }
        }

        public override int Y
        {
            get
            {
                return base.Y;
            }

            set
            {
                base.Y = value;

                if (Module.Child != null)
                {
                    Module.Child.Y = value;
                }
            }
        }

        public override int Width => Module.Child?.Width ?? 0;

        public override int Height => Module.Child?.Height ?? 0;

        private IController ChildToController => controllerRepository[Module.Child];

        public override IImageController MakeImage(IComponent parent, string source)
        {
            var image = new MonoGameImageController(new ImageModule(), source, services);
            image.PreInitialize();
            image.Module.Parent = parent;
            controllerRepository[image.Module] = image;
            return image;
        }

        public override IStackPanelController MakeStackPanel(IComponent parent)
        {
            var stackPanel = new MonoGameStackPanelController(new StackPanelModule(), services);
            stackPanel.PreInitialize();
            stackPanel.Module.Parent = parent;
            controllerRepository[stackPanel.Module] = stackPanel;
            return stackPanel;
        }

        public override IButtonController MakeButton(IComponent parent)
        {
            var button = new MonoGameButtonController(new ButtonModule(), services);
            button.PreInitialize();
            button.Module.Parent = parent;
            controllerRepository[button.Module] = button;
            return button;
        }

        public override ILabelController MakeLabel(IComponent parent, string text)
        {
            var label = new MonoGameLabelController(new LabelModule(), services);
            label.PreInitialize();
            label.Module.Text = text;
            label.Module.Parent = parent;
            controllerRepository[label.Module] = label;
            return label;
        }

        public override void Load()
        {
            background = new Texture2D(graphicsDeviceManager.GraphicsDevice, 1, 1);
            background.SetData(new[] { Module.Background.ToMonoGame() });
        }

        public override void Unload()
        {
        }

        public override void Update(GameTime time)
        {
            ChildToController.ToXnaGameLoop().Update(time);
            destination = new Rectangle(X, Y, Width, Height);
        }

        public override void Draw(GameTime time)
        {
            if (IsVisible)
            {
                spriteBatch.Draw(background, destination, Module.Background.ToMonoGame());
                ChildToController.ToXnaGameLoop().Draw(time);
            }
        }
    }
}
