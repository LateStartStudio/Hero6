// <copyright file="StatModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Characters.Stats
{
    /// <summary>
    /// API for get-set stat module.
    /// </summary>
    public class StatModule : GameModule<StatController, StatModule>
    {
        /// <summary>
        /// <see cref="Change"/> event is onvoked when <see cref="Current"/> changes.
        /// </summary>
        public event EventHandler<EventArgs> Change
        {
            add { Controller.Change += value; }
            remove { Controller.Change -= value; }
        }

        /// <inheritdoc/>
        public override string Name { get; }

        /// <summary>
        /// Gets or sets the current stat.
        /// </summary>
        public int Current
        {
            get { return Controller.Current; }
            set { Controller.Current = value; }
        }

        /// <summary>
        /// Gets he max stat that <see cref="Current"/> shouldn't exceed.
        /// </summary>
        public int Max => Controller.Max;
    }
}
