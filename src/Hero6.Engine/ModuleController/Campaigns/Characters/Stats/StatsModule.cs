// <copyright file="StatsModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Characters.Stats
{
    /// <summary>
    /// API for Stats Module.
    /// </summary>
    public class StatsModule : GameModule<IStatsController, IStatsModule>, IStatsModule
    {
        /// <summary>
        /// Gets the name of module.
        /// </summary>
        public override string Name => "StatsModule";

        /// <summary>
        /// Gets the health stat.
        /// </summary>
        public IStatModule Health => Controller.Health.Module;

        /// <summary>
        /// Gets the stamina stat.
        /// </summary>
        public IStatModule Stamina => Controller.Stamina.Module;

        /// <summary>
        /// Gets the mana stat.
        /// </summary>
        public IStatModule Mana => Controller.Mana.Module;

        /// <summary>
        /// Gets the humans stat.
        /// </summary>
        public IStatModule Humans => Controller.Humans.Module;

        /// <summary>
        /// Gets the sidhe stat.
        /// </summary>
        public IStatModule Sidhe => Controller.Sidhe.Module;

        /// <summary>
        /// Gets the giants stat.
        /// </summary>
        public IStatModule Giants => Controller.Giants.Module;

        /// <summary>
        /// Gets the strength stat.
        /// </summary>
        public ILearningStatModule Strength => Controller.Strength.Module;

        /// <summary>
        /// Gets the intelligence stat.
        /// </summary>
        public ILearningStatModule Intelligence => Controller.Intelligence.Module;

        /// <summary>
        /// Gets the agility stat.
        /// </summary>
        public ILearningStatModule Agility => Controller.Agility.Module;

        /// <summary>
        /// Gets the vitality stat.
        /// </summary>
        public ILearningStatModule Vitality => Controller.Vitality.Module;

        /// <summary>
        /// Gets the luck stat.
        /// </summary>
        public ILearningStatModule Luck => Controller.Luck.Module;

        /// <summary>
        /// Gets the weapon use stat.
        /// </summary>
        public ILearningStatModule WeaponUse => Controller.WeaponUse.Module;

        /// <summary>
        /// Gets the parry stat.
        /// </summary>
        public ILearningStatModule Parry => Controller.Parry.Module;

        /// <summary>
        /// Gets the dodge stat.
        /// </summary>
        public ILearningStatModule Dodge => Controller.Dodge.Module;

        /// <summary>
        /// Gets the stealth stat.
        /// </summary>
        public ILearningStatModule Stealth => Controller.Stealth.Module;

        /// <summary>
        /// Gets the lock picking.
        /// </summary>
        public ILearningStatModule LockPicking => Controller.LockPicking.Module;

        /// <summary>
        /// Gets the throwing stat.
        /// </summary>
        public ILearningStatModule Throwing => Controller.Throwing.Module;

        /// <summary>
        /// Gets the climbing stat.
        /// </summary>
        public ILearningStatModule Climbing => Controller.Climbing.Module;

        /// <summary>
        /// Gets the magic stat.
        /// </summary>
        public ILearningStatModule Magic => Controller.Magic.Module;
    }
}
