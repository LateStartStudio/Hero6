// <copyright file="AssetManager.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets
{
    using System;
    using Graphics;

    using LateStartStudio.Hero6.Engine.Campaigns.Regions;

    /// <summary>
    /// An abstract class for the asset handler of an adventure game engine.
    /// </summary>
    public abstract class AssetManager : IDisposable
    {
        /// <summary>
        /// Gets or sets the root directory of the <see cref="AssetManager"/> instance.
        /// </summary>
        /// <value>
        /// The root directory of the ContentManager instance.
        /// </value>
        public abstract string RootDirectory
        {
            get; set;
        }

        /// <summary>
        /// Gets the native Assets Manager instance.
        /// </summary>
        /// <value>
        /// The native Assets Manager instance.
        /// </value>
        public abstract object NativeAssetManager
        {
            get;
        }

        /// <summary>
        /// Disposes the ContentManager instance.
        /// </summary>
        public abstract void Dispose();

        /// <summary>
        /// Create a new empty texture.
        /// </summary>
        /// <param name="width">The width of the texture.</param>
        /// <param name="height">The height of the texture.</param>
        /// <returns>The texture that was created.</returns>
        public abstract Texture2D CreateTexture2D(int width, int height);

        /// <summary>
        /// Loads the 2D texture asset.
        /// </summary>
        /// <param name="id">The ID of the 2D texture asset.</param>
        /// <returns>The 2D texture that was loaded.</returns>
        public abstract Texture2D LoadTexture2D(string id);

        /// <summary>
        /// Loads the font asset.
        /// </summary>
        /// <param name="id">The ID of the font asset.</param>
        /// <returns>The font that was loaded.</returns>
        public abstract SpriteFont LoadSpriteFont(string id);

        /// <summary>
        /// Loads walk areas from file.
        /// </summary>
        /// <param name="id">The ID of the walk areas.</param>
        /// <returns>The walk areas that was loaded.</returns>
        public abstract WalkAreas LoadWalkAreas(string id);

        /// <summary>
        /// Disposes all data that was loaded by this ContentManager.
        /// </summary>
        public abstract void Unload();
    }
}
