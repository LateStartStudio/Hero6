﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LlewellaWalk.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the LlewellaWalk type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Campaigns.RitesOfPassage.Animations
{
    using AdventureGame;
    using AdventureGame.Game;

    public sealed class LlewellaWalk : CharacterAnimation
    {
        public LlewellaWalk(Campaign campaign) : base(campaign)
        {
            this.CenterDownAnimation = new SpriteSheet(
                campaign,
                "Sprites/Characters/NPCs/Llewella/LlewellaWalkCenterDown",
                1,
                1);

            this.CenterUpAnimation = new SpriteSheet(
                campaign,
                "Sprites/Characters/NPCs/Llewella/LlewellaWalkCenterDown",
                1,
                1);

            this.LeftCenterAnimation = new SpriteSheet(
                campaign,
                "Sprites/Characters/NPCs/Llewella/LlewellaWalkCenterDown",
                1,
                1);

            this.LeftDownAnimation = new SpriteSheet(
                campaign,
                "Sprites/Characters/NPCs/Llewella/LlewellaWalkCenterDown",
                1,
                1);

            this.LeftUpAnimation = new SpriteSheet(
                campaign,
                "Sprites/Characters/NPCs/Llewella/LlewellaWalkCenterDown",
                1,
                1);

            this.RightCenterAnimation = new SpriteSheet(
                campaign,
                "Sprites/Characters/NPCs/Llewella/LlewellaWalkCenterDown",
                1,
                1);

            this.RightDownAnimation = new SpriteSheet(
                campaign,
                "Sprites/Characters/NPCs/Llewella/LlewellaWalkCenterDown",
                1,
                1);

            this.RightUpAnimation = new SpriteSheet(
                campaign,
                "Sprites/Characters/NPCs/Llewella/LlewellaWalkCenterDown",
                1,
                1);

            this.CurrentSprite = this.CenterDownAnimation;
        }
    }
}
