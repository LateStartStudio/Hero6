// <copyright file="MonoGameUserInterfaceGenerator.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces
{
    using Controls;
    using Input;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Utilities.Logger;

    public class MonoGameUserInterfaceGenerator : IUserInterfaceGenerator
    {
        private readonly IMouse mouse;
        private readonly ILogger logger;
        private readonly SpriteBatch spriteBatch;
        private readonly ContentManager content;

        public MonoGameUserInterfaceGenerator(
            IMouse mouse,
            ILogger logger,
            SpriteBatch spriteBatch,
            ContentManager content)
        {
            this.mouse = mouse;
            this.logger = logger;
            this.spriteBatch = spriteBatch;
            this.content = content;
        }

        public Label MakeLabel(UserInterfaceElement parent = null) => MakeLabel(string.Empty, parent);

        public Label MakeLabel(string text, UserInterfaceElement parent = null)
        {
            return new MonoGameLabel(content, spriteBatch, mouse, parent) { Text = text };
        }

        public Button MakeButton(UserInterfaceElement parent = null)
        {
            return new MonoGameButton(mouse, parent);
        }

        public Image MakeImage(string source, UserInterfaceElement parent = null)
        {
            return new MonoGameImage(source, mouse, logger, content, spriteBatch, parent);
        }

        public StackPanel MakeStackPanel(UserInterfaceElement parent = null)
        {
            return new MonoGameStackPanel(mouse, parent);
        }
    }
}
