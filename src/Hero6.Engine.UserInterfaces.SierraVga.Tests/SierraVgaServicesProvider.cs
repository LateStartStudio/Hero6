// <copyright file="SierraVgaServicesProvider.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga
{
    using Dialogs;
    using NSubstitute;
    using Tests.HelperTools;
    using Windows;

    public class SierraVgaServicesProvider : ServicesProvider
    {
        public SierraVgaServicesProvider()
        {
            UserInterfaces = MakeUserInterfaces();
            UserInterfaces.Current.Dialogs.Add(typeof(Rest), new Rest(UserInterfaces, UserInterfaceGenerator, Mouse, GameSettings));
            UserInterfaces.Current.Dialogs.Add(typeof(TextBox), new TextBox(UserInterfaceGenerator, GameSettings, Mouse));
            UserInterfaces.Current.Dialogs.Add(typeof(ExtensionBar), new ExtensionBar(UserInterfaces, UserInterfaceGenerator, Mouse, GameSettings));
            UserInterfaces.Current.Windows.Add(typeof(StatusBar), new StatusBar(UserInterfaces, UserInterfaceGenerator, Mouse, GameSettings));
            UserInterfaces.Current.Windows.Add(typeof(VerbBar), new VerbBar(UserInterfaces, UserInterfaceGenerator, Mouse, GameSettings));
            UserInterfaces.Current.Initialize();
        }

        private IUserInterfaces MakeUserInterfaces()
        {
            var userInterfaces = Substitute.For<IUserInterfaces>();
            userInterfaces.Current = new SierraVgaController(Campaigns, Mouse, GameSettings);
            return userInterfaces;
        }
    }
}
