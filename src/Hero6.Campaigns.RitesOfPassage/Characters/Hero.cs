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

            this.Interaction += this.OnInteraction;
        }

        private void OnInteraction(object sender, EventArgs e)
        {
            this.Display("Clicked character " + Name);
        }
    }
}
