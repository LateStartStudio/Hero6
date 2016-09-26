// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BentSword.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the BentSword type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Campaigns.RitesOfPassage.Items
{
    using System;
    using AdventureGame;
    using AdventureGame.Game;

    public class BentSword : Item
    {
        public const string Name = "Bent Sword";

        public BentSword(Campaign campaign)
            : base(campaign, "Sprites/Objects/Pick-Up/Bent Sword/BentSword")
        {
            this.Interaction += this.OnInteraction;
        }

        private void OnInteraction(object sender, EventArgs e)
        {
            this.IsVisible = false;
            this.Display("You remove the twisted sword from the ground and take it with you. Let's"
                         + " hope your own sword does not end the same shape.");
            Campaign.Player.AddInventory(Campaign.GetInventoryItem(InventoryItems.BentSword.Name));
        }
    }
}
