// <copyright file="WindowController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;
using LateStartStudio.Hero6.Engine.Utilities.Settings;

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Components
{
    public abstract class WindowController : ComponentController<WindowController, IWindowModule>
    {
        private readonly IGameSettings gameSettings;

        protected WindowController(IWindowModule module, IServices services) : base(module, services)
        {
            gameSettings = services.Get<IGameSettings>();
        }

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

        public abstract ImageController MakeImage(IComponent parent, string source);

        public abstract StackPanelController MakeStackPanel(IComponent parent);

        public abstract ButtonController MakeButton(IComponent parent);

        public abstract LabelController MakeLabel(IComponent parent, string text);
    }
}
