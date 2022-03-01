// <copyright file="HostBuilderExtensions.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Threading;
using System.Threading.Tasks;
using LateStartStudio.Hero6.Extensions;
using LateStartStudio.Hero6.ModuleController.Campaigns;
using LateStartStudio.Hero6.ModuleController.UserInterfaces;
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

namespace LateStartStudio.Hero6.Engine.Extensions
{
    public static class HostBuilderExtensions
    {
        /// <summary>
        /// Run the game via the <see cref="IHost"/>, run this instead of <see cref="IHost.StartAsync(CancellationToken)"/>
        /// to start the game.
        /// </summary>
        public static Task RunGameAsync(this IHost host, CancellationToken cancellationToken = default)
        {
            var services = host.Services;

            // First load all game modules
            // TODO The services should probably load the modules themselves, but circular dependencies needs to be resolved
            var ui = services.GetService<MonoGameUserInterfaces>();
            var userInterfaceModules = services.GetServices<IUserInterfaceModule>();
            var campaigns = services.GetService<MonoGameCampaigns>();
            var campaignModules = services.GetServices<ICampaignModule>();
            userInterfaceModules.ForEach(m => ui.Add(m));
            campaignModules.ForEach(m => campaigns.Add(m));

            // Start the host and all related mechanics, dependency injection, logging, etc.
            // awaiting this will make the process hang around after the game had been closed, so don't
            _ = host.RunAsync(cancellationToken);

            using (var game = services.GetService<Game>())
            {
                game.Run();
            }
            // TODO This block needs a logger which is compatible with Microsoft.Logging and dumping log to file
            // which comes later
            ////#if !DEBUG
            ////            catch (Exception e)
            ////            {
            ////                logger.Error("Hero6 has crashed, logging stack trace.");
            ////                logger.Exception(e);
            ////                logger.WillDeleteLogOnDispose = false;
            ////                var p = new System.Diagnostics.Process { StartInfo = { UseShellExecute = true, FileName = logger.Filename } };
            ////                p.Start();
            ////            }
            ////#endif

            // Game is now finished so no point in keeping the host alive
            return host.StopAsync(cancellationToken);
        }

        public static IHostBuilder ConfigureHero6Engine(this IHostBuilder hostBuilder) => hostBuilder
            .ConfigureServices((context, services) =>
            {
                services

                    // MonoGame constructs
                    .AddSingleton<Game>() // Entry point
                    .AddSingleton(s => s.GetService<Game>().Content)
                    .AddSingleton(s => s.GetService<Game>().GraphicsDeviceManager)
                    .AddSingleton(s => s.GetService<Game>().SpriteBatch)

                    // Hero6 services
                    .AddSingleton<IPlatformInfo, PlatformInfo>()
                    .AddSingleton<IFileWrapper, FileWrapper>()
                    .AddSingleton<IDirectoryWrapper, DirectoryWrapper>()
                    .AddSingleton<MonoGameCampaigns>()
                    .AddSingleton<ICampaigns>(s => s.GetService<MonoGameCampaigns>())
                    .AddSingleton<IGameSettings, GameSettings>()
                    .AddSingleton<IControllerRepository, ControllerRepositoryProvider>()
                    .AddSingleton<IUserSettings, UserSettings>()
                    .AddSingleton<MonoGameUserInterfaces>()
                    .AddSingleton<IUserInterfaces>(s => s.GetService<MonoGameUserInterfaces>())
                    .AddSingleton<IMouseCore, MouseCore>()
                    .AddSingleton<IMouse, Mouse>();

                    // TODO Logging needs a new framework to support newer dotnet versions, for now we use
                    // the logger built in to Microsoft.Extensions.Hosting
                    ////.AddSingleton<ILoggerCore, LoggerCore>()
                    ////.AddSingleton<ILogger, Logger>()
            });
    }
}
