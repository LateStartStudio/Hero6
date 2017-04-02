// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MonoGameTexture2D.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the MonoGameTexture2D type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Assets.Graphics
{
    using Microsoft.Xna.Framework.Graphics;

    public class MonoGameTexture2D : AdventureGame.Assets.Graphics.Texture2D
    {
        private readonly Texture2D texture;

        public MonoGameTexture2D(Texture2D texture)
        {
            this.texture = texture;
        }

        public override int Width
        {
            get { return this.texture.Width; }
        }

        public override int Height
        {
            get { return this.texture.Height; }
        }

        public override object GetTexture
        {
            get { return this.texture; }
        }

        public override void GetData<T>(T[] data)
        {
            this.texture.GetData(data);
        }
    }
}
