// <copyright file="RendererMock.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets
{
    using Graphics;

    public class RendererMock : Renderer
    {
        public static bool IsDrawInvoked { get; set; }

        public static bool IsDrawStringInvoked { get; set; }

        public override void Draw(Texture2D texture, Point point)
        {
            IsDrawInvoked = true;
        }

        public override void Draw(Texture2D texture, Rectangle destinationRectangle, Color color)
        {
            IsDrawInvoked = true;
        }

        public override void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle sourceRectangle, Color color)
        {
            IsDrawInvoked = true;
        }

        public override void DrawString(SpriteFont font, string text, Point position, Color color)
        {
            IsDrawStringInvoked = true;
        }
    }
}
