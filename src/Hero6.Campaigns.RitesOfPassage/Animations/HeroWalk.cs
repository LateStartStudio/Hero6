// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HeroWalk.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the HeroWalk type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Campaigns.RitesOfPassage.Animations
{
    using AdventureGame.Campaigns;

    public sealed class HeroWalk : CharacterAnimation
    {
        public HeroWalk(Campaign campaign) : base(campaign)
        {
            this.CenterDownAnimation = new SpriteSheet(
                campaign,
                "Campaigns/Rites of Albion/Animations/Characters/Hero/Walk/Center Down",
                1,
                10);

            this.CenterUpAnimation = new SpriteSheet(
                campaign,
                "Campaigns/Rites of Albion/Animations/Characters/Hero/Walk/Center Up",
                1,
                9);

            this.LeftCenterAnimation = new SpriteSheet(
                campaign,
                "Campaigns/Rites of Albion/Animations/Characters/Hero/Walk/Left Center",
                1,
                10);

            this.LeftDownAnimation = new SpriteSheet(
                campaign,
                "Campaigns/Rites of Albion/Animations/Characters/Hero/Walk/Left Down",
                1,
                12);

            this.LeftUpAnimation = new SpriteSheet(
                campaign,
                "Campaigns/Rites of Albion/Animations/Characters/Hero/Walk/Left Up",
                1,
                8);

            this.RightCenterAnimation = new SpriteSheet(
                campaign,
                "Campaigns/Rites of Albion/Animations/Characters/Hero/Walk/Right Center",
                1,
                9);

            this.RightDownAnimation = new SpriteSheet(
                campaign,
                "Campaigns/Rites of Albion/Animations/Characters/Hero/Walk/Right Down",
                1,
                12);

            this.RightUpAnimation = new SpriteSheet(
                campaign,
                "Campaigns/Rites of Albion/Animations/Characters/Hero/Walk/Right Up",
                1,
                8);

            this.CurrentSprite = this.CenterDownAnimation;
        }
    }
}
