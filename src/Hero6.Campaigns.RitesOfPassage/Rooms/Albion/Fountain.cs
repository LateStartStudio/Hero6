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
    using AdventureGame;
    using AdventureGame.Engine.Graphics;
    using AdventureGame.Game;
    using Characters;

    public sealed class Fountain : Room
    {
        public const string Name = "Fountain";

        private static readonly Color SouthExit = new Color(255, 255, 255, 255);

        public Fountain(Campaign campaign)
            : base(
                  campaign,
                  "Backgrounds/Albion/Fountain",
                  "Backgrounds/Albion/FountainWalkArea",
                  "Backgrounds/Albion/FountainRegions")
        {
            Character llewella = Campaign.GetCharacter(Llewella.Name);
            llewella.Location = new Point(200, 150);
            this.Characters.Add(llewella);
        }

        protected override void InitializeEvents()
        {
            this.Hotspots[SouthExit].WhileStandingIn += this.DummyTest;
        }

        private void DummyTest(object sender, HotspotWalkingEventArgs e)
        {
            e.Character.ChangeRoom(HillOverAlbion.Name, 220, 190);
        }
    }
}
