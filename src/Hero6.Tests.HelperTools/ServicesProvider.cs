// <copyright file="ServicesProvider.cs" company="Late Start Studio">
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
    using NSubstitute;

    public class ServicesProvider
    {
        protected ServicesProvider()
        {
            Mouse = Substitute.For<IMouse>();
            GameSettings = Substitute.For<IGameSettings>();
            UserSettings = Substitute.For<IUserSettings>();
            Campaigns = Substitute.For<ICampaigns>();
            Campaigns.Current = Substitute.For<CampaignModule>();
            UserInterfaces = Substitute.For<IUserInterfaces>();
            UserInterfaces.Current = Substitute.For<UserInterface>();
            UserInterfaceGenerator = new UserInterfacesGeneratorStub(Mouse);
        }

        public IMouse Mouse { get; protected set; }

        public IGameSettings GameSettings { get; protected set; }

        public IUserSettings UserSettings { get; protected set; }

        public ICampaigns Campaigns { get; protected set; }

        public IUserInterfaces UserInterfaces { get; protected set; }

        public UserInterfacesGeneratorStub UserInterfaceGenerator { get; protected set; }
    }
}
