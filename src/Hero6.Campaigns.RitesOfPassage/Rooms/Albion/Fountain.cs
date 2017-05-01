// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Fountain.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the Fountain type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Campaigns.RitesOfPassage.Rooms.Albion
{
    using System;
    using AdventureGame;
    using AdventureGame.Engine.Graphics;
    using AdventureGame.Game;
    using Characters;

    public sealed class Fountain : Room
    {
        public const string Name = "Fountain";

        private static readonly Color SouthExit = new Color(255, 255, 255, 255);
        private static readonly Color FountainSpot = new Color(255, 0, 0, 255);

        public Fountain(Campaign campaign)
            : base(
                  campaign,
                  "Campaigns/Rites of Albion/Rooms/Albion/Fountain/Background",
                  "Campaigns/Rites of Albion/Rooms/Albion/Fountain/Walk Area",
                  "Campaigns/Rites of Albion/Rooms/Albion/Fountain/Hotspots")
        {
            Character llewella = Campaign.GetCharacter(Llewella.Name);
            llewella.Location = new Point(200, 150);
            this.Characters.Add(llewella);
        }

        protected override void InitializeEvents()
        {
            this.Hotspots[SouthExit].WhileStandingIn += this.OnWhileStandingInSouthExit;

            this.Hotspots[FountainSpot].Look += this.OnLook;
            this.Hotspots[FountainSpot].Grab += this.OnGrab;
            this.Hotspots[FountainSpot].Talk += this.OnTalk;
        }

        private void OnLook(object sender, EventArgs eventArgs)
        {
            this.Display("Looks like a fountain.");
        }

        private void OnGrab(object sender, EventArgs eventArgs)
        {
            this.Display("Feels like a fountain.");
        }

        private void OnTalk(object sender, EventArgs eventArgs)
        {
            this.Display("Speaks like a fountain.");
        }

        private void OnWhileStandingInSouthExit(object sender, HotspotWalkingEventArgs e)
        {
            e.Character.ChangeRoom(HillOverAlbion.Name, 220, 190);
        }
    }
}
