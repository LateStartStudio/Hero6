// <copyright file="Hero6ServicesProvider.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Services.DotNetWrappers;
using LateStartStudio.Hero6.Services.Logger;
using LateStartStudio.Hero6.Services.PlatformInfo;
using LateStartStudio.Hero6.Services.Settings;
using LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse;
using NSubstitute;

namespace LateStartStudio.Hero6.Services
{
    public class Hero6ServicesProvider
    {
        public Hero6ServicesProvider()
        {
            File = new FileWrapperStub();
            Directory = Substitute.For<IDirectoryWrapper>();
            MouseCore = Substitute.For<IMouseCore>();
            LoggerCore = Substitute.For<ILoggerCore>();
            UserSettings = Substitute.For<IUserSettings>();
            GameSettings = Substitute.For<IGameSettings>();
            PlatformInfo = Substitute.For<IPlatformInfo>();
        }

        public FileWrapperStub File { get; }

        public IDirectoryWrapper Directory { get; }

        public IMouseCore MouseCore { get; }

        public ILoggerCore LoggerCore { get; }

        public IUserSettings UserSettings { get; }

        public IGameSettings GameSettings { get; }

        public IPlatformInfo PlatformInfo { get; }
    }
}
