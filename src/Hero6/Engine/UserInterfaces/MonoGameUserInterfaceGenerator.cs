// <copyright file="MonoGameUserInterfaceGenerator.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces
{
    using Assets;
    using Controls;
    using Input;
    using Utilities.DependencyInjection;
    using Utilities.Logger;

    public class MonoGameUserInterfaceGenerator : IUserInterfaceGenerator
    {
        private readonly IAssets assets;
        private readonly IRenderer renderer;
        private readonly IMouse mouse;
        private readonly ILogger logger;

        public MonoGameUserInterfaceGenerator(IAssets assets, IServices services)
        {
            this.assets = assets;
            this.renderer = services.Get<IRenderer>();
            this.mouse = services.Get<IMouse>();
            this.logger = services.Get<ILogger>();
        }

        public Label MakeLabel(UserInterfaceElement parent = null) => MakeLabel(string.Empty, parent);

        public Label MakeLabel(string text, UserInterfaceElement parent = null)
        {
            return new MonoGameLabel(assets, renderer, mouse, parent) { Text = text };
        }

        public Button MakeButton(UserInterfaceElement parent = null)
        {
            return new MonoGameButton(mouse, parent);
        }

        public Image MakeImage(string source, UserInterfaceElement parent = null)
        {
            return new MonoGameImage(source, mouse, renderer, logger, assets, parent);
        }

        public StackPanel MakeStackPanel(UserInterfaceElement parent = null)
        {
            return new MonoGameStackPanel(mouse, parent);
        }
    }
}
