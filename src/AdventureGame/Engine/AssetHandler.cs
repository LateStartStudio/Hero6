// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssetHandler.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the AssetHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Engine
{
    using Graphics;

    /// <summary>
    /// An abstract class for the asset handler of an adventure game engine.
    /// </summary>
    public abstract class AssetHandler
    {
        /// <summary>
        /// Loads the 2D texture asset.
        /// </summary>
        /// <param name="id">The ID of the 2D texture asset.</param>
        /// <returns>The 2D texture that was loaded.</returns>
        public abstract Texture2D LoadTexture2D(string id);
    }
}
