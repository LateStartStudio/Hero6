// <copyright file="HillOverAlbion.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Drawing;
using LateStartStudio.Hero6.Campaigns.RitesOfPassage.Characters;
using LateStartStudio.Hero6.Campaigns.RitesOfPassage.Items;
using LateStartStudio.Hero6.Localization;
using LateStartStudio.Hero6.ModuleController.Campaigns.Characters;
using LateStartStudio.Hero6.ModuleController.Campaigns.Rooms;
using LateStartStudio.Hero6.ModuleController.Campaigns.Rooms.Regions;
using LateStartStudio.Hero6.Services.Campaigns;
using LateStartStudio.Hero6.Services.UserInterfaces;

namespace LateStartStudio.Hero6.Campaigns.RitesOfPassage.Rooms.Albion
{
    public class HillOverAlbion : RoomModule
    {
        private readonly ICampaigns campaigns;
        private readonly IUserInterfaces userInterfaces;

        public HillOverAlbion(ICampaigns campaigns, IUserInterfaces userInterfaces)
        {
            this.campaigns = campaigns;
            this.userInterfaces = userInterfaces;
        }

        public static Color HotspotNorthExit { get; } = Color.FromArgb(255, 255, 255, 255);

        public static Color HotspotAlbionSign { get; } = Color.FromArgb(255, 255, 0, 0);

        public override string Name => "Hill Over Albion";

        public override string Background => "Campaigns/Rites of Albion/Rooms/Albion/Hill Over Albion/Background";

        public override string WalkAreasMask => "Campaigns/Rites of Albion/Rooms/Albion/Hill Over Albion/WalkAreas";

        public override string HotspotsMask => "Campaigns/Rites of Albion/Rooms/Albion/Hill Over Albion/Hotspots";

        public override void Initialize()
        {
            base.Initialize();

            var hero = campaigns.Current.GetCharacter<Hero>();
            hero.X = 250;
            hero.Y = 220;
            hero.Face(CharacterDirection.CenterDown);
            AddCharacter<Hero>();

            var bentSword = campaigns.Current.GetItem<BentSword>();
            bentSword.X = 150;
            bentSword.Y = 170;
            AddItem<BentSword>();

            Hotspots[HotspotNorthExit].StandingOn = OnWhileStandingInNorthExit;
            Hotspots[HotspotAlbionSign].Look = OnLookAlbionSign;
            Hotspots[HotspotAlbionSign].Grab = OnGrabAlbionSign;
            Hotspots[HotspotAlbionSign].Talk = OnTalkAlbionSign;
        }

        private void OnWhileStandingInNorthExit(StandingOn e)
        {
            e.Character.ChangeRoom<Fountain>(100, 200, CharacterDirection.CenterUp);
        }

        private void OnLookAlbionSign()
        {
            userInterfaces.Current.ShowTextBox(Strings.AlbionSignLook);
        }

        private void OnGrabAlbionSign()
        {
            userInterfaces.Current.ShowTextBox(Strings.AlbionSignGrab);
        }

        private void OnTalkAlbionSign()
        {
            userInterfaces.Current.ShowTextBox(Strings.AlbionSignTalk);
        }
    }
}
