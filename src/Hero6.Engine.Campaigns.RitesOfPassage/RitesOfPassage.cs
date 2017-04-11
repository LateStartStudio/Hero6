// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RitesOfPassage.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the RitesOfPassage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
        public RitesOfPassage(Renderer renderer, AssetManager assets, UserInterface userInterface)
            : base("Rites of Passage", 100, renderer, assets, userInterface)
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
