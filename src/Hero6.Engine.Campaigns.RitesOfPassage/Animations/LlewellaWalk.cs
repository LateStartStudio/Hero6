// <copyright file="LlewellaWalk.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Animations
{
    using Campaigns;

    public sealed class LlewellaWalk : CharacterAnimation
    {
        public LlewellaWalk(Campaign campaign) : base(campaign)
        {
            this.CenterDownAnimation = new SpriteSheet(
                campaign,
                "Campaigns/Rites of Albion/Animations/Characters/Llewella/Walk/Center Down",
                1,
                1);

            this.CenterUpAnimation = new SpriteSheet(
                campaign,
                "Campaigns/Rites of Albion/Animations/Characters/Llewella/Walk/Center Down",
                1,
                1);

            this.LeftCenterAnimation = new SpriteSheet(
                campaign,
                "Campaigns/Rites of Albion/Animations/Characters/Llewella/Walk/Center Down",
                1,
                1);

            this.LeftDownAnimation = new SpriteSheet(
                campaign,
                "Campaigns/Rites of Albion/Animations/Characters/Llewella/Walk/Center Down",
                1,
                1);

            this.LeftUpAnimation = new SpriteSheet(
                campaign,
                "Campaigns/Rites of Albion/Animations/Characters/Llewella/Walk/Center Down",
                1,
                1);

            this.RightCenterAnimation = new SpriteSheet(
                campaign,
                "Campaigns/Rites of Albion/Animations/Characters/Llewella/Walk/Center Down",
                1,
                1);

            this.RightDownAnimation = new SpriteSheet(
                campaign,
                "Campaigns/Rites of Albion/Animations/Characters/Llewella/Walk/Center Down",
                1,
                1);

            this.RightUpAnimation = new SpriteSheet(
                campaign,
                "Campaigns/Rites of Albion/Animations/Characters/Llewella/Walk/Center Down",
                1,
                1);

            this.CurrentSprite = this.CenterDownAnimation;
        }
    }
}
