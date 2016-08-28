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
    using AdventureGame;
    using AdventureGame.Game;

    public sealed class HeroWalk : CharacterAnimation
    {
        public HeroWalk(Campaign campaign) : base(campaign)
        {
            this.CenterDownAnimation = new SpriteSheet(
                campaign,
                "Sprites/Characters/Hero/HeroWalkCenterDown",
                1,
                10);

            this.CenterUpAnimation = new SpriteSheet(
                campaign,
                "Sprites/Characters/Hero/HeroWalkCenterUp",
                1,
                9);

            this.LeftCenterAnimation = new SpriteSheet(
                campaign,
                "Sprites/Characters/Hero/HeroWalkLeftCenter",
                1,
                10);

            this.LeftDownAnimation = new SpriteSheet(
                campaign,
                "Sprites/Characters/Hero/HeroWalkLeftDown",
                1,
                12);

            this.LeftUpAnimation = new SpriteSheet(
                campaign,
                "Sprites/Characters/Hero/HeroWalkLeftUp",
                1,
                8);

            this.RightCenterAnimation = new SpriteSheet(
                campaign,
                "Sprites/Characters/Hero/HeroWalkRightCenter",
                1,
                9);

            this.RightDownAnimation = new SpriteSheet(
                campaign,
                "Sprites/Characters/Hero/HeroWalkRightDown",
                1,
                12);

            this.RightUpAnimation = new SpriteSheet(
                campaign,
                "Sprites/Characters/Hero/HeroWalkRightUp",
                1,
                8);

            this.CurrentSprite = this.CenterDownAnimation;
        }
    }
}
