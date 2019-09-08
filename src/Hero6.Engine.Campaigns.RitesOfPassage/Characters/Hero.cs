// <copyright file="Hero.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Engine.Campaigns.Characters;
using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Animations.Characters.Hero.Idle;
using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Animations.Characters.Hero.Walk;
using LateStartStudio.Hero6.Engine.UserInterfaces;
using LateStartStudio.Hero6.Localization;

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Characters
{
    public sealed class Hero : CharacterModule
    {
        private readonly IUserInterfaces userInterfaces;
        private readonly ICampaigns campaigns;

        public Hero(IUserInterfaces userInterfaces, ICampaigns campaigns)
        {
            this.userInterfaces = userInterfaces;
            this.campaigns = campaigns;
        }

        public override string Name => "Hero";

        public override void Initialize()
        {
            base.Initialize();
            IdleAnimation = campaigns.Current.GetCharacterAnimation<HeroIdle>();
            MoveAnimation = campaigns.Current.GetCharacterAnimation<HeroWalk>();
            Look = OnLook;
            Grab = OnGrab;
            Talk = OnTalk;
        }

        private void OnLook()
        {
            userInterfaces.Current.ShowTextBox(Strings.HeroLook);
        }

        private void OnGrab()
        {
            userInterfaces.Current.ShowTextBox(Strings.HeroGrab);
        }

        private void OnTalk()
        {
            userInterfaces.Current.ShowTextBox(Strings.HeroTalk);
        }
    }
}
