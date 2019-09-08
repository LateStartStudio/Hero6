// <copyright file="IServicesRepository.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Engine.Campaigns;
using LateStartStudio.Hero6.Engine.UserInterfaces;
using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;
using LateStartStudio.Hero6.Engine.Utilities.Settings;
using LateStartStudio.Hero6.Tests.HelperTools.Utilities;

namespace LateStartStudio.Hero6.Tests.HelperTools
{
    public interface IServicesRepository
    {
        FileWrapperStub File { get; }

        IServices Services { get; }

        IMouse Mouse { get; }

        IGameSettings GameSettings { get; }

        IUserSettings UserSettings { get; }

        ICampaigns Campaigns { get; }

        IUserInterfaces UserInterfaces { get; }
    }
}
