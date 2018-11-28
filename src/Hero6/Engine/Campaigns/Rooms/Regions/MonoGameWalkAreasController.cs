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
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;

    public class MonoGameWalkAreasController : WalkAreasController, IXnaGameLoop
    {
        private readonly string source;
        private readonly ContentManager content;
        private readonly List<WalkArea> walkAreas = new List<WalkArea>();

        public MonoGameWalkAreasController(string source, ContentManager content)
            : base()
        {
            this.source = source;
            this.content = content;
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
            walkAreas.AddRange(content.Load<IEnumerable<WalkArea>>(source));
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
