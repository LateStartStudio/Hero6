// <copyright file="UserInterfacesGeneratorStub.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Tests.HelperTools
{
    using Engine.Assets.Graphics;
    using Engine.UserInterfaces;
    using Engine.UserInterfaces.Controls;
    using Engine.UserInterfaces.Input;
    using NSubstitute;

    public class UserInterfacesGeneratorStub : IUserInterfaceGenerator
    {
        private readonly IMouse mouse;

        public UserInterfacesGeneratorStub(IMouse mouse)
        {
            this.mouse = mouse;
        }

        public Label MakeLabel(UserInterfaceElement parent = null) => MakeLabel(string.Empty, parent);

        public Label MakeLabel(string text, UserInterfaceElement parent = null)
        {
            var label = Substitute.For<Label>(mouse, parent);
            label.Text = text;
            label.Font = Substitute.For<SpriteFont>();
            return label;
        }

        public Button MakeButton(UserInterfaceElement parent = null)
        {
            return Substitute.For<Button>(mouse, parent);
        }

        public Image MakeImage(string source, UserInterfaceElement parent = null)
        {
            return Substitute.For<Image>(source, mouse, parent);
        }

        public StackPanel MakeStackPanel(UserInterfaceElement parent = null)
        {
            return Substitute.For<StackPanel>(mouse, parent);
        }
    }
}
