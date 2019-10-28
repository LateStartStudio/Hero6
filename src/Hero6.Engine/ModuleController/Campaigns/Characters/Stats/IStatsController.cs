// <copyright file="IStatsController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Characters.Stats
{
    public interface IStatsController : IGameController
    {
        IStatsModule Module { get; }

        /// <summary>
        /// Gets the health stat.
        /// </summary>
        IStatController Health { get; }

        /// <summary>
        /// Gets the stamina stat.
        /// </summary>
        IStatController Stamina { get; }

        /// <summary>
        /// Gets the mana stat.
        /// </summary>
        IStatController Mana { get; }

        /// <summary>
        /// Gets the humans stat.
        /// </summary>
        IStatController Humans { get; }

        /// <summary>
        /// Gets the sidhe stat.
        /// </summary>
        IStatController Sidhe { get; }

        /// <summary>
        /// Gets the giants stat.
        /// </summary>
        IStatController Giants { get; }

        /// <summary>
        /// Gets the strength stat.
        /// </summary>
        ILearningStatController Strength { get; }

        /// <summary>
        /// Gets the intelligence stat.
        /// </summary>
        ILearningStatController Intelligence { get; }

        /// <summary>
        /// Gets the agility stat.
        /// </summary>
        ILearningStatController Agility { get; }

        /// <summary>
        /// Gets the vitality stat.
        /// </summary>
        ILearningStatController Vitality { get; }

        /// <summary>
        /// Gets the luck stat.
        /// </summary>
        ILearningStatController Luck { get; }

        /// <summary>
        /// Gets the weapon use stat.
        /// </summary>
        ILearningStatController WeaponUse { get; }

        /// <summary>
        /// Gets the parry stat.
        /// </summary>
        ILearningStatController Parry { get; }

        /// <summary>
        /// Gets the dodge stat.
        /// </summary>
        ILearningStatController Dodge { get; }

        /// <summary>
        /// Gets the stealth stat.
        /// </summary>
        ILearningStatController Stealth { get; }

        /// <summary>
        /// Gets the lock picking.
        /// </summary>
        ILearningStatController LockPicking { get; }

        /// <summary>
        /// Gets the throwing stat.
        /// </summary>
        ILearningStatController Throwing { get; }

        /// <summary>
        /// Gets the climbing stat.
        /// </summary>
        ILearningStatController Climbing { get; }

        /// <summary>
        /// Gets the magic stat.
        /// </summary>
        ILearningStatController Magic { get; }
    }
}
