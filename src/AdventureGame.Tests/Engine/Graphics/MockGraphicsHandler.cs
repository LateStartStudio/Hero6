// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockGraphicsHandler.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the MockGraphicsHandler unit testing.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Engine.Graphics
{
    public class MockGraphicsHandler : GraphicsHandler
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
