// <copyright file="Program.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using System.Threading.Tasks;
using Hero6.Engine.Extensions;
using LateStartStudio.Hero6.Campaigns.RitesOfPassage;
using LateStartStudio.Hero6.UserInterfaces.SierraVga;
using Microsoft.Extensions.Hosting;

namespace LateStartStudio.Hero6
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureHero6Engine()
            .ConfigureHero6RitesOfPassage()
            .ConfigureHero6SierraVgaGui();
    }
}
