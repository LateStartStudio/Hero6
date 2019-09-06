// <copyright file="FakeServices.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Tests.HelperTools
{
    using Engine.Campaigns;
    using Engine.UserInterfaces;
    using Engine.UserInterfaces.Input;
    using Engine.Utilities.Settings;
    using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;
    using LateStartStudio.Hero6.Engine.Utilities.Logger;
    using NSubstitute;
    using Utilities;

    public class FakeServices : IServicesRepository
    {
        private FileWrapperStub file;
        private IServices services;
        private IMouse mouse;
        private ILogger logger;
        private IGameSettings gameSettings;
        private IUserSettings userSettings;
        private ICampaigns campaigns;
        private IUserInterfaces userInterfaces;

        public FileWrapperStub File => file ?? (file = new FileWrapperStub());

        public IServices Services => services ?? (services = Substitute.For<IServices>());

        public IMouse Mouse => mouse ?? (mouse = Substitute.For<IMouse>());

        public ILogger Logger => logger ?? (logger = Substitute.For<ILogger>());

        public IGameSettings GameSettings => gameSettings ?? (gameSettings = Substitute.For<IGameSettings>());

        public IUserSettings UserSettings => userSettings ?? (userSettings = Substitute.For<IUserSettings>());

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
