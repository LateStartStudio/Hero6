// <copyright file="Cursor.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Input
{
    using System.Collections.Generic;

    using LateStartStudio.Hero6.Engine.Assets;
    using LateStartStudio.Hero6.Engine.Assets.Graphics;

    /// <summary>
    /// Abstract class containg raw cursor functionality. This class is designed to be inherited in
    /// a class using the type safe enum design pattern.
    /// </summary>
    public abstract class Cursor
    {
        private readonly string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cursor"/> class.
        /// </summary>
        /// <param name="path">The path of the cursor texture.</param>
        protected Cursor(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Gets all cursors.
        /// </summary>
        public static IEnumerable<Cursor> All => Cursors;

        /// <summary>
        /// Gets the texture to draw for this cursor.
        /// </summary>
        public Texture2D Texture { get; private set; }

        /// <summary>
        /// Gets all cursors.
        /// </summary>
        protected static List<Cursor> Cursors { get; } = new List<Cursor>();

        /// <summary>
        /// Load the texture.
        /// </summary>
        /// <param name="assets">The asset manager for this user interface module.</param>
        public void Load(AssetManager assets)
        {
            this.Texture = assets.LoadTexture2D(path);
        }
    }
}
