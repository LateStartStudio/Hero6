// <copyright file="Writer.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.MonoGamePipeline.WalkAreas
{
    using System.Linq;
    using Microsoft.Xna.Framework.Content.Pipeline;
    using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

    /// <summary>
    /// Binary writer for the walk areas that converts the image masks into .xnb format.
    /// </summary>
    [ContentTypeWriter]
    public class Writer : ContentTypeWriter<MonoGameWalkAreasModule>
    {
        /// <inheritdoc />
        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "LateStartStudio.Hero6.Engine.Assets.MonoGameWalkAreaReader, Hero6";
        }

        /// <inheritdoc />
        protected override void Write(ContentWriter output, MonoGameWalkAreasModule value)
        {
            output.Write(value.Areas.Count());

            foreach (var area in value.Areas)
            {
                output.Write(area.Width);
                output.Write(area.Height);
                output.Write(area.Nodes.Count);

                foreach (var node in area.Nodes)
                {
                    output.Write(node.Value.ID);
                }

                foreach (var node in area.Nodes)
                {
                    output.Write(node.Value.Children.Count);

                    foreach (var child in node.Value.Children)
                    {
                        output.Write(child.ID);
                    }
                }
            }
        }
    }
}
