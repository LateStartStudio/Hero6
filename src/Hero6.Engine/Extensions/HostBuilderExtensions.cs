// <copyright file="HostBuilderExtensions.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.MonoGame;
using LateStartStudio.Hero6.Services.Campaigns;
using LateStartStudio.Hero6.Services.ControllerRepository;
using LateStartStudio.Hero6.Services.DotNetWrappers;
using LateStartStudio.Hero6.Services.PlatformInfo;
using LateStartStudio.Hero6.Services.Settings;
using LateStartStudio.Hero6.Services.UserInterfaces;
using LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hero6.Engine.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigureHero6Engine(this IHostBuilder hostBuilder) => hostBuilder
            .ConfigureServices((context, services) =>
            {
                services

                    // MonoGame constructs
                    .AddSingleton<Game>()
                    .AddSingleton(s => s.GetService<Game>().Content)
                    .AddSingleton(s => s.GetService<Game>().GraphicsDeviceManager)
                    .AddSingleton(s => s.GetService<Game>().SpriteBatch)
                    .AddHostedService(s => s.GetService<Game>())

                    // Hero6 services
                    .AddSingleton<IPlatformInfo, PlatformInfo>()
                    .AddSingleton<IFileWrapper, FileWrapper>()
                    .AddSingleton<IDirectoryWrapper, DirectoryWrapper>()
                    .AddSingleton<ICampaigns, MonoGameCampaigns>()
                    .AddSingleton<IGameSettings, GameSettings>()
                    .AddSingleton<IControllerRepository, ControllerRepositoryProvider>()
                    .AddSingleton<IUserSettings, UserSettings>()
                    .AddSingleton<IUserInterfaces, MonoGameUserInterfaces>()
                    .AddSingleton<IMouseCore, MouseCore>()
                    .AddSingleton<IMouse, Mouse>();

                    // TODO Logging needs a new framework to support newer dotnet versions, for now we use
                    // the logger built in to Microsoft.Extensions.Hosting
                    ////.AddSingleton<ILoggerCore, LoggerCore>()
                    ////.AddSingleton<ILogger, Logger>()
            });
    }
}
