// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MonoGameGraphics.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the MonoGameGraphics type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Engine.Graphics
{
    using AdventureGame.Engine.Graphics;
    using Microsoft.Xna.Framework.Graphics;
    using Texture2D = AdventureGame.Engine.Graphics.Texture2D;
    using XnaColor = Microsoft.Xna.Framework.Color;
    using XnaPoint = Microsoft.Xna.Framework.Point;
    using XnaRectangle = Microsoft.Xna.Framework.Rectangle;
    using XnaTexture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

    public class MonoGameGraphics : GraphicsHandler
    {
        private readonly SpriteBatch spriteBatch;

        public MonoGameGraphics(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public override void Draw(Texture2D texture, Point point)
        {
            XnaTexture2D xnaTexture = texture.GetTexture as XnaTexture2D;
            XnaPoint xnaPoint = new XnaPoint(point.X, point.Y);

            this.spriteBatch.Draw(xnaTexture, xnaPoint.ToVector2());
        }

        public override void Draw(
            Texture2D texture,
            Rectangle destinationRectangle,
            Rectangle sourceRectangle,
            Color color)
        {
            XnaTexture2D xnaTexture = texture.GetTexture as XnaTexture2D;
            XnaRectangle xnaDestination = new XnaRectangle(
                destinationRectangle.X,
                destinationRectangle.Y,
                destinationRectangle.Width,
                destinationRectangle.Height);
            XnaRectangle xnaSource = new XnaRectangle(
                sourceRectangle.X,
                sourceRectangle.Y,
                sourceRectangle.Width,
                sourceRectangle.Height);
            XnaColor xnaColor = new XnaColor(color.R, color.G, color.B, color.A);

            this.spriteBatch.Draw(xnaTexture, xnaDestination, xnaSource, xnaColor);
        }
    }
}
