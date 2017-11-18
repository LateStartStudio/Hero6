// <copyright file="Texture2DMock.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets.Graphics
{
    public class Texture2DMock : Texture2D
    {
        public Texture2DMock(string id, int width, int height)
        {
            this.GetTexture = id;
            this.Width = width;
            this.Height = height;
        }

        public override int Width { get; }

        public override int Height { get; }

        public override object GetTexture { get; }

        public override void GetData<T>(T[] data)
        {
        }

        public override void SetData<T>(T[] data)
        {
        }
    }
}
