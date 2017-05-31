// <copyright file="RitesOfPassage.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage
{
    using Assets;
    using Campaigns;
    using Characters;
    using Items;
    using Rooms.Albion;
    using UserInterfaces;

    public sealed class RitesOfPassage : Campaign
    {
        public RitesOfPassage(AssetManager assets, UserInterface userInterface)
            : base("Rites of Passage", 100, assets, userInterface)
        {
            this.AddCharacters();
            this.AddItems();
            this.AddInventoryItems();
            this.AddRooms();

            this.CurrentRoom = this.GetRoom(HillOverAlbion.Id);
            this.Player = (PlayerCharacter)this.GetCharacter(Hero.Id);
        }

        private void AddCharacters()
        {
            this.AddCharacter(Hero.Id, new Hero(this));
            this.AddCharacter(Llewella.Id, new Llewella(this));
        }

        private void AddItems()
        {
            this.AddItem(BentSword.Id, new BentSword(this));
        }

        private void AddInventoryItems()
        {
            this.AddInventoryItem(Engine.Campaigns.RitesOfPassage.InventoryItems.BentSword.Id, new Engine.Campaigns.RitesOfPassage.InventoryItems.BentSword(this));
        }

        private void AddRooms()
        {
            this.AddRoom(Fountain.Id, new Fountain(this));
            this.AddRoom(HillOverAlbion.Id, new HillOverAlbion(this));
        }
    }
}
