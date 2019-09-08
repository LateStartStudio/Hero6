// <copyright file="WindowTestBase.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Engine.UserInterfaces.Components;
using NSubstitute;

namespace LateStartStudio.Hero6.Tests.HelperTools
{
    public abstract class WindowTestBase<TModule> : ModuleControllerTestBase<TModule, WindowController>
        where TModule : WindowModule
    {
        protected override WindowController MakeController() => Substitute.For<WindowController>(Module, Services.Services);

        protected override void PreInitialize()
        {
            base.PreInitialize();

            Controller.MakeButton(Arg.Any<IComponent>()).Returns(r =>
            {
                var module = Substitute.For<IButtonModule>();
                var button = Substitute.For<ButtonController>(module, Services.Services);
                button.Module.Parent = (IComponent)r[0];
                button.PreInitialize();
                button.Initialize();
                return button;
            });

            Controller.MakeImage(Arg.Any<IComponent>(), Arg.Any<string>()).Returns(r =>
            {
                var module = Substitute.For<IImageModule>();
                var image = Substitute.For<ImageController>(module, (string)r[1], Services.Services);
                image.Module.Parent = (IComponent)r[0];
                image.PreInitialize();
                image.Initialize();
                return image;
            });

            Controller.MakeLabel(Arg.Any<IComponent>(), Arg.Any<string>()).Returns(r =>
            {
                var module = Substitute.For<ILabelModule>();
                var label = Substitute.For<LabelController>(module, Services.Services);
                label.Module.Parent = (IComponent)r[0];
                label.Module.Text = (string)r[1];
                label.PreInitialize();
                label.Initialize();
                return label;
            });

            Controller.MakeStackPanel(Arg.Any<IComponent>()).Returns(r =>
            {
                var module = Substitute.For<IStackPanelModule>();
                var result = Substitute.For<StackPanelController>(module, Services.Services);
                result.Module.Parent = (IComponent)r[0];
                result.PreInitialize();
                result.Initialize();
                return result;
            });
        }
    }
}
