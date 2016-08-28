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

namespace LateStartStudio.Hero6.Campaigns.RitesOfPassage
{
    using AdventureGame;
    using AdventureGame.Engine;
    using Characters;
    using Items;
    using Rooms.Albion;

    public sealed class RitesOfPassage : Campaign
    {
        public RitesOfPassage(Engine engine) : base("Rites of Passage", engine)
        {
            this.AddCharacters();
            this.AddItems();
            this.AddInventoryItems();
            this.AddRooms();

            this.CurrentRoom = this.GetRoom(HillOverAlbion.Name);
            this.Player = this.GetCharacter(Hero.Name);
        }

        private void AddCharacters()
        {
            this.AddCharacter(Hero.Name, new Hero(this));
            this.AddCharacter(Llewella.Name, new Llewella(this));
        }

        private void AddItems()
        {
            this.AddItem(BentSword.Name, new BentSword(this));
        }

        private void AddInventoryItems()
        {
            this.AddInventoryItem(InventoryItems.BentSword.Name, new InventoryItems.BentSword(this));
        }

        private void AddRooms()
        {
            this.AddRoom(Fountain.Name, new Fountain(this));
            this.AddRoom(HillOverAlbion.Name, new HillOverAlbion(this));
        }
    }
}
