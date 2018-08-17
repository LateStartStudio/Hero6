// <copyright file="SpriteSheetModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Animations
{
    public abstract class AnimationModule : GameModule<AnimationController>
    {
        public abstract string Sprite { get; }

        public abstract int Cols { get; }

        public abstract int Rows { get; }
    }
}
