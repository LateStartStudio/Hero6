﻿// <copyright file="HeroIdle.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Animations.Characters.Hero.Idle;
using LateStartStudio.Hero6.ModuleController.Campaigns.Animations;
using LateStartStudio.Hero6.Services.Campaigns;

namespace LateStartStudio.Hero6.Campaigns.RitesOfPassage.Animations.Characters.Hero.Idle
{
    public class HeroIdle : CharacterAnimationModule
    {
        private readonly ICampaigns campaigns;

        public HeroIdle(ICampaigns campaigns)
        {
            this.campaigns = campaigns;
        }

        public override string Name => "Hero Idle Animation";

        public override void Initialize()
        {
            base.Initialize();

            CenterDown = campaigns.Current.GetAnimation<HeroIdleCenterDown>();
            CenterUp = campaigns.Current.GetAnimation<HeroIdleCenterUp>();
            LeftCenter = campaigns.Current.GetAnimation<HeroIdleLeftCenter>();
            LeftDown = campaigns.Current.GetAnimation<HeroIdleLeftDown>();
            LeftUp = campaigns.Current.GetAnimation<HeroIdleLeftUp>();
            RightCenter = campaigns.Current.GetAnimation<HeroIdleRightCenter>();
            RightDown = campaigns.Current.GetAnimation<HeroIdleRightDown>();
            RightUp = campaigns.Current.GetAnimation<HeroIdleRightUp>();
        }
    }
}
