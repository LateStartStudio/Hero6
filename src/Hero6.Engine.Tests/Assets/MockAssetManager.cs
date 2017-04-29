// <copyright file="MockAssetManager.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets
{
    using Graphics;

    public class MockAssetManager : AssetManager
    {
        public override string RootDirectory { get; set; }

        public override object NativeAssetManager => null;

        public override void Dispose()
        {
        }

        public override Texture2D CreateTexture2D(int width, int height)
        {
            return null;
        }

        public override Texture2D LoadTexture2D(string id)
        {
            return null;
        }

        public override SpriteFont LoadSpriteFont(string id)
        {
            return null;
        }

        public override void Unload()
        {
        }
    }
}
