// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Hero.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the Hero type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Campaigns.RitesOfPassage.Characters
{
    using System;
    using AdventureGame.Campaigns;
    using Animations;
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
