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
    using AdventureGame;
    using AdventureGame.Game;
    using Animations;

    public sealed class Hero : Character
    {
        public const string Name = "Hero";

        public Hero(Campaign campaign) : base(campaign)
        {
            this.Animation = new HeroWalk(campaign);

            this.Look += this.OnLook;
            this.Grab += this.OnGrab;
            this.Talk += this.OnTalk;
        }

        private void OnLook(object sender, EventArgs e)
        {
            this.Display("Just another Player Character.");
        }

        private void OnGrab(object sender, EventArgs e)
        {
            this.Display("Touching yourself isn't very hero-like.");
        }

        private void OnTalk(object sender, EventArgs e)
        {
            this.Display("Did the Hero or the pizza come first you wonder...");
        }
    }
}
