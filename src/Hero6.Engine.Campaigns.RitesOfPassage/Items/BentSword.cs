// <copyright file="BentSword.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Items
{
    using System;
    using Campaigns;
    using Localization;

    public class BentSword : Item
    {
        public const string Id = "Bent Sword";

        public BentSword(Campaign campaign)
            : base(campaign, "Campaigns/Rites of Albion/Sprites/Items/Bent Sword")
        {
            this.Look += this.OnLook;
            this.Grab += this.OnGrab;
            this.Talk += this.OnTalk;
        }

        private void OnLook(object sender, EventArgs e)
        {
            this.Display(Strings.BentSwordLook);
        }

        private void OnGrab(object sender, EventArgs e)
        {
            this.IsVisible = false;
            this.Display(Strings.BentSwordGrab);
            Campaign.Player.AddInventory(Campaign.GetInventoryItem(Engine.Campaigns.RitesOfPassage.InventoryItems.BentSword.Id));
        }

        private void OnTalk(object sender, EventArgs e)
        {
            this.Display(Strings.BentSwordTalk);
        }
    }
}
