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
    using AdventureGame.Game.Regions;
    using Characters;
    using Items;
    using Locales;

    public sealed class HillOverAlbion : Room
    {
        public const string Id = "Hill Over Albion";

        private static readonly Color HotspotNorthExit = new Color(255, 255, 255, 255);
        private static readonly Color HotspotAlbionSign = new Color(255, 0, 0, 255);

        public HillOverAlbion(Campaign campaign)
            : base(
                  campaign,
                  "Campaigns/Rites of Albion/Rooms/Albion/Hill Over Albion/Background",
                  "Campaigns/Rites of Albion/Rooms/Albion/Hill Over Albion/Walk Area",
                  "Campaigns/Rites of Albion/Rooms/Albion/Hill Over Albion/Hotspots")
        {
            Character hero = Campaign.GetCharacter(Hero.Id);
            hero.Location = new Point(250, 220);
            this.Characters.Add(hero);

            Item bentSword = Campaign.GetItem(BentSword.Id);
            bentSword.Location = new Point(150, 170);
            this.Items.Add(bentSword);
        }

        protected override void InitializeEvents()
        {
            this.Hotspots[HotspotNorthExit].WhileStandingIn += this.OnWhileStandingInNorthExit;

            this.Hotspots[HotspotAlbionSign].Look += this.OnLookAlbionSign;
            this.Hotspots[HotspotAlbionSign].Grab += this.OnGrabAlbionSign;
            this.Hotspots[HotspotAlbionSign].Talk += this.OnTalkAlbionSign;
        }

        private void OnWhileStandingInNorthExit(object sender, HotspotWalkingEventArgs e)
        {
            e.Character.ChangeRoom(Fountain.Id, 100, 210);
        }

        private void OnLookAlbionSign(object sender, EventArgs eventArgs)
        {
            this.Display(Strings.AlbionSignLook);
        }

        private void OnGrabAlbionSign(object sender, EventArgs eventArgs)
        {
            this.Display(Strings.AlbionSignGrab);
        }

        private void OnTalkAlbionSign(object sender, EventArgs eventArgs)
        {
            this.Display(Strings.AlbionSignTalk);
        }
    }
}
