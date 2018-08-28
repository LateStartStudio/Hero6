// <copyright file="MonoGameRoomController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Rooms
{
    using System.Collections.Generic;
    using System.Linq;
    using LateStartStudio.Hero6.Engine.Assets;
    using LateStartStudio.Hero6.Engine.Assets.Graphics;
    using LateStartStudio.Hero6.Engine.Campaigns.Characters;
    using LateStartStudio.Hero6.Engine.Campaigns.Items;
    using LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions;
    using LateStartStudio.Hero6.Engine.GameLoop;
    using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;
    using Microsoft.Xna.Framework;
    using Point = LateStartStudio.Hero6.Engine.Assets.Graphics.Point;

    public class MonoGameRoomController : RoomController, IXnaGameLoop
    {
        private readonly IRenderer renderer;
        private readonly ICampaigns campaigns;
        private readonly IAssets assets;
        private readonly List<MonoGameCharacterController> characters = new List<MonoGameCharacterController>();
        private readonly List<MonoGameItemController> items = new List<MonoGameItemController>();
        private readonly MonoGameHotspotsController hotspots;

        private Texture2D background;
        private MonoGameWalkAreasController walkAreas;

        public MonoGameRoomController(RoomModule module, IServices services, IAssets assets)
            : base(module)
        {
            renderer = services.Get<IRenderer>();
            campaigns = services.Get<ICampaigns>();
            this.assets = assets;
            hotspots = new MonoGameHotspotsController(Module.HotspotsMask, assets);
        }

        public override int Width => background.Width;

        public override int Height => background.Height;

        public override IEnumerable<CharacterController> Characters => characters;

        public override WalkAreasController WalkAreas => walkAreas;

        public override HotspotsController Hotspots => hotspots;

        public override void AddCharacter<T>()
        {
            characters.Add(campaigns.AsMonoGame().CurrentController.Characters[typeof(T)]);
        }

        public void AddCharacter(MonoGameCharacterController character)
        {
            characters.Add(character);
        }

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

        void IXnaGameLoop.Initialize()
        {
            PreInitialize();
        }

        public void Load()
        {
            background = assets.LoadTexture2D(Module.Background);
            walkAreas = new MonoGameWalkAreasController(assets.LoadWalkAreas(Module.WalkAreasMask));
            walkAreas.PreInitialize();
            walkAreas.Initialize();
            walkAreas.Load();
            hotspots.PreInitialize();
            hotspots.Initialize();
            hotspots.Load();
            Initialize();
        }

        public void Unload()
        {
            characters.ForEach(c => c.Unload());
            items.ForEach(i => i.Unload());
            walkAreas.Unload();
            hotspots.Unload();
        }

        public void Update(GameTime time)
        {
            foreach (var c in characters)
            {
                c.Update(time);
                hotspots.StandingOn(c);
            }

            items.ForEach(i => i.Update(time));
            walkAreas.Update(time);
            hotspots.Update(time);
        }

        public void Draw(GameTime time)
        {
            if (Module.IsVisible)
            {
                renderer.Draw(background, new Point(Module.X, Module.Y));
            }

            characters.ForEach(c => c.Draw(time));
            items.ForEach(i => i.Draw(time));
            walkAreas.Draw(time);
            hotspots.Draw(time);
        }
    }
}
