// <copyright file="MonoGameWalkAreaReader.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets
{
    using System.Collections.Generic;
    using LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions;
    using LateStartStudio.Hero6.MonoGamePipeline.WalkAreas;
    using LateStartStudio.Search.Pathfinder;
    using Microsoft.Xna.Framework.Content;

    public class MonoGameWalkAreaReader : ContentTypeReader<WalkAreasModule>
    {
        protected override WalkAreasModule Read(ContentReader input, WalkAreasModule existingInstance)
        {
            var walkAreasCount = input.ReadInt32();
            var areas = new List<WalkArea>(walkAreasCount);

            for (var i = 0; i < walkAreasCount; i++)
            {
                var width = input.ReadInt32();
                var height = input.ReadInt32();
                var nodeCount = input.ReadInt32();
                var nodes = new Dictionary<int, Node>();

                for (var j = 0; j < nodeCount; j++)
                {
                    var id = input.ReadInt32();
                    nodes.Add(id, new Node(id));
                }

                foreach (var node in nodes)
                {
                    var childrenCount = input.ReadInt32();

                    for (var k = 0; k < childrenCount; k++)
                    {
                        var id = input.ReadInt32();
                        nodes[node.Key].Children.Add(nodes[id]);
                    }
                }

                areas.Add(new WalkArea(width, height, nodes));
            }

            return new MonoGameWalkAreasModule(areas);
        }
    }
}
