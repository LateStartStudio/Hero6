// <copyright file="StatsController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.Services.Campaigns;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Characters.Stats
{
    /// <summary>
    /// API for Stats Controller.
    /// </summary>
    public class StatsController : GameController<IStatsController, IStatsModule>, IStatsController
    {
        /// <summary>
        /// Makes a new instance of the <see cref="StatController"/> class.
        /// </summary>
        public StatsController(IServiceProvider services, ICampaigns campaigns)
            : base(new StatsModule(), services)
        {
            Func<int> healthMax = () => (int)((Strength.Current * 0.4) + (Vitality.Current * 0.6));
            Health = ActivatorUtilities.CreateInstance<StatController>(services, healthMax);
            Func<int> staminaMax = () => (int)((Vitality.Current * 0.4) + (Agility.Current * 0.6));
            Stamina = ActivatorUtilities.CreateInstance<StatController>(services, staminaMax);
            Func<int> manaMax = () => Magic.Current > 0 ? (int)((Intelligence.Current * 0.4) + (Magic.Current * 0.6)) : 0;
            Mana = ActivatorUtilities.CreateInstance<StatController>(services, manaMax);
            Func<int> humansMax = () => campaigns.Current.StatCap;
            Humans = ActivatorUtilities.CreateInstance<StatController>(services, humansMax);
            Func<int> sidheMax = () => campaigns.Current.StatCap;
            Sidhe = ActivatorUtilities.CreateInstance<StatController>(services, sidheMax);
            Func<int> giantsMax = () => campaigns.Current.StatCap;
            Giants = ActivatorUtilities.CreateInstance<StatController>(services, giantsMax);

            Strength = ActivatorUtilities.CreateInstance<LearningStatController>(services);
            Intelligence = ActivatorUtilities.CreateInstance<LearningStatController>(services);
            Agility = ActivatorUtilities.CreateInstance<LearningStatController>(services);
            Vitality = ActivatorUtilities.CreateInstance<LearningStatController>(services);
            Luck = ActivatorUtilities.CreateInstance<LearningStatController>(services);
            WeaponUse = ActivatorUtilities.CreateInstance<LearningStatController>(services);
            Parry = ActivatorUtilities.CreateInstance<LearningStatController>(services);
            Dodge = ActivatorUtilities.CreateInstance<LearningStatController>(services);
            Stealth = ActivatorUtilities.CreateInstance<LearningStatController>(services);
            LockPicking = ActivatorUtilities.CreateInstance<LearningStatController>(services);
            Throwing = ActivatorUtilities.CreateInstance<LearningStatController>(services);
            Climbing = ActivatorUtilities.CreateInstance<LearningStatController>(services);
            Magic = ActivatorUtilities.CreateInstance<LearningStatController>(services);
        }

        public override int Width { get; }

        public override int Height { get; }

        public IStatController Health { get; }

        public IStatController Stamina { get; }

        public IStatController Mana { get; }

        public IStatController Humans { get; }

        public IStatController Sidhe { get; }

        public IStatController Giants { get; }

        public ILearningStatController Strength { get; }

        public ILearningStatController Intelligence { get; }

        public ILearningStatController Agility { get; }

        public ILearningStatController Vitality { get; }

        public ILearningStatController Luck { get; }

        public ILearningStatController WeaponUse { get; }

        public ILearningStatController Parry { get; }

        public ILearningStatController Dodge { get; }

        public ILearningStatController Stealth { get; }

        public ILearningStatController LockPicking { get; }

        public ILearningStatController Throwing { get; }

        public ILearningStatController Climbing { get; }

        public ILearningStatController Magic { get; }

        public override bool Interact(int x, int y, Interaction interaction)
        {
            throw new System.NotImplementedException();
        }

        public override void Load()
        {
        }

        public override void Unload()
        {
        }

        public override void Update(GameTime time)
        {
        }

        public override void Draw(GameTime time)
        {
        }
    }
}
