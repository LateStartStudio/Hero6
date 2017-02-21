// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HillOverAlbion.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the HillOverAlbion type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Campaigns.RitesOfPassage.Rooms.Albion
{
    using System;
    using AdventureGame;
    using AdventureGame.Engine.Graphics;
    using AdventureGame.Game;
    using Characters;
    using Items;

    public sealed class HillOverAlbion : Room
    {
        public const string Name = "Hill Over Albion";

        private static readonly Color NorthExit = new Color(255, 255, 255, 255);
        private static readonly Color AlbionSign = new Color(255, 0, 0, 255);

        public HillOverAlbion(Campaign campaign)
            : base(
                  campaign,
                  "Backgrounds/Albion/HillOverAlbion",
                  "Backgrounds/Albion/HillOverAlbionWalkArea",
                  "Backgrounds/Albion/HillOverAlbionRegions")
        {
            Character hero = Campaign.GetCharacter(Hero.Name);
            hero.Location = new Point(250, 220);
            this.Characters.Add(hero);

            Item bentSword = Campaign.GetItem(BentSword.Name);
            bentSword.Location = new Point(150, 170);
            this.Items.Add(bentSword);
        }

        protected override void InitializeEvents()
        {
            this.Hotspots[NorthExit].WhileStandingIn += this.OnWhileStandingInNorthExit;

            this.Hotspots[AlbionSign].Look += this.OnLookAlbionSign;
            this.Hotspots[AlbionSign].Grab += this.OnGrabAlbionSign;
            this.Hotspots[AlbionSign].Talk += this.OnTalkAlbionSign;
        }

        private void OnWhileStandingInNorthExit(object sender, HotspotWalkingEventArgs e)
        {
            e.Character.ChangeRoom(Fountain.Name, 100, 210);
        }

        private void OnLookAlbionSign(object sender, EventArgs eventArgs)
        {
            this.Display("This must be Albion.");
        }

        private void OnGrabAlbionSign(object sender, EventArgs eventArgs)
        {
            this.Display("You can't quite reach it.");
        }

        private void OnTalkAlbionSign(object sender, EventArgs eventArgs)
        {
            this.Display("It talks as much as any other piece wood.");
        }
    }
}
