// <copyright file="IStatsModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Characters.Stats
{
    public interface IStatsModule : IGameModule
    {
        /// <summary>
        /// Gets the health stat.
        /// </summary>
        IStatModule Health { get; }

        /// <summary>
        /// Gets the stamina stat.
        /// </summary>
        IStatModule Stamina { get; }

        /// <summary>
        /// Gets the mana stat.
        /// </summary>
        IStatModule Mana { get; }

        /// <summary>
        /// Gets the humans stat.
        /// </summary>
        IStatModule Humans { get; }

        /// <summary>
        /// Gets the sidhe stat.
        /// </summary>
        IStatModule Sidhe { get; }

        /// <summary>
        /// Gets the giants stat.
        /// </summary>
        IStatModule Giants { get; }

        /// <summary>
        /// Gets the strength stat.
        /// </summary>
        ILearningStatModule Strength { get; }

        /// <summary>
        /// Gets the intelligence stat.
        /// </summary>
        ILearningStatModule Intelligence { get; }

        /// <summary>
        /// Gets the agility stat.
        /// </summary>
        ILearningStatModule Agility { get; }

        /// <summary>
        /// Gets the vitality stat.
        /// </summary>
        ILearningStatModule Vitality { get; }

        /// <summary>
        /// Gets the luck stat.
        /// </summary>
        ILearningStatModule Luck { get; }

        /// <summary>
        /// Gets the weapon use stat.
        /// </summary>
        ILearningStatModule WeaponUse { get; }

        /// <summary>
        /// Gets the parry stat.
        /// </summary>
        ILearningStatModule Parry { get; }

        /// <summary>
        /// Gets the dodge stat.
        /// </summary>
        ILearningStatModule Dodge { get; }

        /// <summary>
        /// Gets the stealth stat.
        /// </summary>
        ILearningStatModule Stealth { get; }

        /// <summary>
        /// Gets the lock picking.
        /// </summary>
        ILearningStatModule LockPicking { get; }

        /// <summary>
        /// Gets the throwing stat.
        /// </summary>
        ILearningStatModule Throwing { get; }

        /// <summary>
        /// Gets the climbing stat.
        /// </summary>
        ILearningStatModule Climbing { get; }

        /// <summary>
        /// Gets the magic stat.
        /// </summary>
        ILearningStatModule Magic { get; }
    }
}
