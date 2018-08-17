// <copyright file="StatsController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Characters.Stats
{
    public abstract class StatsController : GameController<StatsController, StatsModule>
    {
        protected StatsController()
            : base(new StatsModule())
        {
        }

        public abstract StatController Health { get; }

        public abstract StatController Stamina { get; }

        public abstract StatController Mana { get; }

        public abstract StatController Humans { get; }

        public abstract StatController Sidhe { get; }

        public abstract StatController Giants { get; }

        public abstract LearningStatController Strength { get; }

        public abstract LearningStatController Intelligence { get; }

        public abstract LearningStatController Agility { get; }

        public abstract LearningStatController Vitality { get; }

        public abstract LearningStatController Luck { get; }

        public abstract LearningStatController WeaponUse { get; }

        public abstract LearningStatController Parry { get; }

        public abstract LearningStatController Dodge { get; }

        public abstract LearningStatController Stealth { get; }

        public abstract LearningStatController LockPicking { get; }

        public abstract LearningStatController Throwing { get; }

        public abstract LearningStatController Climbing { get; }

        public abstract LearningStatController Magic { get; }
    }
}
