// <copyright file="BentSword.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.InventoryItems
{
    using Campaigns;

    public sealed class BentSword : InventoryItem
    {
        public const string Id = "Bent Sword";

        public BentSword(Campaign campaign)
            : base(campaign, "Campaigns/Rites of Albion/Sprites/Items/Bent Sword")
        {
        }
    }
}
