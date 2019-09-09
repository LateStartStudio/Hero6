// <copyright file="RitesOfPassageModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using System.Collections.Generic;
using LateStartStudio.Hero6.Campaigns.RitesOfPassage.Animations.Characters.Hero.Idle;
using LateStartStudio.Hero6.Campaigns.RitesOfPassage.Animations.Characters.Hero.Walk;
using LateStartStudio.Hero6.Campaigns.RitesOfPassage.Animations.Characters.Llewella.Idle;
using LateStartStudio.Hero6.Campaigns.RitesOfPassage.Characters;
using LateStartStudio.Hero6.Campaigns.RitesOfPassage.InventoryItems;
using LateStartStudio.Hero6.Campaigns.RitesOfPassage.Rooms.Albion;
using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Animations.Characters.Hero.Idle;
using LateStartStudio.Hero6.ModuleController.Campaigns;
using LateStartStudio.Hero6.Services.Campaigns;

namespace LateStartStudio.Hero6.Campaigns.RitesOfPassage
{
    public class RitesOfPassageModule : CampaignModule
    {
        private readonly ICampaigns campaigns;

        public RitesOfPassageModule(ICampaigns campaigns)
        {
            this.campaigns = campaigns;
        }

        public override string Name => "Rites of Passage";

        public override int StatCap => 100;

        public override IEnumerable<Type> GenerateAnimations()
        {
            yield return typeof(HeroIdleCenterDown);
            yield return typeof(HeroIdleCenterUp);
            yield return typeof(HeroIdleLeftCenter);
            yield return typeof(HeroIdleLeftDown);
            yield return typeof(HeroIdleLeftUp);
            yield return typeof(HeroIdleRightCenter);
            yield return typeof(HeroIdleRightDown);
            yield return typeof(HeroIdleRightUp);
            yield return typeof(HeroWalkCenterDown);
            yield return typeof(HeroWalkCenterUp);
            yield return typeof(HeroWalkLeftCenter);
            yield return typeof(HeroWalkLeftDown);
            yield return typeof(HeroWalkLeftUp);
            yield return typeof(HeroWalkRightCenter);
            yield return typeof(HeroWalkRightDown);
            yield return typeof(HeroWalkRightUp);
            yield return typeof(LllewellaIdleCenterDown);
        }

        public override IEnumerable<Type> GenerateCharacterAnimations()
        {
            yield return typeof(HeroIdle);
            yield return typeof(HeroWalk);
            yield return typeof(LlewellaIdle);
        }

        public override IEnumerable<Type> GenerateRooms()
        {
            yield return typeof(HillOverAlbion);
            yield return typeof(Fountain);
        }

        public override IEnumerable<Type> GenerateCharacters()
        {
            yield return typeof(Hero);
            yield return typeof(Llewella);
        }

        public override IEnumerable<Type> GenerateItems()
        {
            yield return typeof(Items.BentSword);
        }

        public override IEnumerable<Type> GenerateInventoryItems()
        {
            yield return typeof(BentSword);
        }

        public override void Initialize()
        {
            base.Initialize();
            campaigns.Current.GetCharacter<Hero>().SetAsPlayer();
        }
    }
}
