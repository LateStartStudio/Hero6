// <copyright file="RitesOfPassageServicesProvider.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage
{
    using System.Collections.Generic;
    using LateStartStudio.Hero6.Engine.Assets.Graphics;
    using LateStartStudio.Hero6.Engine.Campaigns.Animations;
    using LateStartStudio.Hero6.Engine.Campaigns.Characters;
    using LateStartStudio.Hero6.Engine.Campaigns.InventoryItems;
    using LateStartStudio.Hero6.Engine.Campaigns.Items;
    using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Animations.Characters.Hero.Idle;
    using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Animations.Characters.Hero.Walk;
    using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Animations.Characters.Llewella.Idle;
    using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Characters;
    using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Items;
    using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Rooms.Albion;
    using LateStartStudio.Hero6.Engine.Campaigns.Rooms;
    using LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions;
    using LateStartStudio.Hero6.Engine.ModuleController;
    using LateStartStudio.Hero6.Tests.HelperTools;
    using NSubstitute;

    public class RitesOfPassageServicesProvider : ServicesProvider
    {
        private readonly List<IController> controllers = new List<IController>();

        public RitesOfPassageServicesProvider()
        {
            Campaigns = Substitute.For<ICampaigns>();
            var module = new RitesOfPassageModule(Campaigns);
            Campaigns.Current = module;
            CampaignController = Substitute.For<CampaignController>(module);
            controllers.Add(CampaignController);

            // Animations
            MakeAnimation<HeroIdleCenterDown>(new HeroIdleCenterDown());
            MakeAnimation<HeroIdleCenterUp>(new HeroIdleCenterUp());
            MakeAnimation<HeroIdleLeftCenter>(new HeroIdleLeftCenter());
            MakeAnimation<HeroIdleLeftDown>(new HeroIdleLeftDown());
            MakeAnimation<HeroIdleLeftUp>(new HeroIdleLeftUp());
            MakeAnimation<HeroIdleRightCenter>(new HeroIdleRightCenter());
            MakeAnimation<HeroIdleRightDown>(new HeroIdleRightDown());
            MakeAnimation<HeroIdleRightUp>(new HeroIdleRightUp());

            MakeAnimation<HeroWalkCenterDown>(new HeroWalkCenterDown());
            MakeAnimation<HeroWalkCenterUp>(new HeroWalkCenterUp());
            MakeAnimation<HeroWalkLeftCenter>(new HeroWalkLeftCenter());
            MakeAnimation<HeroWalkLeftDown>(new HeroWalkLeftDown());
            MakeAnimation<HeroWalkLeftUp>(new HeroWalkLeftUp());
            MakeAnimation<HeroWalkRightCenter>(new HeroWalkRightCenter());
            MakeAnimation<HeroWalkRightDown>(new HeroWalkRightDown());
            MakeAnimation<HeroWalkRightUp>(new HeroWalkRightUp());

            MakeAnimation<LllewellaIdleCenterDown>(new LllewellaIdleCenterDown());

            // Character Animations
            MakeCharacterAnimation<HeroIdle>(new HeroIdle(Campaigns));
            MakeCharacterAnimation<HeroWalk>(new HeroWalk(Campaigns));
            MakeCharacterAnimation<LlewellaIdle>(new LlewellaIdle(Campaigns));

            // Characters
            MakeCharacter<Hero>(new Hero(UserInterfaces, Campaigns));
            MakeCharacter<Llewella>(new Llewella(UserInterfaces, Campaigns));

            // Items
            MakeItem<BentSword>(new BentSword(UserInterfaces, Campaigns));

            // Inventory Items
            MakeInventoryItem<InventoryItems.BentSword>(new InventoryItems.BentSword());

            // Rooms
            MakeRoom<Fountain>(new Fountain(Campaigns, UserInterfaces));
            MakeRoom<HillOverAlbion>(new HillOverAlbion(Campaigns, UserInterfaces));

            controllers.ForEach(c =>
            {
                (c as RoomController)?.Hotspots.PreInitialize();
                c.PreInitialize();
            });

            controllers.ForEach(c =>
            {
                (c as RoomController)?.Hotspots.Initialize();
                c.Initialize();
            });
        }

        public CampaignController CampaignController { get; }

        private void MakeAnimation<T>(AnimationModule module)
            where T : AnimationModule
        {
            var controller = MakeController<AnimationController, AnimationModule>(module);
            CampaignController.GetAnimation<T>().Returns(controller);
        }

        private void MakeCharacterAnimation<T>(CharacterAnimationModule module)
            where T : CharacterAnimationModule
        {
            var controller = MakeController<CharacterAnimationController, CharacterAnimationModule>(module);
            CampaignController.GetCharacterAnimation<T>().Returns(controller);
        }

        private void MakeCharacter<T>(CharacterModule module)
            where T : CharacterModule
        {
            var controller = MakeController<CharacterController, CharacterModule>(module);
            controller.When(c => c.SetAsPlayer()).Do(c => Campaigns.Current.Player = controller);
            CampaignController.GetCharacter<T>().Returns(controller);
        }

        private void MakeItem<T>(ItemModule module)
            where T : ItemModule
        {
            var controller = MakeController<ItemController, ItemModule>(module);
            CampaignController.GetItem<T>().Returns(controller);
        }

        private void MakeInventoryItem<T>(InventoryItemModule module)
            where T : InventoryItemModule
        {
            var controller = MakeController<InventoryItemController, InventoryItemModule>(module);
            CampaignController.GetInventoryItem<T>().Returns(controller);
        }

        private void MakeRoom<T>(RoomModule module)
            where T : RoomModule
        {
            var controller = MakeController<RoomController, RoomModule>(module);
            var hotspots = Substitute.For<HotspotsController>();
            var hotspotsBuffer = new Dictionary<Color, Hotspot>();
            hotspots[Arg.Any<Color>()].Returns(x =>
            {
                if (!hotspotsBuffer.ContainsKey(x.Arg<Color>()))
                {
                    hotspotsBuffer[x.Arg<Color>()] = Substitute.For<Hotspot>();
                }

                return hotspotsBuffer[x.Arg<Color>()];
            });
            controller.Hotspots.Returns(hotspots);
            CampaignController.GetRoom<T>().Returns(controller);
        }

        private TController MakeController<TController, TModule>(TModule module)
            where TController : GameController<TController, TModule>
            where TModule : GameModule<TController>
        {
            var controller = Substitute.For<TController>(module);
            controllers.Add(controller);
            return controller;
        }
    }
}
