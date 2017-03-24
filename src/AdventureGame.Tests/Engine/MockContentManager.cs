// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockContentManager.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the MockContentManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Engine
{
    using Graphics;

    public class MockContentManager : ContentManager
    {
        public override string RootDirectory { get; set; }

        public override object NativeContentManager => null;

        public override void Dispose()
        {
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
