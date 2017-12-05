// <copyright file="Texture2DMock.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets.Graphics
{
    public class Texture2DMock : Texture2D
    {
        private readonly string id;
        private readonly object[] texture;

        public Texture2DMock(string id, int width, int height)
        {
            this.id = id;
            this.Width = width;
            this.Height = height;
            this.texture = GenerateTexture();
        }

        public override int Width { get; }

        public override int Height { get; }

        public override object GetTexture => texture;

        public override void GetData<T>(T[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (T)texture[i];
            }
        }

        public override void SetData<T>(T[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                texture[i] = data[i];
            }
        }

        private object[] GenerateTexture()
        {
            object[] result = new object[Width * Height];

            for (int i = 0; i < result.Length; i++)
            {
                switch (id)
                {
                    case "r":
                        result[i] = new Color(255, 0, 0, 0);
                        break;
                }
            }

            return result;
        }
    }
}
