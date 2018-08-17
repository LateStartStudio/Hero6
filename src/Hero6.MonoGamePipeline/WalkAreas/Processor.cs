// <copyright file="Processor.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.MonoGamePipeline.WalkAreas
{
    using System.Collections.Generic;
    using System.Drawing;
    using LateStartStudio.Hero6.Engine.Assets.Graphics;
    using LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions;
    using LateStartStudio.Search.Pathfinder;
    using Microsoft.Xna.Framework.Content.Pipeline;

    /// <summary>
    /// Processes walk areas from image masks to actual usable data. Iterates through each image
    /// mask pixel-by-pixel and converts each pixel into a node to be used with the pathfinder.
    /// </summary>
    [ContentProcessor(DisplayName = "Walk Area Processor - Hero6")]
    public class Processor : ContentProcessor<string[], WalkAreasModule>
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
        public override WalkAreasModule Process(string[] input, ContentProcessorContext context)
        {
            var areas = new List<WalkArea>();

            foreach (var file in input)
            {
                var bmp = new Bitmap(Image.FromFile(file));
                areas.Add(new WalkArea(bmp.Width, bmp.Height, GetNodesFromMap(bmp)));
            }

            return new MonoGameWalkAreasModule(areas);
        }

        private static IDictionary<int, Node> GetNodesFromMap(Bitmap input)
        {
            var nodes = new Dictionary<int, Node>();

            for (var y = 0; y < input.Height; y++)
            {
                for (var x = 0; x < input.Width; x++)
                {
                    if (input.GetPixel(x, y).A == 0)
                    {
                        continue;
                    }

                    var id = (y * input.Width) + x;
                    nodes.Add(id, new Node(id));
                }
            }

            foreach (var node in nodes)
            {
                node.Value.Children = FindNeighbors(node.Value, nodes, input.Width, input.Height);
            }

            return nodes;
        }

        private static IList<Node> FindNeighbors(Node node, IDictionary<int, Node> nodes, int width, int height)
        {
            var neighbors = new List<Node>();

            foreach (var vector in DirectionVectors)
            {
                var x = (node.ID % width) + (int)vector.X;
                var y = (node.ID / width) + (int)vector.Y;

                if (x < 0 || x >= width || y < 0 || y >= height)
                {
                    continue;
                }

                var id = (y * width) + x;

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
