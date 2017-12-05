// <copyright file="AssetManagerMock.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets
{
    using System.Collections.Generic;
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
            string[] texture = id.Split(':');
            return new Texture2DMock(texture[0], int.Parse(texture[1]), int.Parse(texture[2]));
        }

        public override SpriteFont LoadSpriteFont(string id)
        {
            return new SpriteFontMock(id);
        }

        public override WalkAreas LoadWalkAreas(string id)
        {
            return new WalkAreas(new List<WalkArea>());
        }

        public override void Unload()
        {
        }
    }
}
