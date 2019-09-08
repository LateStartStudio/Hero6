// <copyright file="Llewella.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Characters
{
    using LateStartStudio.Hero6.Engine.Campaigns.Characters;
    using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Animations.Characters.Llewella.Idle;
    using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.InventoryItems;
    using LateStartStudio.Hero6.Engine.UserInterfaces;
    using LateStartStudio.Hero6.Localization;

    public class Llewella : CharacterModule
    {
        private readonly IUserInterfaces userInterfaces;
        private readonly ICampaigns campaigns;

        public Llewella(IUserInterfaces userInterfaces, ICampaigns campaigns)
        {
            this.userInterfaces = userInterfaces;
            this.campaigns = campaigns;
        }

        public override string Name => "Llewella";

        public override void Initialize()
        {
            base.Initialize();

            IdleAnimation = campaigns.Current.GetCharacterAnimation<LlewellaIdle>();
            Look = OnLook;
            Grab = OnGrab;
            Talk = OnTalk;
        }

        private void OnLook()
        {
            userInterfaces.Current.ShowTextBox(Strings.LlewellaLook);
        }

        private void OnGrab()
        {
            userInterfaces.Current.ShowTextBox(Strings.LlewellaGrab);
        }

        private void OnTalk()
        {
            if (HasInventoryItem<BentSword>())
            {
                userInterfaces.Current.ShowTextBox(Strings.LlewellaTalk3);
            }
            else if (campaigns.Current.Player.HasInventoryItem<BentSword>())
            {
                userInterfaces.Current.ShowTextBox(Strings.LlewellaTalk1);
                AddInventoryItem<BentSword>();
                campaigns.Current.Player.RemoveInventoryItem<BentSword>();
            }
            else
            {
                userInterfaces.Current.ShowTextBox(Strings.LlewellaTalk2);
            }
        }
    }
}
