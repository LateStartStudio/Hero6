// <copyright file="BentSword.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Engine.Campaigns.Items;
using LateStartStudio.Hero6.Engine.UserInterfaces;
using LateStartStudio.Hero6.Localization;

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Items
{
    public class BentSword : ItemModule
    {
        private readonly IUserInterfaces userInterfaces;
        private readonly ICampaigns campaigns;

        public BentSword(IUserInterfaces userInterfaces, ICampaigns campaigns)
        {
            this.userInterfaces = userInterfaces;
            this.campaigns = campaigns;
        }

        public override string Name => "Bent Sword";

        public override string Sprite => "Campaigns/Rites of Albion/Sprites/Items/Bent Sword";

        public override void Initialize()
        {
            base.Initialize();
            Look = OnLook;
            Grab = OnGrab;
            Talk = OnTalk;
        }

        private void OnLook()
        {
            userInterfaces.Current.ShowTextBox(Strings.BentSwordLook);
        }

        private void OnGrab()
        {
            IsVisible = false;
            userInterfaces.Current.ShowTextBox(Strings.BentSwordGrab);
            campaigns.Current.Player.AddInventoryItem<InventoryItems.BentSword>();
        }

        private void OnTalk()
        {
            userInterfaces.Current.ShowTextBox(Strings.BentSwordTalk);
        }
    }
}
