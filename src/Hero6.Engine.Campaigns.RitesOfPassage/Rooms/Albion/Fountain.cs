// <copyright file="Fountain.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Rooms.Albion
{
    using System;
    using Assets.Graphics;
    using Campaigns;
    using Characters;
    using Localization;
    using Regions;

    public sealed class Fountain : Room
    {
        public const string Id = "Fountain";

        private static readonly Color HotspotSouthExit = new Color(255, 255, 255, 255);
        private static readonly Color HotspotFountainSpot = new Color(255, 0, 0, 255);

        public Fountain(Campaign campaign)
            : base(
                  campaign,
                  "Campaigns/Rites of Albion/Rooms/Albion/Fountain/Background",
                  "Campaigns/Rites of Albion/Rooms/Albion/Fountain/WalkAreas",
                  "Campaigns/Rites of Albion/Rooms/Albion/Fountain/Hotspots")
        {
            Character llewella = Campaign.GetCharacter(Llewella.Id);
            llewella.Location = new Point(200, 150);
            this.Characters.Add(llewella);
        }

        protected override void InitializeEvents()
        {
            this.Hotspots[HotspotSouthExit].WhileStandingIn += this.OnWhileStandingInSouthExit;

            this.Hotspots[HotspotFountainSpot].Look += this.OnLookFountain;
            this.Hotspots[HotspotFountainSpot].Grab += this.OnGrabFountain;
            this.Hotspots[HotspotFountainSpot].Talk += this.OnTalkFountain;
        }

        private void OnLookFountain(object sender, EventArgs eventArgs)
        {
            this.Display(Strings.FountainLook);
        }

        private void OnGrabFountain(object sender, EventArgs eventArgs)
        {
            this.Display(Strings.FountainGrab);
        }

        private void OnTalkFountain(object sender, EventArgs eventArgs)
        {
            this.Display(Strings.FountainTalk);
        }

        private void OnWhileStandingInSouthExit(object sender, HotspotWalkingEventArgs e)
        {
            e.Character.ChangeRoom(HillOverAlbion.Id, 220, 190);
        }
    }
}
