// <copyright file="CampaignController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using LateStartStudio.Hero6.Extensions;
using LateStartStudio.Hero6.ModuleController.Campaigns.Animations;
using LateStartStudio.Hero6.ModuleController.Campaigns.Characters;
using LateStartStudio.Hero6.ModuleController.Campaigns.InventoryItems;
using LateStartStudio.Hero6.ModuleController.Campaigns.Items;
using LateStartStudio.Hero6.ModuleController.Campaigns.Rooms;
using LateStartStudio.Hero6.Services.DependencyInjection;
using Microsoft.Xna.Framework;

namespace LateStartStudio.Hero6.ModuleController.Campaigns
{
    /// <summary>
    /// API for a campaign controller.
    /// </summary>
    public class CampaignController : GameController<ICampaignController, ICampaignModule>, ICampaignController
    {
        private readonly IServiceLocator services;

        private RoomController currentRoom;

        /// <summary>
        /// Creates a new instance of the <see cref="CampaignController"/> instance.
        /// </summary>
        /// <param name="module">The module corresponding to this controller.</param>
        public CampaignController(ICampaignModule module, IServiceLocator services)
            : base(module, services)
        {
            this.services = services;
        }

        public IDictionary<Type, AnimationController> Animations { get; } = new Dictionary<Type, AnimationController>();

        public IDictionary<Type, CharacterAnimationController> CharacterAnimations { get; } = new Dictionary<Type, CharacterAnimationController>();

        public IDictionary<Type, RoomController> Rooms { get; } = new Dictionary<Type, RoomController>();

        public IDictionary<Type, CharacterController> Characters { get; } = new Dictionary<Type, CharacterController>();

        public IDictionary<Type, ItemController> Items { get; } = new Dictionary<Type, ItemController>();

        public IDictionary<Type, InventoryItemController> InventoryItems { get; } = new Dictionary<Type, InventoryItemController>();

        public override int Width => currentRoom?.Width ?? 0;

        public override int Height => currentRoom?.Height ?? 0;

        public ICharacterController Player { get; set; }

        public override bool Interact(int x, int y, Interaction interaction)
        {
            return currentRoom.Interact(x, y, interaction);
        }

        public AnimationController GetAnimation<T>() where T : IAnimationModule => Animations[typeof(T)];

        public CharacterAnimationController GetCharacterAnimation<T>() where T : ICharacterAnimationModule => CharacterAnimations[typeof(T)];

        public CharacterController GetCharacter<T>() where T : ICharacterModule => Characters[typeof(T)];

        public ItemController GetItem<T>() where T : IItemModule => Items[typeof(T)];

        public InventoryItemController GetInventoryItem<T>() where T : IInventoryItemModule => InventoryItems[typeof(T)];

        public RoomController GetRoom<T>() where T : IRoomModule => Rooms[typeof(T)];

        public override void Initialize()
        {
            FindModules<AnimationModule>().ForEach(a => Animations.Add(a, new AnimationController(services.Make<AnimationModule>(a), services)));
            FindModules<CharacterAnimationModule>().ForEach(a => CharacterAnimations.Add(a, new CharacterAnimationController(services.Make<CharacterAnimationModule>(a), services)));
            FindModules<CharacterModule>().ForEach(a => Characters.Add(a, new CharacterController(services.Make<CharacterModule>(a), services)));
            FindModules<ItemModule>().ForEach(a => Items.Add(a, new ItemController(services.Make<ItemModule>(a), services)));
            FindModules<InventoryItemModule>().ForEach(a => InventoryItems.Add(a, new InventoryItemController(services.Make<InventoryItemModule>(a), services)));
            FindModules<RoomModule>().ForEach(a => Rooms.Add(a, new RoomController(services.Make<RoomModule>(a), services)));

            PreInitialize();
            Animations.Values.ForEach(a => a.PreInitialize());
            CharacterAnimations.Values.ForEach(c => c.PreInitialize());
            Characters.Values.ForEach(c => c.PreInitialize());
            Items.Values.ForEach(i => i.PreInitialize());
            InventoryItems.Values.ForEach(i => i.PreInitialize());
            Rooms.Values.ForEach(r => r.PreInitialize());

            Animations.Values.ForEach(a => a.Initialize());
            CharacterAnimations.Values.ForEach(c => c.Initialize());
            Characters.Values.ForEach(c => c.Initialize());
            Items.Values.ForEach(i => i.Initialize());
            InventoryItems.Values.ForEach(i => i.Initialize());
            Rooms.Values.ForEach(r => r.Initialize());

            base.Initialize();
        }

        public override void Load()
        {
            Animations.Values.ForEach(a => a.Load());
            CharacterAnimations.Values.ForEach(c => c.Load());
            Characters.Values.ForEach(c => c.Load());
            Items.Values.ForEach(i => i.Load());
            InventoryItems.Values.ForEach(i => i.Load());
            Rooms.Values.ForEach(r => r.Load());
        }

        public override void Unload()
        {
            Animations.Values.ForEach(a => a.Unload());
            CharacterAnimations.Values.ForEach(c => c.Unload());
            Rooms.Values.ForEach(r => r.Unload());
            Characters.Values.ForEach(c => c.Unload());
            Items.Values.ForEach(i => i.Unload());
            InventoryItems.Values.ForEach(i => i.Unload());
        }

        public override void Update(GameTime time)
        {
            currentRoom = Rooms.Values.Single(r => r.Characters.Any(c => c.IsPlayer));
            currentRoom.Update(time);
        }

        public override void Draw(GameTime time)
        {
            currentRoom.Draw(time);
        }
    }
}
