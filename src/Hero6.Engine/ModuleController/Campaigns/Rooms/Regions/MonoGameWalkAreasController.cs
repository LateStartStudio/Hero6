// <copyright file="MonoGameWalkAreasController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using LateStartStudio.Hero6.MonoGame.GameLoop;
using LateStartStudio.Hero6.Services.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Rooms.Regions
{
    public class MonoGameWalkAreasController : WalkAreasController, IXnaGameLoop
    {
        private readonly string source;
        private readonly ContentManager content;
        private readonly List<WalkArea> walkAreas = new List<WalkArea>();

        public MonoGameWalkAreasController(string source, IServiceLocator services) : base(services)
        {
            this.source = source;
            this.content = services.Get<ContentManager>();
        }

        public override int Width { get; }

        public override int Height { get; }

        public override bool Interact(int x, int y, Interaction interaction)
        {
            throw new System.NotImplementedException("Walk areas are invisible to the user and should not be interacted with");
        }

        void IXnaGameLoop.Initialize()
        {
        }

        public void Load()
        {
            walkAreas.AddRange(content.Load<List<WalkArea>>(source));
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
            foreach (var area in walkAreas)
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
