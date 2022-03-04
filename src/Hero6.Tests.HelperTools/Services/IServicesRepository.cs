// <copyright file="IServicesRepository.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.Services.Campaigns;
using LateStartStudio.Hero6.Services.DotNetWrappers;
using LateStartStudio.Hero6.Services.PlatformInfo;
using LateStartStudio.Hero6.Services.Settings;
using LateStartStudio.Hero6.Services.UserInterfaces;
using LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse;

namespace LateStartStudio.Hero6.Services
{
    public interface IServicesRepository
    {
        FileWrapperStub File { get; }

        IDirectoryWrapper Directory { get; }

        IServiceProvider Services { get; }

        IMouse Mouse { get; }

        IMouseCore MouseCore { get; }

        IGameSettings GameSettings { get; }

        IUserSettings UserSettings { get; }

        IPlatformInfo PlatformInfo { get; }

        ICampaigns Campaigns { get; }

        IUserInterfaces UserInterfaces { get; }
    }
}
