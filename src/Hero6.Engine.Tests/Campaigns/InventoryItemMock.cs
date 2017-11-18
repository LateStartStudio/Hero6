// <copyright file="InventoryItemMock.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    public class InventoryItemMock : InventoryItem
    {
        public InventoryItemMock(Campaign campaign, string spriteID)
            : base(campaign, spriteID)
        {
            PostUpdate += (s, e) => IsUpdateInvoked = true;
            PostDraw += (s, e) => IsDrawInvoked = true;
        }

        public bool IsUpdateInvoked { get; private set; }

        public bool IsDrawInvoked { get; private set; }
    }
}
