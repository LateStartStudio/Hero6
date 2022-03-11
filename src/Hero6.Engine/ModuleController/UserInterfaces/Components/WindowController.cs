// <copyright file="WindowController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.Extensions;
using LateStartStudio.Hero6.Services.ControllerRepository;
using LateStartStudio.Hero6.Services.Settings;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Components
{
    public class WindowController : ComponentController<IWindowController, IWindowModule>, IWindowController
    {
        private readonly IServiceProvider services;
        private readonly IGameSettings gameSettings;
        private readonly IControllerRepository controllerRepository;
        private readonly SpriteBatch spriteBatch;
        private readonly GraphicsDeviceManager graphicsDeviceManager;

        private Texture2D background;
        private Rectangle destination;

        public WindowController(
            IWindowModule module,
            IServiceProvider services,
            IGameSettings gameSettings,
            IControllerRepository controllerRepository,
            SpriteBatch spriteBatch,
            GraphicsDeviceManager graphicsDeviceManager) : base(module, services)
        {
            this.services = services;
            this.gameSettings = gameSettings;
            this.controllerRepository = controllerRepository;
            this.spriteBatch = spriteBatch;
            this.graphicsDeviceManager = graphicsDeviceManager;
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

        public override bool IsVisible
        {
            get
            {
                return base.IsVisible;
            }

            set
            {
                base.IsVisible = value;

                if (IsVisible && Module.IsDialog)
                {
                    X = (gameSettings.NativeWidth / 2) - (Width / 2);
                    Y = (gameSettings.NativeHeight / 2) - (Height / 2);
                }
            }
        }

        public bool PauseGame => Module.PauseGame;

        private IController ChildToController => controllerRepository[Module.Child];

        public IImageController MakeImage(IComponent parent, string source)
        {
            var image = new ImageController(new ImageModule(), source, services);
            image.PreInitialize();
            image.Module.Parent = parent;
            controllerRepository[image.Module] = image;
            return image;
        }

        public IStackPanelController MakeStackPanel(IComponent parent)
        {
            var stackPanel = new StackPanelController(new StackPanelModule(), services);
            stackPanel.PreInitialize();
            stackPanel.Module.Parent = parent;
            controllerRepository[stackPanel.Module] = stackPanel;
            return stackPanel;
        }

        public IButtonController MakeButton(IComponent parent)
        {
            var button = new ButtonController(new ButtonModule(), services);
            button.PreInitialize();
            button.Module.Parent = parent;
            controllerRepository[button.Module] = button;
            return button;
        }

        public ILabelController MakeLabel(IComponent parent, string text)
        {
            var label = new LabelController(new LabelModule(), services);
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
