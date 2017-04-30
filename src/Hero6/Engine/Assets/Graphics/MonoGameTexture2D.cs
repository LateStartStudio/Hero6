// <copyright file="MonoGameTexture2D.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets.Graphics
{
    using XnaTexture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

    public class MonoGameTexture2D : Texture2D
    {
        private readonly XnaTexture2D texture;

        public MonoGameTexture2D(XnaTexture2D texture)
        {
            this.texture = texture;
        }

        public override int Width => texture.Width;

        public override int Height => texture.Height;

        public override object GetTexture => texture;

        public override void GetData<T>(T[] data)
        {
            texture.GetData(data);
        }

        public override void SetData<T>(T[] data)
        {
            texture.SetData(data);
        }
    }
}
