// <copyright file="SpriteFontMock.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets.Graphics
{
    using System.Text;

    public class SpriteFontMock : SpriteFont
    {
        public SpriteFontMock(string id)
        {
            this.GetSpriteFont = id;
        }

        public override object GetSpriteFont { get; }

        public override Vector2 MeasureString(string text)
        {
            return new Vector2(text.Length, text.Length);
        }

        public override Vector2 MeasureString(StringBuilder text)
        {
            return new Vector2(text.Length, text.Length);
        }
    }
}
