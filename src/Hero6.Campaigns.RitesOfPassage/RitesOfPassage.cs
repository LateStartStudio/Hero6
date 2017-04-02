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
    using AdventureGame.Campaigns;
    using AdventureGame.Engine;
    using AdventureGame.UserInterfaces;
    using Characters;
    using Items;
    using Rooms.Albion;

    public sealed class RitesOfPassage : Campaign
    {
        public RitesOfPassage(Engine engine, ContentManager content, UserInterface userInterface)
            : base("Rites of Passage", 100, engine, content, userInterface)
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
            this.AddInventoryItem(InventoryItems.BentSword.Id, new InventoryItems.BentSword(this));
        }

        private void AddRooms()
        {
            this.AddRoom(Fountain.Id, new Fountain(this));
            this.AddRoom(HillOverAlbion.Id, new HillOverAlbion(this));
        }
    }
}
