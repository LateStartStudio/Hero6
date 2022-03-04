// <copyright file="RitesOfPassageConfiguration.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Campaigns.RitesOfPassage.Animations.Characters.Hero.Idle;
using LateStartStudio.Hero6.Campaigns.RitesOfPassage.Animations.Characters.Hero.Walk;
using LateStartStudio.Hero6.Campaigns.RitesOfPassage.Animations.Characters.Llewella.Idle;
using LateStartStudio.Hero6.Campaigns.RitesOfPassage.Characters;
using LateStartStudio.Hero6.Campaigns.RitesOfPassage.Rooms.Albion;
using LateStartStudio.Hero6.ModuleController.Campaigns;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LateStartStudio.Hero6.Campaigns.RitesOfPassage
{
    public static class RitesOfPassageConfiguration
    {
        public static IHostBuilder ConfigureHero6RitesOfPassage(this IHostBuilder hostBuilder) => hostBuilder
            .ConfigureServices(services =>
            {
                services

                    // Entry point
                    .AddSingleton<ICampaignModule, RitesOfPassageModule>()

                    // Animations
                    .AddSingleton<HeroIdle>()
                    .AddSingleton<HeroIdleCenterDown>()
                    .AddSingleton<HeroIdleCenterUp>()
                    .AddSingleton<HeroIdleLeftCenter>()
                    .AddSingleton<HeroIdleLeftDown>()
                    .AddSingleton<HeroIdleLeftUp>()
                    .AddSingleton<HeroIdleRightCenter>()
                    .AddSingleton<HeroIdleRightDown>()
                    .AddSingleton<HeroIdleRightUp>()

                    .AddSingleton<HeroWalk>()
                    .AddSingleton<HeroWalkCenterDown>()
                    .AddSingleton<HeroWalkCenterUp>()
                    .AddSingleton<HeroWalkLeftCenter>()
                    .AddSingleton<HeroWalkLeftDown>()
                    .AddSingleton<HeroWalkLeftUp>()
                    .AddSingleton<HeroWalkRightCenter>()
                    .AddSingleton<HeroWalkRightDown>()
                    .AddSingleton<HeroWalkRightUp>()

                    .AddSingleton<LlewellaIdle>()
                    .AddSingleton<LllewellaIdleCenterDown>()

                    // Characters
                    .AddSingleton<Hero>()
                    .AddSingleton<Llewella>()

                    // Inventory Items
                    .AddSingleton<InventoryItems.BentSword>()

                    // Items
                    .AddSingleton<Items.BentSword>()

                    // Rooms
                    .AddSingleton<Fountain>()
                    .AddSingleton<HillOverAlbion>();
            });
    }
}
