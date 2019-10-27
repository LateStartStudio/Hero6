// <copyright file="ICharacterAnimationController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Animations
{
    public interface ICharacterAnimationController : IGameController
    {
        ICharacterAnimationModule Module { get; }

        /// <summary>
        /// Gets or sets the center down animation.
        /// </summary>
        IAnimationController CenterDown { get; set; }

        /// <summary>
        /// Gets or sets the center up animation.
        /// </summary>
        IAnimationController CenterUp { get; set; }

        /// <summary>
        /// Gets or sets the left center animation.
        /// </summary>
        IAnimationController LeftCenter { get; set; }

        /// <summary>
        /// Gets or sets the left down animation.
        /// </summary>
        IAnimationController LeftDown { get; set; }

        /// <summary>
        /// Gets or sets the left up animation.
        /// </summary>
        IAnimationController LeftUp { get; set; }

        /// <summary>
        /// Gets or sets the right center animation.
        /// </summary>
        IAnimationController RightCenter { get; set; }

        /// <summary>
        /// Gets or sets the right down animation.
        /// </summary>
        IAnimationController RightDown { get; set; }

        /// <summary>
        /// Gets or sets the right up animation.
        /// </summary>
        IAnimationController RightUp { get; set; }
    }
}
