// <copyright file="RoomController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using LateStartStudio.Hero6.Extensions;
using LateStartStudio.Hero6.ModuleController.Campaigns.Characters;
using LateStartStudio.Hero6.ModuleController.Campaigns.Items;
using LateStartStudio.Hero6.ModuleController.Campaigns.Rooms.Regions;
using LateStartStudio.Hero6.Services.Campaigns;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Rooms
{
    /// <summary>
    /// API for room controller.
    /// </summary>
    public class RoomController : GameController<IRoomController, IRoomModule>, IRoomController
    {
        private readonly ICampaigns campaigns;
        private readonly ContentManager content;
        private readonly SpriteBatch spriteBatch;
        private readonly List<CharacterController> characters = new List<CharacterController>();
        private readonly List<ItemController> items = new List<ItemController>();
        private readonly HotspotsController hotspots;
        private readonly WalkAreasController walkAreas;

        private Texture2D background;
        private Vector2 position;

        /// <summary>
        /// Makes a new <see cref="RoomController"/> instance.
        /// </summary>
        /// <param name="module">The module for this controller.</param>
        public RoomController(IRoomModule module, IServiceProvider services, ICampaigns campaigns, ContentManager content, SpriteBatch spriteBatch)
            : base(module, services)
        {
            this.campaigns = campaigns;
            this.content = content;
            this.spriteBatch = spriteBatch;
            walkAreas = ActivatorUtilities.CreateInstance<WalkAreasController>(services, Module.WalkAreasMask);
            hotspots = ActivatorUtilities.CreateInstance<HotspotsController>(services, Module.HotspotsMask);
        }

        public override int Width => background.Width;

        public override int Height => background.Height;

        public IEnumerable<ICharacterController> Characters => characters;

        public IWalkAreasController WalkAreas => walkAreas;

        public IHotspotsController Hotspots => hotspots;

        public void AddCharacter<T>() where T : ICharacterModule
        {
            characters.Add(campaigns.AsMonoGame().CurrentController.Characters[typeof(T)]);
        }

        public void AddCharacter(CharacterController character)
        {
            characters.Add(character);
        }

        public void RemoveCharacter<T>() where T : ICharacterModule => characters.Where(c => c.GetType() == typeof(T));

        public void RemoveCharacter(ICharacterModule character) => RemoveCharacter((CharacterController)((CharacterModule)character).Controller);

        public void RemoveCharacter(CharacterController character)
        {
            characters.Remove(character);
        }

        public void AddItem<T>() where T : IItemModule
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
