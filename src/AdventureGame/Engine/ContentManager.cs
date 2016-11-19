// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContentManager.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the ContentManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Engine
{
    using System;
    using Graphics;

    /// <summary>
    /// An abstract class for the asset handler of an adventure game engine.
    /// </summary>
    public abstract class ContentManager : IDisposable
    {
        /// <summary>
        /// Gets or sets the root directory of the <see cref="ContentManager"/> instance.
        /// </summary>
        /// <value>
        /// The root directory of the ContentManager instance.
        /// </value>
        public abstract string RootDirectory
        {
            get; set;
        }

        /// <summary>
        /// Gets the native Content Manager instance.
        /// </summary>
        /// <value>
        /// The native Content Manager instance.
        /// </value>
        public abstract object NativeContentManager
        {
            get;
        }

        /// <summary>
        /// Disposes the ContentManager instance.
        /// </summary>
        public abstract void Dispose();

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
        /// Disposes all data that was loaded by this ContentManager.
        /// </summary>
        public abstract void Unload();
    }
}
