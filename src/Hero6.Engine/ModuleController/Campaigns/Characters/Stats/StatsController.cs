// <copyright file="StatsController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Services.DependencyInjection;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Characters.Stats
{
    /// <summary>
    /// API for Stats Controller.
    /// </summary>
    public abstract class StatsController : GameController<IStatsController, IStatsModule>, IStatsController
    {
        /// <summary>
        /// Makes a new instance of the <see cref="StatController"/> class.
        /// </summary>
        protected StatsController(IServiceLocator services)
            : base(new StatsModule(), services)
        {
        }

        /// <summary>
        /// Gets the health stat.
        /// </summary>
        public abstract IStatController Health { get; }

        /// <summary>
        /// Gets the stamina stat.
        /// </summary>
        public abstract IStatController Stamina { get; }

        /// <summary>
        /// Gets the mana stat.
        /// </summary>
        public abstract IStatController Mana { get; }

        /// <summary>
        /// Gets the humans stat.
        /// </summary>
        public abstract IStatController Humans { get; }

        /// <summary>
        /// Gets the sidhe stat.
        /// </summary>
        public abstract IStatController Sidhe { get; }

        /// <summary>
        /// Gets the giants stat.
        /// </summary>
        public abstract IStatController Giants { get; }

        /// <summary>
        /// Gets the strength stat.
        /// </summary>
        public abstract ILearningStatController Strength { get; }

        /// <summary>
        /// Gets the intelligence stat.
        /// </summary>
        public abstract ILearningStatController Intelligence { get; }

        /// <summary>
        /// Gets the agility stat.
        /// </summary>
        public abstract ILearningStatController Agility { get; }

        /// <summary>
        /// Gets the vitality stat.
        /// </summary>
        public abstract ILearningStatController Vitality { get; }

        /// <summary>
        /// Gets the luck stat.
        /// </summary>
        public abstract ILearningStatController Luck { get; }

        /// <summary>
        /// Gets the weapon use stat.
        /// </summary>
        public abstract ILearningStatController WeaponUse { get; }

        /// <summary>
        /// Gets the parry stat.
        /// </summary>
        public abstract ILearningStatController Parry { get; }

        /// <summary>
        /// Gets the dodge stat.
        /// </summary>
        public abstract ILearningStatController Dodge { get; }

        /// <summary>
        /// Gets the stealth stat.
        /// </summary>
        public abstract ILearningStatController Stealth { get; }

        /// <summary>
        /// Gets the lock picking.
        /// </summary>
        public abstract ILearningStatController LockPicking { get; }

        /// <summary>
        /// Gets the throwing stat.
        /// </summary>
        public abstract ILearningStatController Throwing { get; }

        /// <summary>
        /// Gets the climbing stat.
        /// </summary>
        public abstract ILearningStatController Climbing { get; }

        /// <summary>
        /// Gets the magic stat.
        /// </summary>
        public abstract ILearningStatController Magic { get; }
    }
}
