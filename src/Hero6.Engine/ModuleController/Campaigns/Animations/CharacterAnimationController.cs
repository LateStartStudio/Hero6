// <copyright file="CharacterAnimationController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Services.DependencyInjection;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Animations
{
    /// <summary>
    /// The API for the character animation controller.
    /// </summary>
    public abstract class CharacterAnimationController : GameController<CharacterAnimationController, ICharacterAnimationModule>
    {
        /// <summary>
        /// Creates a new instance of the <see cref="CharacterAnimationController"/> class.
        /// </summary>
        /// <param name="module">The module corresponding to this controller.</param>
        protected CharacterAnimationController(ICharacterAnimationModule module, IServiceLocator services)
            : base(module, services)
        {
        }

        /// <summary>
        /// Gets or sets the center down animation.
        /// </summary>
        protected internal abstract AnimationController CenterDown { get; set; }

        /// <summary>
        /// Gets or sets the center up animation.
        /// </summary>
        protected internal abstract AnimationController CenterUp { get; set; }

        /// <summary>
        /// Gets or sets the left center animation.
        /// </summary>
        protected internal abstract AnimationController LeftCenter { get; set; }

        /// <summary>
        /// Gets or sets the left down animation.
        /// </summary>
        protected internal abstract AnimationController LeftDown { get; set; }

        /// <summary>
        /// Gets or sets the left up animation.
        /// </summary>
        protected internal abstract AnimationController LeftUp { get; set; }

        /// <summary>
        /// Gets or sets the right center animation.
        /// </summary>
        protected internal abstract AnimationController RightCenter { get; set; }

        /// <summary>
        /// Gets or sets the right down animation.
        /// </summary>
        protected internal abstract AnimationController RightDown { get; set; }

        /// <summary>
        /// Gets or sets the right up animation.
        /// </summary>
        protected internal abstract AnimationController RightUp { get; set; }
    }
}
