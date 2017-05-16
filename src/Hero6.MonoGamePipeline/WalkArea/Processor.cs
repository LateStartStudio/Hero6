// <copyright file="Processor.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.MonoGamePipeline.WalkArea
{
    using System.Collections.Generic;
    using System.Drawing;

    using LateStartStudio.Hero6.Engine.Assets.Graphics;
    using LateStartStudio.Hero6.Engine.Campaigns.Regions;
    using LateStartStudio.Search.Pathfinder;

    using Microsoft.Xna.Framework.Content.Pipeline;

    using TOutput = LateStartStudio.Hero6.Engine.Campaigns.Regions.WalkAreas;

    /// <summary>
    /// Processes walk areas from image masks to actual usable data. Iterates through each image
    /// mask pixel-by-pixel and converts each pixel into a node to be used with the pathfinder.
    /// </summary>
    [ContentProcessor(DisplayName = "Walk Area Processor - Hero6")]
    public class Processor : ContentProcessor<string[], TOutput>
    {
        private static readonly Vector2[] DirectionVectors =
            {
                Vector2.LeftUp,
                Vector2.Up,
                Vector2.RightUp,
                Vector2.Left,
                Vector2.Right,
                Vector2.LeftDown,
                Vector2.Down,
                Vector2.RightDown
            };

        /// <inheritdoc />
        public override TOutput Process(string[] input, ContentProcessorContext context)
        {
            List<WalkArea> areas = new List<WalkArea>();

            foreach (string file in input)
            {
                Bitmap bmp = new Bitmap(Image.FromFile(file));

                areas.Add(new WalkArea(bmp.Width, bmp.Height, GetNodesFromMap(bmp)));
            }

            return new TOutput(areas);
        }

        private static IDictionary<int, Node> GetNodesFromMap(Bitmap input)
        {
            IDictionary<int, Node> nodes = new Dictionary<int, Node>();

            for (int y = 0; y < input.Height; y++)
            {
                for (int x = 0; x < input.Width; x++)
                {
                    if (input.GetPixel(x, y).A == 0)
                    {
                        continue;
                    }

                    int id = (y * input.Width) + x;

                    nodes.Add(id, new Node(id));
                }
            }

            foreach (KeyValuePair<int, Node> node in nodes)
            {
                node.Value.Children = FindNeighbors(node.Value, nodes, input.Width, input.Height);
            }

            return nodes;
        }

        private static IList<Node> FindNeighbors(Node node, IDictionary<int, Node> nodes, int width, int height)
        {
            IList<Node> neighbors = new List<Node>();

            foreach (Vector2 vector in DirectionVectors)
            {
                int x = (node.ID % width) + (int)vector.X;
                int y = (node.ID / width) + (int)vector.Y;

                if (x < 0 || x >= width || y < 0 || y >= height)
                {
                    continue;
                }

                int id = (y * width) + x;

                if (!nodes.ContainsKey(id))
                {
                    continue;
                }

                neighbors.Add(nodes[id]);
            }

            return neighbors;
        }
    }
}
