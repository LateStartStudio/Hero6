// <copyright file="CampaignMock.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using Assets;
    using LateStartStudio.Hero6.Engine.Assets.Graphics;
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
            PlayerCharacter playerCharacter1 = new PlayerCharacterMock(this)
            {
                Location = new Point(0, 1)
            };
            AddCharacter(PlayerCharacter1, playerCharacter1);
            Player = playerCharacter1;
            Character character1 = new CharacterMock(this)
            {
                Location = new Point(1, 1)
            };
            AddCharacter(Character1, character1);
            AddInventoryItem(InventoryItem1, new InventoryItemMock(this, "0:0:0"));
            Item item1 = new ItemMock(this, "0:0:0")
            {
                Location = new Point(0, 2)
            };
            AddItem(Item1, item1);
            Room room1 = new RoomMock(this, "0:3:3", "0:0:0", "r:2:2");
            room1.Characters.Add(playerCharacter1);
            room1.Characters.Add(character1);
            room1.Items.Add(item1);
            AddRoom(Room1, room1);
            AddRoom(Room2, new RoomMock(this, "0:0:0", "0:0:0", "0:0:0"));
        }

        public static CampaignMock Make()
        {
            AssetManagerMock assets = new AssetManagerMock();
            MockUserInterface ui = new MockUserInterface(assets, new MouseCoreMock());

            return new CampaignMock(assets, ui);
        }
    }
}
