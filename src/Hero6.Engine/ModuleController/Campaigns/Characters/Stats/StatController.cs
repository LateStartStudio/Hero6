// <copyright file="StatController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.Services.DependencyInjection;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Characters.Stats
{
    /// <summary>
    /// API for get-set stat controller.
    /// </summary>
    public abstract class StatController : GameController<StatController, IStatModule>
    {
        /// <summary>
        /// Makes a new instance of the <see cref="StatController"/>.
        /// </summary>
        protected StatController(IServiceLocator services)
            : base(new StatModule(), services)
        {
        }

        /// <summary>
        /// <see cref="Change"/> event is onvoked when <see cref="Current"/> changes.
        /// </summary>
        public abstract event EventHandler<EventArgs> Change;

        /// <summary>
        /// Gets or sets the current stat.
        /// </summary>
        public abstract int Current { get; set; }

        /// <summary>
        /// Gets he max stat that <see cref="Current"/> shouldn't exceed.
        /// </summary>
        public abstract int Max { get; }
    }
}
