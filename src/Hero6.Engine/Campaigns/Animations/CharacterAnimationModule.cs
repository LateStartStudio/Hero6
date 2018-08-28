// <copyright file="CharacterAnimationModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Animations
{
    /// <summary>
    /// The API for the character animation module.
    /// </summary>
    public abstract class CharacterAnimationModule : GameModule<CharacterAnimationController>
    {
        /// <summary>
        /// Gets or sets the center down animation.
        /// </summary>
        protected AnimationModule CenterDown
        {
            get { return Controller.CenterDown; }
            set { Controller.CenterDown = value.Controller; }
        }

        /// <summary>
        /// Gets or sets the center up animation.
        /// </summary>
        protected AnimationModule CenterUp
        {
            get { return Controller.CenterUp; }
            set { Controller.CenterUp = value.Controller; }
        }

        /// <summary>
        /// Gets or sets the left center animation.
        /// </summary>
        protected AnimationModule LeftCenter
        {
            get { return Controller.LeftCenter; }
            set { Controller.LeftCenter = value.Controller; }
        }

        /// <summary>
        /// Gets or sets the left down animation.
        /// </summary>
        protected AnimationModule LeftDown
        {
            get { return Controller.LeftDown; }
            set { Controller.LeftDown = value.Controller; }
        }

        /// <summary>
        /// Gets or sets the left up animation.
        /// </summary>
        protected AnimationModule LeftUp
        {
            get { return Controller.LeftUp; }
            set { Controller.LeftUp = value.Controller; }
        }

        /// <summary>
        /// Gets or sets the right center animation.
        /// </summary>
        protected AnimationModule RightCenter
        {
            get { return Controller.RightCenter; }
            set { Controller.RightCenter = value.Controller; }
        }

        /// <summary>
        /// Gets or sets the right down animation.
        /// </summary>
        protected AnimationModule RightDown
        {
            get { return Controller.RightDown; }
            set { Controller.RightDown = value.Controller; }
        }

        /// <summary>
        /// Gets or sets the right up animation.
        /// </summary>
        protected AnimationModule RightUp
        {
            get { return Controller.RightUp; }
            set { Controller.RightUp = value.Controller; }
        }
    }
}
