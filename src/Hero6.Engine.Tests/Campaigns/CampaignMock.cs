// <copyright file="CampaignMock.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using Assets;
    using UserInterfaces;

    public class CampaignMock : Campaign
    {
        public const string PlayerCharacter1 = "PlayerCharacter1";
        public const string Character1 = "Character1";
        public const string InventoryItem1 = "InventoryItem1";
        public const string Item1 = "Item1";

        private const string Id = "Mock Campaign";
        private const int Cap = 100;

        static CampaignMock()
        {
            Renderer = new RendererMock();
        }

        private CampaignMock(AssetManager assets, UserInterface ui)
            : base(Id, Cap, assets, ui)
        {
            AddCharacter(PlayerCharacter1, new PlayerCharacterMock(this));
            AddCharacter(Character1, new CharacterMock(this));
            AddInventoryItem(InventoryItem1, new InventoryItemMock(this, InventoryItem1));
            AddItem(Item1, new ItemMock(this, Item1));
        }

        public static CampaignMock Make()
        {
            AssetManagerMock assets = new AssetManagerMock();
            MockUserInterface ui = new MockUserInterface(assets, null);

            return new CampaignMock(assets, ui);
        }
    }
}
