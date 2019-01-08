// <copyright file="Importer.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.MonoGamePipeline.WalkAreas
{
    using System.IO;
    using Microsoft.Xna.Framework.Content.Pipeline;

    /// <summary>
    /// Imports walk areas to the content pipeline builder. Walk areas are stored in the source
    /// code as multiple image masks(.png), and they're all loaded by a master file(.h6walkareas)
    /// which contains a list of all the images masks contained in the same directory.
    /// </summary>
    [ContentImporter(
        ".h6walkareas",
        DisplayName = "Walk Area Importer - Hero6",
        DefaultProcessor = nameof(Processor))]
    public class Importer : ContentImporter<string[]>
    {
        /// <inheritdoc />
        public override string[] Import(string filename, ContentImporterContext context)
        {
            var filenames = File.ReadAllLines(filename);
            var res = new string[filenames.Length];
            var dir = Path.GetDirectoryName(filename) + Path.DirectorySeparatorChar;

            for (var i = 0; i < res.Length; i++)
            {
                res[i] = dir + filenames[i];
            }

            return res;
        }
    }
}
