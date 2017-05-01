// <copyright file="Hero.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Characters
{
    using System;
    using Animations;
    using Campaigns;
    using Locales;

    public sealed class Hero : PlayerCharacter
    {
        public const string Id = "Hero";

        public Hero(Campaign campaign) : base(campaign)
        {
            this.Animation = new HeroWalk(campaign);

            this.Look += this.OnLook;
            this.Grab += this.OnGrab;
            this.Talk += this.OnTalk;
        }

        private void OnLook(object sender, EventArgs e)
        {
            this.Display(Strings.HeroLook);
        }

        private void OnGrab(object sender, EventArgs e)
        {
            this.Display(Strings.HeroGrab);
        }

        private void OnTalk(object sender, EventArgs e)
        {
            this.Display(Strings.HeroTalk);
        }
    }
}
