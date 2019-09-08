// <copyright file="MonoGameCampaignController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using LateStartStudio.Hero6.Engine.Campaigns.Animations;
using LateStartStudio.Hero6.Engine.Campaigns.Characters;
using LateStartStudio.Hero6.Engine.Campaigns.InventoryItems;
using LateStartStudio.Hero6.Engine.Campaigns.Items;
using LateStartStudio.Hero6.Engine.Campaigns.Rooms;
using LateStartStudio.Hero6.Engine.GameLoop;
using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;
using Microsoft.Xna.Framework;

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    public class MonoGameCampaignController : CampaignController, IXnaGameLoop
    {
        private readonly IServices services;

        private MonoGameRoomController currentRoom;

        public MonoGameCampaignController(CampaignModule module, IServices services)
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

        public override CharacterController Player { get; set; }

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
            foreach (var type in Module.GenerateAnimations())
            {
                Animations[type] = new MonoGameAnimationController(services.Make<AnimationModule>(type), services);
            }

            foreach (var type in Module.GenerateCharacterAnimations())
            {
                CharacterAnimations[type] = new MonoGameCharacterAnimationController(services.Make<CharacterAnimationModule>(type), services);
            }

            foreach (var type in Module.GenerateCharacters())
            {
                Characters[type] = new MonoGameCharacterController(services.Make<CharacterModule>(type), services);
            }

            foreach (var type in Module.GenerateItems())
            {
                Items[type] = new MonoGameItemController(services.Make<ItemModule>(type), services);
            }

            foreach (var type in Module.GenerateInventoryItems())
            {
                InventoryItems[type] = new MonoGameInventoryItemController(services.Make<InventoryItemModule>(type), services);
            }

            foreach (var type in Module.GenerateRooms())
            {
                Rooms[type] = new MonoGameRoomController(services.Make<RoomModule>(type), services);
            }

            PreInitialize();
            Animations.Values.ToList().ForEach(a => a.PreInitialize());
            CharacterAnimations.Values.ToList().ForEach(c => c.PreInitialize());
            Characters.Values.ToList().ForEach(c => c.PreInitialize());
            Items.Values.ToList().ForEach(i => i.PreInitialize());
            InventoryItems.Values.ToList().ForEach(i => i.PreInitialize());
            Rooms.Values.ToList().ForEach(r => r.PreInitialize());

            Animations.Values.Select(a => a as IXnaGameLoop).ToList().ForEach(a => a.Initialize());
            CharacterAnimations.Values.Select(c => c as IXnaGameLoop).ToList().ForEach(c => c.Initialize());
            Characters.Values.Select(c => c as IXnaGameLoop).ToList().ForEach(c => c.Initialize());
            Items.Values.Select(i => i as IXnaGameLoop).ToList().ForEach(i => i.Initialize());
            InventoryItems.Values.Select(i => i as IXnaGameLoop).ToList().ForEach(i => i.Initialize());
            Rooms.Values.Select(r => r as IXnaGameLoop).ToList().ForEach(r => r.Initialize());
        }

        public void Load()
        {
            Animations.Values.ToList().ForEach(a => a.Load());
            CharacterAnimations.Values.ToList().ForEach(c => c.Load());
            Characters.Values.ToList().ForEach(c => c.Load());
            Items.Values.ToList().ForEach(i => i.Load());
            InventoryItems.Values.ToList().ForEach(i => i.Load());
            Rooms.Values.ToList().ForEach(r => r.Load());
            Initialize();
        }

        public void Unload()
        {
            Animations.Values.ToList().ForEach(a => a.Unload());
            CharacterAnimations.Values.ToList().ForEach(c => c.Unload());
            Rooms.Values.ToList().ForEach(r => r.Unload());
            Characters.Values.ToList().ForEach(c => c.Unload());
            Items.Values.ToList().ForEach(i => i.Unload());
            InventoryItems.Values.ToList().ForEach(i => i.Unload());
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
