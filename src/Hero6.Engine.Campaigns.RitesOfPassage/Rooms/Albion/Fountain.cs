// <copyright file="Fountain.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Rooms.Albion
{
    using LateStartStudio.Hero6.Engine.Assets.Graphics;
    using LateStartStudio.Hero6.Engine.Campaigns.Characters;
    using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Characters;
    using LateStartStudio.Hero6.Engine.Campaigns.Rooms;
    using LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions;
    using LateStartStudio.Hero6.Engine.UserInterfaces;
    using LateStartStudio.Hero6.Localization;

    public class Fountain : RoomModule
    {
        private readonly ICampaigns campaigns;
        private readonly IUserInterfaces userInterfaces;

        public Fountain(ICampaigns campaigns, IUserInterfaces userInterfaces)
        {
            this.campaigns = campaigns;
            this.userInterfaces = userInterfaces;
        }

        public override string Name => "Fountain";

        public override string Background => "Campaigns/Rites of Albion/Rooms/Albion/Fountain/Background";

        public override string WalkAreasMask => "Campaigns/Rites of Albion/Rooms/Albion/Fountain/WalkAreas";

        public override string HotspotsMask => "Campaigns/Rites of Albion/Rooms/Albion/Fountain/Hotspots";

        public Color HotspotSouthExit { get; } = new Color(255, 255, 255, 255);

        public Color HotspotFountainSpot { get; } = new Color(255, 0, 0, 255);

        protected override void Initialize()
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
