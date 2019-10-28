// <copyright file="MonoGameCampaignController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using LateStartStudio.Hero6.ModuleController.Campaigns.Animations;
using LateStartStudio.Hero6.ModuleController.Campaigns.Characters;
using LateStartStudio.Hero6.ModuleController.Campaigns.Characters.InventoryItems;
using LateStartStudio.Hero6.ModuleController.Campaigns.Characters.Items;
using LateStartStudio.Hero6.ModuleController.Campaigns.InventoryItems;
using LateStartStudio.Hero6.ModuleController.Campaigns.Items;
using LateStartStudio.Hero6.ModuleController.Campaigns.Rooms;
using LateStartStudio.Hero6.MonoGame.GameLoop;
using LateStartStudio.Hero6.Services.DependencyInjection;
using Microsoft.Xna.Framework;

namespace LateStartStudio.Hero6.ModuleController.Campaigns
{
    public class MonoGameCampaignController : CampaignController, IXnaGameLoop
    {
        private readonly IServiceLocator services;

        private MonoGameRoomController currentRoom;

        public MonoGameCampaignController(ICampaignModule module, IServiceLocator services)
            : base(module, services)
        {
            this.services = services;
        }

        public IDictionary<Type, MonoGameAnimationController> Animations { get; } = new Dictionary<Type, MonoGameAnimationController>();

        public IDictionary<Type, MonoGameCharacterAnimationController> CharacterAnimations { get; } = new Dictionary<Type, MonoGameCharacterAnimationController>();

        public IDictionary<Type, MonoGameRoomController> Rooms { get; } = new Dictionary<Type, MonoGameRoomController>();

        public IDictionary<Type, MonoGameCharacterController> Characters { get; } = new Dictionary<Type, MonoGameCharacterController>();

        public IDictionary<Type, MonoGameItemController> Items { get; } = new Dictionary<Type, MonoGameItemController>();

        public IDictionary<Type, MonoGameInventoryItemController> InventoryItems { get; } = new Dictionary<Type, MonoGameInventoryItemController>();

        public override int Width => currentRoom?.Width ?? 0;

        public override int Height => currentRoom?.Height ?? 0;

        public override ICharacterController Player { get; set; }

        public override bool Interact(int x, int y, Interaction interaction)
        {
            return currentRoom.Interact(x, y, interaction);
        }

        public override AnimationController GetAnimation<T>() => Animations[typeof(T)];

        public override CharacterAnimationController GetCharacterAnimation<T>() => CharacterAnimations[typeof(T)];

        public override CharacterController GetCharacter<T>() => Characters[typeof(T)];

        public override ItemController GetItem<T>() => Items[typeof(T)];

        public override InventoryItemController GetInventoryItem<T>() => InventoryItems[typeof(T)];

        public override RoomController GetRoom<T>() => Rooms[typeof(T)];

        void IXnaGameLoop.Initialize()
        {
            FindModules<AnimationModule>().ForEach(a => Animations.Add(a, new MonoGameAnimationController(services.Make<AnimationModule>(a), services)));
            FindModules<CharacterAnimationModule>().ForEach(a => CharacterAnimations.Add(a, new MonoGameCharacterAnimationController(services.Make<CharacterAnimationModule>(a), services)));
            FindModules<CharacterModule>().ForEach(a => Characters.Add(a, new MonoGameCharacterController(services.Make<CharacterModule>(a), services)));
            FindModules<ItemModule>().ForEach(a => Items.Add(a, new MonoGameItemController(services.Make<ItemModule>(a), services)));
            FindModules<InventoryItemModule>().ForEach(a => InventoryItems.Add(a, new MonoGameInventoryItemController(services.Make<InventoryItemModule>(a), services)));
            FindModules<RoomModule>().ForEach(a => Rooms.Add(a, new MonoGameRoomController(services.Make<RoomModule>(a), services)));

            PreInitialize();
            Animations.Values.ForEach(a => a.PreInitialize());
            CharacterAnimations.Values.ForEach(c => c.PreInitialize());
            Characters.Values.ForEach(c => c.PreInitialize());
            Items.Values.ForEach(i => i.PreInitialize());
            InventoryItems.Values.ForEach(i => i.PreInitialize());
            Rooms.Values.ForEach(r => r.PreInitialize());

            Animations.Values.Select(a => a as IXnaGameLoop).ForEach(a => a.Initialize());
            CharacterAnimations.Values.Select(c => c as IXnaGameLoop).ForEach(c => c.Initialize());
            Characters.Values.Select(c => c as IXnaGameLoop).ForEach(c => c.Initialize());
            Items.Values.Select(i => i as IXnaGameLoop).ForEach(i => i.Initialize());
            InventoryItems.Values.Select(i => i as IXnaGameLoop).ForEach(i => i.Initialize());
            Rooms.Values.Select(r => r as IXnaGameLoop).ForEach(r => r.Initialize());
        }

        public void Load()
        {
            Animations.Values.ForEach(a => a.Load());
            CharacterAnimations.Values.ForEach(c => c.Load());
            Characters.Values.ForEach(c => c.Load());
            Items.Values.ForEach(i => i.Load());
            InventoryItems.Values.ForEach(i => i.Load());
            Rooms.Values.ForEach(r => r.Load());
            Initialize();
        }

        public void Unload()
        {
            Animations.Values.ForEach(a => a.Unload());
            CharacterAnimations.Values.ForEach(c => c.Unload());
            Rooms.Values.ForEach(r => r.Unload());
            Characters.Values.ForEach(c => c.Unload());
            Items.Values.ForEach(i => i.Unload());
            InventoryItems.Values.ForEach(i => i.Unload());
        }

        public void Update(GameTime time)
        {
            currentRoom = Rooms.Values.Single(r => r.Characters.Any(c => c.IsPlayer));
            currentRoom.Update(time);
        }

        public void Draw(GameTime time)
        {
            currentRoom.Draw(time);
        }
    }
}
