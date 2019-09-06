// <copyright file="AnimationController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Animations
{
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;

    /// <summary>
    /// API for for animation controllers.
    /// </summary>
    public abstract class AnimationController : GameController<AnimationController, AnimationModule>
    {
        /// <summary>
        /// Makes an new instance of the <see cref="AnimationController"/> class.
        /// </summary>
        /// <param name="module">The module corresponding to this controller.</param>
        protected AnimationController(AnimationModule module, IServices services) : base(module, services)
        {
        }
    }
}
