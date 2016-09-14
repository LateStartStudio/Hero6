// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpriteFont.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the SpriteFont type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Engine.Graphics
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
