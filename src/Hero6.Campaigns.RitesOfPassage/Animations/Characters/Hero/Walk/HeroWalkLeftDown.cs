﻿// <copyright file="HeroWalkLeftDown.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.ModuleController.Campaigns.Animations;

namespace LateStartStudio.Hero6.Campaigns.RitesOfPassage.Animations.Characters.Hero.Walk
{
    public class HeroWalkLeftDown : AnimationModule
    {
        public override string Name => "Hero Walk Left Down";

        public override string Sprite => "Campaigns/Rites of Albion/Animations/Characters/Hero/Walk/Left Down";

        public override int Cols => 11;

        public override int Rows => 1;
    }
}
