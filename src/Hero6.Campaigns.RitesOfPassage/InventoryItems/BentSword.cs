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

namespace LateStartStudio.Hero6.Campaigns.RitesOfPassage.InventoryItems
{
    using AdventureGame;
    using AdventureGame.Game;

    public sealed class BentSword : InventoryItem
    {
        public const string Name = "Bent Sword";

        public BentSword(Campaign campaign)
            : base(campaign, "Sprites/Objects/Pick-Up/Bent Sword/BentSword")
        {
        }
    }
}
