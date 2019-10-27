// <copyright file="CharacterAnimationModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Animations
{
    /// <summary>
    /// The API for the character animation module.
    /// </summary>
    public abstract class CharacterAnimationModule : GameModule<CharacterAnimationController, ICharacterAnimationModule>, ICharacterAnimationModule
    {
        /// <summary>
        /// Gets or sets the center down animation.
        /// </summary>
        protected IAnimationModule CenterDown
        {
            get { return Controller.CenterDown.Module; }
            set { Controller.CenterDown = ((AnimationModule)value).Controller; }
        }

        /// <summary>
        /// Gets or sets the center up animation.
        /// </summary>
        protected IAnimationModule CenterUp
        {
            get { return Controller.CenterUp.Module; }
            set { Controller.CenterUp = ((AnimationModule)value).Controller; }
        }

        /// <summary>
        /// Gets or sets the left center animation.
        /// </summary>
        protected IAnimationModule LeftCenter
        {
            get { return Controller.LeftCenter.Module; }
            set { Controller.LeftCenter = ((AnimationModule)value).Controller; }
        }

        /// <summary>
        /// Gets or sets the left down animation.
        /// </summary>
        protected IAnimationModule LeftDown
        {
            get { return Controller.LeftDown.Module; }
            set { Controller.LeftDown = ((AnimationModule)value).Controller; }
        }

        /// <summary>
        /// Gets or sets the left up animation.
        /// </summary>
        protected IAnimationModule LeftUp
        {
            get { return Controller.LeftUp.Module; }
            set { Controller.LeftUp = ((AnimationModule)value).Controller; }
        }

        /// <summary>
        /// Gets or sets the right center animation.
        /// </summary>
        protected IAnimationModule RightCenter
        {
            get { return Controller.RightCenter.Module; }
            set { Controller.RightCenter = ((AnimationModule)value).Controller; }
        }

        /// <summary>
        /// Gets or sets the right down animation.
        /// </summary>
        protected IAnimationModule RightDown
        {
            get { return Controller.RightDown.Module; }
            set { Controller.RightDown = ((AnimationModule)value).Controller; }
        }

        /// <summary>
        /// Gets or sets the right up animation.
        /// </summary>
        protected IAnimationModule RightUp
        {
            get { return Controller.RightUp.Module; }
            set { Controller.RightUp = ((AnimationModule)value).Controller; }
        }
    }
}
