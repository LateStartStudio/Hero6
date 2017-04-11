// <copyright file="Llewella.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Characters
{
    using System;
    using Animations;
    using Campaigns;
    using InventoryItems;
    using Locales;

    public sealed class Llewella : Character
    {
        public const string Id = "Llewella";

        private bool swordReturned;

        public Llewella(Campaign campaign) : base(campaign)
        {
            this.Animation = new LlewellaWalk(campaign);

            this.Look += this.OnLook;
            this.Grab += this.OnGrab;
            this.Talk += this.OnTalk;
        }

        private void OnGrab(object sender, EventArgs e)
        {
            this.Display(Strings.LlewellaGrab);
        }

        private void OnLook(object sender, EventArgs e)
        {
            this.Display(Strings.LlewellaLook);
        }

        private void OnTalk(object sender, EventArgs e)
        {
            if (!this.swordReturned)
            {
                if (Campaign.Player.HasInventory(Campaign.GetInventoryItem(BentSword.Id)))
                {
                    this.Display(Strings.LlewellaTalk1);
                    Campaign.Player.RemoveInventory(Campaign.GetInventoryItem(BentSword.Id));
                    this.swordReturned = true;
                }
                else
                {
                    this.Display(Strings.LlewellaTalk2);
                }
            }
            else
            {
                this.Display(Strings.LlewellaTalk3);
            }
        }
    }
}
