// <copyright file="LlewellaIdle.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Animations.Characters.Llewella.Idle
{
    using LateStartStudio.Hero6.Engine.Campaigns.Animations;

    public class LlewellaIdle : CharacterAnimationModule
    {
        private readonly ICampaigns campaigns;

        public LlewellaIdle(ICampaigns campaigns)
        {
            this.campaigns = campaigns;
        }

        public override string Name => "Llewella Idle";

        protected override void Initialize()
        {
            base.Initialize();
            CenterDown = campaigns.Current.GetAnimation<LllewellaIdleCenterDown>();
        }
    }
}
