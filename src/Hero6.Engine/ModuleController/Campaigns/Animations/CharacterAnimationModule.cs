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
    public abstract class CharacterAnimationModule : GameModule<ICharacterAnimationController, ICharacterAnimationModule>, ICharacterAnimationModule
    {
        /// <summary>
        /// Gets or sets the center down animation.
        /// </summary>
        public IAnimationModule CenterDown
        {
            get => Controller.LeftUp.Module;
            set => Controller.CenterDown = ((AnimationModule)value).Controller;
        }

        /// <summary>
        /// Gets or sets the center up animation.
        /// </summary>
        public IAnimationModule CenterUp
        {
            get => Controller.CenterUp.Module;
            set => Controller.CenterUp = ((AnimationModule)value).Controller;
        }

        /// <summary>
        /// Gets or sets the left center animation.
        /// </summary>
        public IAnimationModule LeftCenter
        {
            get => Controller.LeftCenter.Module;
            set => Controller.LeftCenter = ((AnimationModule)value).Controller;
        }

        /// <summary>
        /// Gets or sets the left down animation.
        /// </summary>
        public IAnimationModule LeftDown
        {
            get => Controller.LeftDown.Module;
            set => Controller.LeftDown = ((AnimationModule)value).Controller;
        }

        /// <summary>
        /// Gets or sets the left up animation.
        /// </summary>
        public IAnimationModule LeftUp
        {
            get => Controller.LeftUp.Module;
            set => Controller.LeftUp = ((AnimationModule)value).Controller;
        }

        /// <summary>
        /// Gets or sets the right center animation.
        /// </summary>
        public IAnimationModule RightCenter
        {
            get => Controller.RightCenter.Module;
            set => Controller.RightCenter = ((AnimationModule)value).Controller;
        }

        /// <summary>
        /// Gets or sets the right down animation.
        /// </summary>
        public IAnimationModule RightDown
        {
            get => Controller.RightDown.Module;
            set => Controller.RightDown = ((AnimationModule)value).Controller;
        }

        /// <summary>
        /// Gets or sets the right up animation.
        /// </summary>
        public IAnimationModule RightUp
        {
            get => Controller.RightUp.Module;
            set => Controller.RightUp = ((AnimationModule)value).Controller;
        }
    }
}
