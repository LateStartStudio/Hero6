// <copyright file="AnimationModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Animations
{
    /// <summary>
    /// Animation using a sprite sheet.
    /// </summary>
    public abstract class AnimationModule : GameModule<AnimationController, AnimationModule>, IAnimationModule
    {
        /// <summary>
        /// Gets the path of the sprite sheets.
        /// </summary>
        public abstract string Sprite { get; }

        /// <summary>
        /// Gets the column count of the sprite sheet.
        /// </summary>
        public abstract int Cols { get; }

        /// <summary>
        /// Gets the row count of the sprite sheet.
        /// </summary>
        public abstract int Rows { get; }
    }
}
