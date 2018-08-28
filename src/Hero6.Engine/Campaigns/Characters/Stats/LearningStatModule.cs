// <copyright file="LearningStatModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Characters.Stats
{
    using System;

    /// <summary>
    /// Stat that has to be learned and trained.
    /// </summary>
    public class LearningStatModule : GameModule<LearningStatController>
    {
        /// <summary>
        /// Invoked when <see cref="Current"/> has changed.
        /// </summary>
        public event EventHandler<EventArgs> Change
        {
            add { Controller.Change += value; }
            remove { Controller.Change -= value; }
        }

        /// <inheritdoc />
        public override string Name => "StatModule";

        /// <summary>
        /// Gets the current stat.
        /// </summary>
        public int Current => Controller.Current;
    }
}
