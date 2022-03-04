// <copyright file="SierraVgaConfiguration.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.ModuleController.UserInterfaces;
using LateStartStudio.Hero6.UserInterfaces.SierraVga.Input.Mouse;
using LateStartStudio.Hero6.UserInterfaces.SierraVga.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LateStartStudio.Hero6.UserInterfaces.SierraVga
{
    public static class SierraVgaConfiguration
    {
        public static IHostBuilder ConfigureHero6SierraVgaGui(this IHostBuilder hostBuilder) => hostBuilder
            .ConfigureServices(services =>
            {
                services

                    // Entry point
                    .AddSingleton<IUserInterfaceModule, SierraVgaModule>()

                    // Windows
                    .AddSingleton<ExtensionBar>()
                    .AddSingleton<Rest>()
                    .AddSingleton<StatusBar>()
                    .AddSingleton<TextBox>()
                    .AddSingleton<VerbBar>()

                    // Cursors
                    .AddSingleton<Arrow>()
                    .AddSingleton<Hand>()
                    .AddSingleton<Look>()
                    .AddSingleton<Talk>()
                    .AddSingleton<Wait>()
                    .AddSingleton<Walk>();
            });
    }
}
