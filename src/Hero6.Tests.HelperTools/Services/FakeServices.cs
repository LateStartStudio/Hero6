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
        private readonly Lazy<FileWrapperStub> file;
        private readonly Lazy<IDirectoryWrapper> directory;
        private readonly Lazy<IMouse> mouse;
        private readonly Lazy<IMouseCore> mouseCore;
        private readonly Lazy<IGameSettings> gameSettings;
        private readonly Lazy<IUserSettings> userSettings;
        private readonly Lazy<IPlatformInfo> platformInfo;
        private readonly Lazy<ICampaigns> campaigns;
        private readonly Lazy<IUserInterfaces> userInterfaces;
        private readonly Lazy<IServiceProvider> services;

        public FakeServices()
        {
            file = new Lazy<FileWrapperStub>(() => new FileWrapperStub());
            directory = new Lazy<IDirectoryWrapper>(() => Substitute.For<IDirectoryWrapper>());
            mouse = new Lazy<IMouse>(() => Substitute.For<IMouse>());
            mouseCore = new Lazy<IMouseCore>(() => Substitute.For<IMouseCore>());
            gameSettings = new Lazy<IGameSettings>(() => Substitute.For<IGameSettings>());
            userSettings = new Lazy<IUserSettings>(() => Substitute.For<IUserSettings>());
            platformInfo = new Lazy<IPlatformInfo>(() => Substitute.For<IPlatformInfo>());

            campaigns = new Lazy<ICampaigns>(() =>
            {
                var campaigns = Substitute.For<ICampaigns>();
                var module = Substitute.For<ICampaignModule>();
                campaigns.Current.Returns(module);
                return campaigns;
            });

            userInterfaces = new Lazy<IUserInterfaces>(() =>
            {
                var userInterfaces = Substitute.For<IUserInterfaces>();
                var module = Substitute.For<IUserInterfaceModule>();
                userInterfaces.Current.Returns(module);
                return userInterfaces;
            });

            services = new Lazy<IServiceProvider>(() =>
            {
                var services = Substitute.For<IServiceProvider>();

                var resolvedFileWrapper = File;
                services.GetService(typeof(IFileWrapper)).Returns(resolvedFileWrapper);

                var resolvedDirectoryWrapper = Directory;
                services.GetService(typeof(IDirectoryWrapper)).Returns(resolvedDirectoryWrapper);

                var resolvedMouse = Mouse;
                services.GetService(typeof(IMouse)).Returns(resolvedMouse);

                var resolvedMouseCore = MouseCore;
                services.GetService(typeof(IMouseCore)).Returns(resolvedMouseCore);

                var resolvedGameSettings = GameSettings;
                services.GetService(typeof(IGameSettings)).Returns(resolvedGameSettings);

                var resolvedUserSettings = UserSettings;
                services.GetService(typeof(IUserSettings)).Returns(resolvedUserSettings);

                var resolvedPlatformIno = PlatformInfo;
                services.GetService(typeof(IPlatformInfo)).Returns(resolvedPlatformIno);

                var resolvedCampaigns = Campaigns;
                services.GetService(typeof(ICampaigns)).Returns(resolvedCampaigns);

                var resolvedUserInterfaces = UserInterfaces;
                services.GetService(typeof(IUserInterfaces)).Returns(resolvedUserInterfaces);

                return services;
            });
        }

        public FileWrapperStub File => file.Value;

        public IDirectoryWrapper Directory => directory.Value;

        public IServiceProvider Services => services.Value;

        public IMouse Mouse => mouse.Value;

        public IMouseCore MouseCore => mouseCore.Value;

        public IGameSettings GameSettings => gameSettings.Value;

        public IUserSettings UserSettings => userSettings.Value;

        public IPlatformInfo PlatformInfo => platformInfo.Value;

        public ICampaigns Campaigns => campaigns.Value;

        public IUserInterfaces UserInterfaces => userInterfaces.Value;
    }
}
