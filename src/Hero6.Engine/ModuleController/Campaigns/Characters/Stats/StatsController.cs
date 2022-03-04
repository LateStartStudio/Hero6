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
        public StatsController(IServiceProvider services)
            : base(new StatsModule(), services)
        {
            var campaigns = services.GetService<ICampaigns>();
            Health = new StatController(services, () => (int)((Strength.Current * 0.4) + (Vitality.Current * 0.6)));
            Stamina = new StatController(services, () => (int)((Vitality.Current * 0.4) + (Agility.Current * 0.6)));
            Mana = new StatController(services, () => Magic.Current > 0 ? (int)((Intelligence.Current * 0.4) + (Magic.Current * 0.6)) : 0);
            Humans = new StatController(services, () => campaigns.Current.StatCap);
            Sidhe = new StatController(services, () => campaigns.Current.StatCap);
            Giants = new StatController(services, () => campaigns.Current.StatCap);
            Strength = new LearningStatController(services);
            Intelligence = new LearningStatController(services);
            Agility = new LearningStatController(services);
            Vitality = new LearningStatController(services);
            Luck = new LearningStatController(services);
            WeaponUse = new LearningStatController(services);
            Parry = new LearningStatController(services);
            Dodge = new LearningStatController(services);
            Stealth = new LearningStatController(services);
            LockPicking = new LearningStatController(services);
            Throwing = new LearningStatController(services);
            Climbing = new LearningStatController(services);
            Magic = new LearningStatController(services);
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
