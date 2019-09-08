// <copyright file="StatsController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;

namespace LateStartStudio.Hero6.Engine.Campaigns.Characters.Stats
{
    /// <summary>
    /// API for Stats Controller.
    /// </summary>
    public abstract class StatsController : GameController<StatsController, StatsModule>
    {
        /// <summary>
        /// Makes a new instance of the <see cref="StatController"/> class.
        /// </summary>
        protected StatsController(IServices services)
            : base(new StatsModule(), services)
        {
        }

        /// <summary>
        /// Gets the health stat.
        /// </summary>
        public abstract StatController Health { get; }

        /// <summary>
        /// Gets the stamina stat.
        /// </summary>
        public abstract StatController Stamina { get; }

        /// <summary>
        /// Gets the mana stat.
        /// </summary>
        public abstract StatController Mana { get; }

        /// <summary>
        /// Gets the humans stat.
        /// </summary>
        public abstract StatController Humans { get; }

        /// <summary>
        /// Gets the sidhe stat.
        /// </summary>
        public abstract StatController Sidhe { get; }

        /// <summary>
        /// Gets the giants stat.
        /// </summary>
        public abstract StatController Giants { get; }

        /// <summary>
        /// Gets the strength stat.
        /// </summary>
        public abstract LearningStatController Strength { get; }

        /// <summary>
        /// Gets the intelligence stat.
        /// </summary>
        public abstract LearningStatController Intelligence { get; }

        /// <summary>
        /// Gets the agility stat.
        /// </summary>
        public abstract LearningStatController Agility { get; }

        /// <summary>
        /// Gets the vitality stat.
        /// </summary>
        public abstract LearningStatController Vitality { get; }

        /// <summary>
        /// Gets the luck stat.
        /// </summary>
        public abstract LearningStatController Luck { get; }

        /// <summary>
        /// Gets the weapon use stat.
        /// </summary>
        public abstract LearningStatController WeaponUse { get; }

        /// <summary>
        /// Gets the parry stat.
        /// </summary>
        public abstract LearningStatController Parry { get; }

        /// <summary>
        /// Gets the dodge stat.
        /// </summary>
        public abstract LearningStatController Dodge { get; }

        /// <summary>
        /// Gets the stealth stat.
        /// </summary>
        public abstract LearningStatController Stealth { get; }

        /// <summary>
        /// Gets the lock picking.
        /// </summary>
        public abstract LearningStatController LockPicking { get; }

        /// <summary>
        /// Gets the throwing stat.
        /// </summary>
        public abstract LearningStatController Throwing { get; }

        /// <summary>
        /// Gets the climbing stat.
        /// </summary>
        public abstract LearningStatController Climbing { get; }

        /// <summary>
        /// Gets the magic stat.
        /// </summary>
        public abstract LearningStatController Magic { get; }
    }
}
