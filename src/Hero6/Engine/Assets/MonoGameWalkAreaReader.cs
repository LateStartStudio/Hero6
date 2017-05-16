// <copyright file="MonoGameWalkAreaReader.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets
{
    using System.Collections.Generic;

    using LateStartStudio.Hero6.Engine.Campaigns.Regions;
    using LateStartStudio.Search.Pathfinder;

    using Microsoft.Xna.Framework.Content;

    using TRead = LateStartStudio.Hero6.Engine.Campaigns.Regions.WalkAreas;

    public class MonoGameWalkAreaReader : ContentTypeReader<TRead>
    {
        protected override TRead Read(ContentReader input, TRead existingInstance)
        {
            int walkAreasCount = input.ReadInt32();
            IList<WalkArea> areas = new List<WalkArea>(walkAreasCount);

            for (int i = 0; i < walkAreasCount; i++)
            {
                int width = input.ReadInt32();
                int height = input.ReadInt32();
                int nodeCount = input.ReadInt32();

                IDictionary<int, Node> nodes = new Dictionary<int, Node>();

                for (int j = 0; j < nodeCount; j++)
                {
                    int id = input.ReadInt32();

                    nodes.Add(id, new Node(id));
                }

                foreach (KeyValuePair<int, Node> node in nodes)
                {
                    int childrenCount = input.ReadInt32();

                    for (int k = 0; k < childrenCount; k++)
                    {
                        int id = input.ReadInt32();

                        nodes[node.Key].Children.Add(nodes[id]);
                    }
                }

                areas.Add(new WalkArea(width, height, nodes));
            }

            return new TRead(areas);
        }
    }
}
