﻿// <copyright file="AssetManagerMock.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets
{
    using LateStartStudio.Hero6.Engine.Assets.Graphics;
    using LateStartStudio.Hero6.Engine.Campaigns.Regions;

    public sealed class AssetManagerMock : AssetManager
    {
        public AssetManagerMock()
        {
            this.RootDirectory = "Mock Asset Manager";
        }

        public override string RootDirectory { get; set; }

        public override object NativeAssetManager => "Native Asset Manager";

        public override void Dispose()
        {
        }

        public override Texture2D CreateTexture2D(int width, int height)
        {
            return new Texture2DMock("Made Texutre", width, height);
        }

        public override Texture2D LoadTexture2D(string id)
        {
            return new Texture2DMock(id, 0, 0);
        }

        public override SpriteFont LoadSpriteFont(string id)
        {
            return new SpriteFontMock(id);
        }

        public override WalkAreas LoadWalkAreas(string id)
        {
            return new WalkAreas(null);
        }

        public override void Unload()
        {
        }
    }
}
