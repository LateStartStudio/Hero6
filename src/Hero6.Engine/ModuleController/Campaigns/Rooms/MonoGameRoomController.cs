﻿// <copyright file="MonoGameRoomController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using LateStartStudio.Hero6.Extensions;
using LateStartStudio.Hero6.ModuleController.Campaigns.Characters;
using LateStartStudio.Hero6.ModuleController.Campaigns.Characters.Items;
using LateStartStudio.Hero6.ModuleController.Campaigns.Rooms.Regions;
using LateStartStudio.Hero6.MonoGame.GameLoop;
using LateStartStudio.Hero6.Services.Campaigns;
using LateStartStudio.Hero6.Services.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Rooms
{
    public class MonoGameRoomController : RoomController
    {
        private readonly ICampaigns campaigns;
        private readonly ContentManager content;
        private readonly SpriteBatch spriteBatch;
        private readonly List<MonoGameCharacterController> characters = new List<MonoGameCharacterController>();
        private readonly List<MonoGameItemController> items = new List<MonoGameItemController>();
        private readonly MonoGameHotspotsController hotspots;

        private Texture2D background;
        private MonoGameWalkAreasController walkAreas;
        private Vector2 position;

        public MonoGameRoomController(RoomModule module, IServiceLocator services)
            : base(module, services)
        {
            campaigns = services.Get<ICampaigns>();
            content = services.Get<ContentManager>();
            spriteBatch = services.Get<SpriteBatch>();
            walkAreas = new MonoGameWalkAreasController(Module.WalkAreasMask, services);
            hotspots = new MonoGameHotspotsController(Module.HotspotsMask, services);
        }

        public override int Width => background.Width;

        public override int Height => background.Height;

        public override IEnumerable<ICharacterController> Characters => characters;

        public override IWalkAreasController WalkAreas => walkAreas;

        public override IHotspotsController Hotspots => hotspots;

        public override void AddCharacter<T>()
        {
            characters.Add(campaigns.AsMonoGame().CurrentController.Characters[typeof(T)]);
        }

        public void AddCharacter(MonoGameCharacterController character)
        {
            characters.Add(character);
        }

        public override void RemoveCharacter<T>() => characters.Where(c => c.GetType() == typeof(T));

        public override void RemoveCharacter(ICharacterModule character) => RemoveCharacter((MonoGameCharacterController)((CharacterModule)character).Controller);

        public void RemoveCharacter(MonoGameCharacterController character)
        {
            characters.Remove(character);
        }

        public override void AddItem<T>()
        {
            items.Add(campaigns.AsMonoGame().CurrentController.Items[typeof(T)]);
        }

        public override bool Interact(int x, int y, Interaction interaction)
        {
            if (interaction == Interaction.Move)
            {
                campaigns.Current.Player.Walk(x, y);
                return true;
            }

            if (characters.Any(c => c.Interact(x, y, interaction)))
            {
                return true;
            }

            if (items.Any(i => i.Interact(x, y, interaction)))
            {
                return true;
            }

            if (hotspots.Interact(x, y, interaction))
            {
                return true;
            }

            return false;
        }

        public override void Initialize()
        {
            walkAreas.PreInitialize();
            hotspots.PreInitialize();
            walkAreas.Initialize();
            hotspots.Initialize();
        }

        public override void Load()
        {
            background = content.Load<Texture2D>(Module.Background);
            walkAreas.Load();
            hotspots.Load();
            base.Initialize(); // Run base initialize here so it doesn't crash referencing room regions
        }

        public override void Unload()
        {
            characters.ForEach(c => c.Unload());
            items.ForEach(i => i.Unload());
            walkAreas.Unload();
            hotspots.Unload();
        }

        public override void Update(GameTime time)
        {
            foreach (var c in characters.ToArray())
            {
                c.Update(time);
                hotspots.StandingOn(c);
            }

            items.ForEach(i => i.Update(time));
            walkAreas.Update(time);
            hotspots.Update(time);
            position.X = X;
            position.Y = Y;
        }

        public override void Draw(GameTime time)
        {
            if (Module.IsVisible)
            {
                spriteBatch.Draw(background, position, Color.White);
            }

            characters.ForEach(c => c.Draw(time));
            items.ForEach(i => i.Draw(time));
            walkAreas.Draw(time);
            hotspots.Draw(time);
        }
    }
}
