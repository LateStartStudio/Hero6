// <copyright file="MockRenderer.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets
{
    using Graphics;

    public class MockRenderer : Renderer
    {
        public override void Draw(Texture2D texture, Point point)
        {
            throw new System.NotImplementedException();
        }

        public override void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle sourceRectangle, Color color)
        {
            throw new System.NotImplementedException();
        }
    }
}
