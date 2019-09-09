// <copyright file="Fountain.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Drawing;
using LateStartStudio.Hero6.Campaigns.RitesOfPassage.Characters;
using LateStartStudio.Hero6.Localization;
using LateStartStudio.Hero6.ModuleController.Campaigns.Characters;
using LateStartStudio.Hero6.ModuleController.Campaigns.Rooms;
using LateStartStudio.Hero6.ModuleController.Campaigns.Rooms.Regions;
using LateStartStudio.Hero6.Services.Campaigns;
using LateStartStudio.Hero6.Services.UserInterfaces;

namespace LateStartStudio.Hero6.Campaigns.RitesOfPassage.Rooms.Albion
{
    public class Fountain : RoomModule
    {
        private readonly ICampaigns campaigns;
        private readonly IUserInterfaces userInterfaces;

        public Fountain(ICampaigns campaigns, IUserInterfaces userInterfaces)
        {
            this.campaigns = campaigns;
            this.userInterfaces = userInterfaces;
        }

        public static Color HotspotSouthExit { get; } = Color.FromArgb(255, 255, 255, 255);

        public static Color HotspotFountainSpot { get; } = Color.FromArgb(255, 255, 0, 0);

        public override string Name => "Fountain";

        public override string Background => "Campaigns/Rites of Albion/Rooms/Albion/Fountain/Background";

        public override string WalkAreasMask => "Campaigns/Rites of Albion/Rooms/Albion/Fountain/WalkAreas";

        public override string HotspotsMask => "Campaigns/Rites of Albion/Rooms/Albion/Fountain/Hotspots";

        public override void Initialize()
        {
            base.Initialize();

            var llewella = campaigns.Current.GetCharacter<Llewella>();
            llewella.X = 200;
            llewella.Y = 150;
            llewella.Face(CharacterDirection.CenterDown);
            AddCharacter<Llewella>();

            Hotspots[HotspotSouthExit].StandingOn = OnWhileStandingOnSouthExit;
            Hotspots[HotspotFountainSpot].Look = OnLookFountain;
            Hotspots[HotspotFountainSpot].Grab = OnGrabFountain;
            Hotspots[HotspotFountainSpot].Talk = OnTalkFountain;
        }

        private void OnWhileStandingOnSouthExit(StandingOn e)
        {
            e.Character.ChangeRoom<HillOverAlbion>(220, 190, CharacterDirection.CenterDown);
        }

        private void OnLookFountain()
        {
            userInterfaces.Current.ShowTextBox(Strings.FountainLook);
        }

        private void OnGrabFountain()
        {
            userInterfaces.Current.ShowTextBox(Strings.FountainGrab);
        }

        private void OnTalkFountain()
        {
            userInterfaces.Current.ShowTextBox(Strings.FountainTalk);
        }
    }
}
