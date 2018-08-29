// <copyright file="IAssets.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets
{
    using Graphics;
    using LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions;

    /// <summary>
    /// An interface for the asset handler of an adventure game engine.
    /// </summary>
    public interface IAssets
    {
        /// <summary>
        /// Gets or sets the root directory of the <see cref="IAssets"/> instance.
        /// </summary>
        string Directory { get; set; }

        /// <summary>
        /// Disposes the <see cref="IAssets"/> instance.
        /// </summary>
        void Dispose();

        /// <summary>
        /// Create a new empty texture.
        /// </summary>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <returns>The texture that was created.</returns>
        Texture2D CreateTexture2D(int width, int height);

        /// <summary>
        /// Loads the 2D texture asset.
        /// </summary>
        /// <param name="id">The ID of the 2D texture asset.</param>
        /// <returns>The 2D texture that was loaded.</returns>
        Texture2D LoadTexture2D(string id);

        /// <summary>
        /// Loads the font asset.
        /// </summary>
        /// <param name="id">The ID of the font asset.</param>
        /// <returns>The font that was loaded.</returns>
        SpriteFont LoadSpriteFont(string id);

        /// <summary>
        /// Loads walk areas from file.
        /// </summary>
        /// <param name="id">The ID of the walk areas.</param>
        /// <returns>The walk areas that was loaded.</returns>
        WalkAreasModule LoadWalkAreas(string id);

        /// <summary>
        /// Disposes all data that was loaded by this <see cref="IAssets"/> instance.
        /// </summary>
        void Unload();
    }
}
