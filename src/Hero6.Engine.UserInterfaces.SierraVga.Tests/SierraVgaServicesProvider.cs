// <copyright file="SierraVgaServicesProvider.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga
{
    using Assets;
    using Campaigns;
    using Dialogs;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using NSubstitute;
    using Utilities.Settings;
    using Windows;

    public class SierraVgaServicesProvider
    {
        public SierraVgaServicesProvider()
        {
            Mouse = Substitute.For<IMouse>();
            GameSettings = Substitute.For<IGameSettings>();
            Renderer = Substitute.For<IRenderer>();
            Campaigns = Substitute.For<ICampaigns>();
            UserInterfaces = MakeUserInterfaces();
            UserInterfaces.Current.Dialogs.Add(typeof(Rest), new Rest(UserInterfaces, Renderer, Mouse, GameSettings));
            UserInterfaces.Current.Dialogs.Add(typeof(TextBox), new TextBox(UserInterfaces, GameSettings, Renderer, Mouse));
            UserInterfaces.Current.Dialogs.Add(typeof(ExtensionBar), new ExtensionBar(UserInterfaces, Renderer, Mouse, GameSettings));
            UserInterfaces.Current.Windows.Add(typeof(StatusBar), new StatusBar(UserInterfaces, Renderer, Mouse));
            UserInterfaces.Current.Windows.Add(typeof(VerbBar), new VerbBar(UserInterfaces, Renderer, Mouse));
        }

        public IMouse Mouse { get; }

        public IGameSettings GameSettings { get; }

        public IRenderer Renderer { get; }

        public ICampaigns Campaigns { get; }

        public IUserInterfaces UserInterfaces { get; }

        private IUserInterfaces MakeUserInterfaces()
        {
            var userInterfaces = Substitute.For<IUserInterfaces>();
            userInterfaces.Current = new SierraVgaController(Campaigns, Mouse, Renderer, new UserInterfacesGeneratorStub(Mouse));
            return userInterfaces;
        }
    }
}
