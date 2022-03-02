// <copyright file="FakeServices.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.ModuleController.Campaigns;
using LateStartStudio.Hero6.ModuleController.UserInterfaces;
using LateStartStudio.Hero6.Services.Campaigns;
using LateStartStudio.Hero6.Services.DotNetWrappers;
using LateStartStudio.Hero6.Services.PlatformInfo;
using LateStartStudio.Hero6.Services.Settings;
using LateStartStudio.Hero6.Services.UserInterfaces;
using LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse;
using NSubstitute;

namespace LateStartStudio.Hero6.Services
{
    public class FakeServices : IServicesRepository
    {
        private FileWrapperStub file;
        private IDirectoryWrapper directory;
        private IServiceProvider services;
        private IMouse mouse;
        private IMouseCore mouseCore;
        private IGameSettings gameSettings;
        private IUserSettings userSettings;
        private IPlatformInfo platformInfo;
        private ICampaigns campaigns;
        private IUserInterfaces userInterfaces;

        public FileWrapperStub File => file ?? (file = new FileWrapperStub());

        public IDirectoryWrapper Directory => directory ?? (directory = Substitute.For<IDirectoryWrapper>());

        public IServiceProvider Services => services ?? (services = Substitute.For<IServiceProvider>());

        public IMouse Mouse => mouse ?? (mouse = Substitute.For<IMouse>());

        public IMouseCore MouseCore => mouseCore ?? (mouseCore = Substitute.For<IMouseCore>());

        public IGameSettings GameSettings => gameSettings ?? (gameSettings = Substitute.For<IGameSettings>());

        public IUserSettings UserSettings => userSettings ?? (userSettings = Substitute.For<IUserSettings>());

        public IPlatformInfo PlatformInfo => platformInfo ?? (platformInfo = Substitute.For<IPlatformInfo>());

        public ICampaigns Campaigns
        {
            get
            {
                if (campaigns == null)
                {
                    campaigns = Substitute.For<ICampaigns>();
                    var module = Substitute.For<ICampaignModule>();
                    campaigns.Current.Returns(module);
                }

                return campaigns;
            }
        }

        public IUserInterfaces UserInterfaces
        {
            get
            {
                if (userInterfaces == null)
                {
                    userInterfaces = Substitute.For<IUserInterfaces>();
                    var module = Substitute.For<IUserInterfaceModule>();
                    userInterfaces.Current.Returns(module);
                }

                return userInterfaces;
            }
        }
    }
}
