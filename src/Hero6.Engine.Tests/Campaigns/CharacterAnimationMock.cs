// <copyright file="CharacterAnimationMock.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    public class CharacterAnimationMock : CharacterAnimation
    {
        public CharacterAnimationMock(Campaign campaign, int rows = 1, int columns = 10)
            : base(campaign)
        {
            CenterDownAnimation = MakeSpriteSheet(campaign, "CenterDown", rows, columns);
            CenterUpAnimation = MakeSpriteSheet(campaign, "CenterUp", rows, columns);
            LeftCenterAnimation = MakeSpriteSheet(campaign, "LeftCenter", rows, columns);
            LeftDownAnimation = MakeSpriteSheet(campaign, "LeftDown", rows, columns);
            LeftUpAnimation = MakeSpriteSheet(campaign, "LeftUp", rows, columns);
            RightCenterAnimation = MakeSpriteSheet(campaign, "RightCenter", rows, columns);
            RightDownAnimation = MakeSpriteSheet(campaign, "RightDown", rows, columns);
            RightUpAnimation = MakeSpriteSheet(campaign, "RightUp", rows, columns);
            CurrentSprite = CenterDownAnimation;
        }

        private static SpriteSheet MakeSpriteSheet(Campaign campaign, string id, int rows, int columns)
        {
            SpriteSheet spriteSheet = new SpriteSheet(campaign, id, rows, columns)
            {
                Sheet = campaign.Assets.CreateTexture2D(1000, 100)
            };

            return spriteSheet;
        }
    }
}
