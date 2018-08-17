// <copyright file="StatsModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Characters.Stats
{
    public class StatsModule : GameModule<StatsController>
    {
        public override string Name => "StatsModule";

        public StatModule Health => Controller.Health;

        public StatModule Stamina => Controller.Stamina;

        public StatModule Mana => Controller.Mana;

        public StatModule Humans => Controller.Humans;

        public StatModule Sidhe => Controller.Sidhe;

        public StatModule Giants => Controller.Giants;

        public LearningStatModule Strength => Controller.Strength;

        public LearningStatModule Intelligence => Controller.Intelligence;

        public LearningStatModule Agility => Controller.Agility;

        public LearningStatModule Vitality => Controller.Vitality;

        public LearningStatModule Luck => Controller.Luck;

        public LearningStatModule WeaponUse => Controller.WeaponUse;

        public LearningStatModule Parry => Controller.Parry;

        public LearningStatModule Dodge => Controller.Dodge;

        public LearningStatModule Stealth => Controller.Stealth;

        public LearningStatModule LockPicking => Controller.LockPicking;

        public LearningStatModule Throwing => Controller.Throwing;

        public LearningStatModule Climbing => Controller.Climbing;

        public LearningStatModule Magic => Controller.Magic;
    }
}
