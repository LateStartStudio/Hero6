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
    public class StatsModule : GameModule<StatsController, StatsModule>
    {
        /// <summary>
        /// Gets the name of module.
        /// </summary>
        public override string Name => "StatsModule";

        /// <summary>
        /// Gets the health stat.
        /// </summary>
        public StatModule Health => Controller.Health;

        /// <summary>
        /// Gets the stamina stat.
        /// </summary>
        public StatModule Stamina => Controller.Stamina;

        /// <summary>
        /// Gets the mana stat.
        /// </summary>
        public StatModule Mana => Controller.Mana;

        /// <summary>
        /// Gets the humans stat.
        /// </summary>
        public StatModule Humans => Controller.Humans;

        /// <summary>
        /// Gets the sidhe stat.
        /// </summary>
        public StatModule Sidhe => Controller.Sidhe;

        /// <summary>
        /// Gets the giants stat.
        /// </summary>
        public StatModule Giants => Controller.Giants;

        /// <summary>
        /// Gets the strength stat.
        /// </summary>
        public LearningStatModule Strength => Controller.Strength;

        /// <summary>
        /// Gets the intelligence stat.
        /// </summary>
        public LearningStatModule Intelligence => Controller.Intelligence;

        /// <summary>
        /// Gets the agility stat.
        /// </summary>
        public LearningStatModule Agility => Controller.Agility;

        /// <summary>
        /// Gets the vitality stat.
        /// </summary>
        public LearningStatModule Vitality => Controller.Vitality;

        /// <summary>
        /// Gets the luck stat.
        /// </summary>
        public LearningStatModule Luck => Controller.Luck;

        /// <summary>
        /// Gets the weapon use stat.
        /// </summary>
        public LearningStatModule WeaponUse => Controller.WeaponUse;

        /// <summary>
        /// Gets the parry stat.
        /// </summary>
        public LearningStatModule Parry => Controller.Parry;

        /// <summary>
        /// Gets the dodge stat.
        /// </summary>
        public LearningStatModule Dodge => Controller.Dodge;

        /// <summary>
        /// Gets the stealth stat.
        /// </summary>
        public LearningStatModule Stealth => Controller.Stealth;

        /// <summary>
        /// Gets the lock picking.
        /// </summary>
        public LearningStatModule LockPicking => Controller.LockPicking;

        /// <summary>
        /// Gets the throwing stat.
        /// </summary>
        public LearningStatModule Throwing => Controller.Throwing;

        /// <summary>
        /// Gets the climbing stat.
        /// </summary>
        public LearningStatModule Climbing => Controller.Climbing;

        /// <summary>
        /// Gets the magic stat.
        /// </summary>
        public LearningStatModule Magic => Controller.Magic;
    }
}
