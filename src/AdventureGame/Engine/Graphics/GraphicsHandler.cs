// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GraphicsHandler.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the GraphicsHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Engine.Graphics
{
    /// <summary>
    /// An abstract class for the graphics handler of the adventure game engine.
    /// </summary>
    public abstract class GraphicsHandler
    {
        /// <summary>
        /// Draws sprites to screen.
        /// </summary>
        /// <param name="texture">The sprite.</param>
        /// <param name="point">The location to draw the sprite.</param>
        public abstract void Draw(Texture2D texture, Point point);

        /// <summary>
        /// Draws sprites to screen.
        /// </summary>
        /// <param name="texture">The 2D sprite.</param>
        /// <param name="destinationRectangle">
        /// A rectangle that specifies the desination to draw the sprite.
        /// </param>
        /// <param name="sourceRectangle">
        /// A rectangle to specify how much will be drawn of the texture.
        /// </param>
        /// <param name="color">The color to tint the sprite.</param>
        public abstract void Draw(
            Texture2D texture,
            Rectangle destinationRectangle,
            Rectangle sourceRectangle,
            Color color);
    }
}
