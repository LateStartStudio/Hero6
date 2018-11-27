// <copyright file="MonoGameWalkAreasController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions
{
    using System.Collections.Generic;
    using System.Linq;
    using LateStartStudio.Hero6.Engine.GameLoop;
    using LateStartStudio.Hero6.MonoGamePipeline.WalkAreas;
    using Microsoft.Xna.Framework;

    public class MonoGameWalkAreasController : WalkAreasController, IXnaGameLoop
    {
        private readonly MonoGameWalkAreasModule monoGameWalkAreasModule;

        public MonoGameWalkAreasController(WalkAreasModule module)
            : base(module)
        {
            monoGameWalkAreasModule = (MonoGameWalkAreasModule)module;
        }

        public override int Width { get; }

        public override int Height { get; }

        public override bool Interact(int x, int y, Interaction interaction)
        {
            throw new System.NotImplementedException();
        }

        void IXnaGameLoop.Initialize()
        {
        }

        public void Load()
        {
            Initialize();
        }

        public void Unload()
        {
        }

        public void Update(GameTime time)
        {
        }

        public void Draw(GameTime time)
        {
        }

        public IEnumerable<Point> GetPath(Point start, Point end)
        {
            foreach (var area in monoGameWalkAreasModule.Areas)
            {
                if (
                    !area.Nodes.ContainsKey((start.Y * area.Width) + start.X) ||
                    !area.Nodes.ContainsKey((end.Y * area.Width) + end.X))
                {
                    continue;
                }

                return area.GetPath(start.ToDotNet(), end.ToDotNet()).Select(p => p.ToMonoGame());
            }

            return null;
        }
    }
}
