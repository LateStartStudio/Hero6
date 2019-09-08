// <copyright file="LearningStatController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Characters.Stats
{
    using System;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;
    using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;

    /// <summary>
    /// Stat that has to be learned and trained.
    /// </summary>
    public abstract class LearningStatController : GameController<LearningStatController, LearningStatModule>
    {
        /// <summary>
        /// Makes a new instance of the <see cref="LearningStatController"/> class.
        /// </summary>
        protected LearningStatController(IServices services)
            : base(new LearningStatModule(), services)
        {
        }

        /// <summary>
        /// Invoked when <see cref="Current"/> has changed.
        /// </summary>
        public abstract event EventHandler<EventArgs> Change;

        /// <summary>
        /// Gets the current stat.
        /// </summary>
        public abstract int Current { get; }

        /// <summary>
        /// Trains the current stat. The formula/algorithm to how it is trained depends on implementation.
        /// </summary>
        /// <param name="factor">The factor for how it should be trained.</param>
        public abstract void Train(int factor);
    }
}
