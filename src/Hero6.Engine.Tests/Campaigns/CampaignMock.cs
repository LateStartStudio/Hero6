// <copyright file="CampaignMock.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using Assets;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using UserInterfaces;

    public class CampaignMock : Campaign
    {
        public const string PlayerCharacter1 = "PlayerCharacter1";
        public const string Character1 = "Character1";
        public const string InventoryItem1 = "InventoryItem1";
        public const string Item1 = "Item1";
        public const string Room1 = "Room1";
        public const string Room2 = "Room2";

        private const string Id = "Mock Campaign";
        private const int Cap = 100;

        static CampaignMock()
        {
            Renderer = new RendererMock();
        }

        private CampaignMock(AssetManager assets, UserInterface ui)
            : base(Id, Cap, assets, ui)
        {
            PlayerCharacter playerCharacter1 = new PlayerCharacterMock(this);
            AddCharacter(PlayerCharacter1, playerCharacter1);
            Character character1 = new CharacterMock(this);
            AddCharacter(Character1, character1);
            AddInventoryItem(InventoryItem1, new InventoryItemMock(this, InventoryItem1));
            AddItem(Item1, new ItemMock(this, Item1));
            Room room1 = new RoomMock(this);
            room1.Characters.Add(playerCharacter1);
            room1.Characters.Add(character1);
            AddRoom(Room1, room1);
            AddRoom(Room2, new RoomMock(this));
        }

        public static CampaignMock Make()
        {
            AssetManagerMock assets = new AssetManagerMock();
            MockUserInterface ui = new MockUserInterface(assets, new MouseCoreMock());

            return new CampaignMock(assets, ui);
        }
    }
}
