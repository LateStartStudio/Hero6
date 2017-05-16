// <copyright file="Writer.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.MonoGamePipeline.WalkArea
{
    using System.Collections.Generic;
    using System.Linq;

    using LateStartStudio.Hero6.Engine.Campaigns.Regions;
    using LateStartStudio.Search.Pathfinder;

    using Microsoft.Xna.Framework.Content.Pipeline;
    using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

    using TWrite = LateStartStudio.Hero6.Engine.Campaigns.Regions.WalkAreas;

    /// <summary>
    /// Binary writer for the walk areas that converts the image masks into .xnb format.
    /// </summary>
    [ContentTypeWriter]
    public class Writer : ContentTypeWriter<TWrite>
    {
        /// <inheritdoc />
        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "LateStartStudio.Hero6.Engine.Assets.MonoGameWalkAreaReader, Hero6";
        }

        /// <inheritdoc />
        protected override void Write(ContentWriter output, TWrite value)
        {
            output.Write(value.Areas.Count());

            foreach (WalkArea area in value.Areas)
            {
                output.Write(area.Width);
                output.Write(area.Height);
                output.Write(area.Nodes.Count);

                foreach (KeyValuePair<int, Node> node in area.Nodes)
                {
                    output.Write(node.Value.ID);
                }

                foreach (KeyValuePair<int, Node> node in area.Nodes)
                {
                    output.Write(node.Value.Children.Count);

                    foreach (Node child in node.Value.Children)
                    {
                        output.Write(child.ID);
                    }
                }
            }
        }
    }
}
