﻿// <copyright file="LlewellaIdle.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.ModuleController.Campaigns.Animations;
using LateStartStudio.Hero6.Services.Campaigns;

namespace LateStartStudio.Hero6.Campaigns.RitesOfPassage.Animations.Characters.Llewella.Idle
{
    public class LlewellaIdle : CharacterAnimationModule
    {
        private readonly ICampaigns campaigns;

        public LlewellaIdle(ICampaigns campaigns)
        {
            this.campaigns = campaigns;
        }

        public override string Name => "Llewella Idle";

        public override void Initialize()
        {
            base.Initialize();
            CenterDown = campaigns.Current.GetAnimation<LllewellaIdleCenterDown>();
        }
    }
}
