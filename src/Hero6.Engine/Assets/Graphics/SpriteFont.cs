// <copyright file="SpriteFont.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets.Graphics
{
    using System.Text;

    /// <summary>
    /// An abstract class for a sprite font.
    /// </summary>
    public abstract class SpriteFont
    {
        /// <summary>
        /// Gets the data within the sprite font.
        /// </summary>
        /// <value>
        /// The data within the sprite font.
        /// </value>
        public abstract object GetSpriteFont { get; }

        /// <summary>
        /// Calculates the size of the string in vector coordinates.
        /// </summary>
        /// <param name="text">The text to find the size from.</param>
        /// <returns>The size in vector format.</returns>
        public abstract Vector2 MeasureString(string text);

        /// <summary>
        /// Calculates the size of the string in vector coordinates.
        /// </summary>
        /// <param name="text">The text to find the size from.</param>
        /// <returns>The size in vector format.</returns>
        public abstract Vector2 MeasureString(StringBuilder text);
    }
}
