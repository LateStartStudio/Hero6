// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Llewella.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the Llewella type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Campaigns.RitesOfPassage.Characters
{
    using System;
    using AdventureGame;
    using AdventureGame.Game;
    using Animations;
    using InventoryItems;

    public sealed class Llewella : Character
    {
        public const string Name = "Llewella";

        private bool swordReturned;

        public Llewella(Campaign campaign) : base(campaign)
        {
            this.Animation = new LlewellaWalk(campaign);

            this.Interaction += this.OnInteraction;
        }

        private void OnInteraction(object sender, EventArgs e)
        {
            if (!this.swordReturned)
            {
                if (Campaign.Player.HasInventory(Campaign.GetInventoryItem(BentSword.Name)))
                {
                    System.Diagnostics.Debug.WriteLine("You found my sword! Thank you so much!");
                    Campaign.Player.RemoveInventory(Campaign.GetInventoryItem(BentSword.Name));
                    this.swordReturned = true;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("I've lost my sword oh great hero!");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("You're my hero!");
            }
        }
    }
}
