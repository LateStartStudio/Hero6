// <copyright file="SpriteFont.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets.Graphics
{
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
    }
}
