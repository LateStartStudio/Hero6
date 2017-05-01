// <copyright file="MonoGameRenderer.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets
{
    using Graphics;
    using XnaColor = Microsoft.Xna.Framework.Color;
    using XnaPoint = Microsoft.Xna.Framework.Point;
    using XnaRectangle = Microsoft.Xna.Framework.Rectangle;
    using XnaSpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
    using XnaSpriteFont = Microsoft.Xna.Framework.Graphics.SpriteFont;
    using XnaTexture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

    public class MonoGameRenderer : Renderer
    {
        private readonly XnaSpriteBatch spriteBatch;

        public MonoGameRenderer(XnaSpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public override void Draw(Texture2D texture, Point point)
        {
            XnaTexture2D xnaTexture = texture.GetTexture as XnaTexture2D;
            XnaPoint xnaPoint = new XnaPoint(point.X, point.Y);

            this.spriteBatch.Draw(xnaTexture, xnaPoint.ToVector2());
        }

        public override void Draw(Texture2D texture, Rectangle destinationRectangle, Color color)
        {
            XnaTexture2D xnaTexture = texture.GetTexture as XnaTexture2D;
            XnaRectangle xnaDestination = new XnaRectangle(
                destinationRectangle.X,
                destinationRectangle.Y,
                destinationRectangle.Width,
                destinationRectangle.Height);
            XnaColor xnaColor = new XnaColor(color.R, color.G, color.B, color.A);

            this.spriteBatch.Draw(xnaTexture, xnaDestination, xnaColor);
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

        public override void DrawString(SpriteFont font, string text, Point position, Color color)
        {
            XnaSpriteFont xnaFont = font.GetSpriteFont as XnaSpriteFont;
            XnaPoint xnaPoint = new XnaPoint(position.X, position.Y);
            XnaColor xnaColor = new XnaColor(color.R, color.G, color.B, color.A);

            this.spriteBatch.DrawString(xnaFont, text, xnaPoint.ToVector2(), xnaColor);
        }
    }
}
