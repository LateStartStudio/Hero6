// <copyright file="MonoGameStatsController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Services.Campaigns;
using LateStartStudio.Hero6.Services.DependencyInjection;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Characters.Stats
{
    public class MonoGameStatsController : StatsController
    {
        public MonoGameStatsController(IServiceLocator services) : base(services)
        {
            var campaigns = services.Get<ICampaigns>();
            Health = new Hero6StatController(services, () => (int)((Strength.Current * 0.4) + (Vitality.Current * 0.6)));
            Stamina = new Hero6StatController(services, () => (int)((Vitality.Current * 0.4) + (Agility.Current * 0.6)));
            Mana = new Hero6StatController(services, () => Magic.Current > 0 ? (int)((Intelligence.Current * 0.4) + (Magic.Current * 0.6)) : 0);
            Humans = new Hero6StatController(services, () => campaigns.Current.StatCap);
            Sidhe = new Hero6StatController(services, () => campaigns.Current.StatCap);
            Giants = new Hero6StatController(services, () => campaigns.Current.StatCap);
            Strength = new Hero6LearningStatController(services);
            Intelligence = new Hero6LearningStatController(services);
            Agility = new Hero6LearningStatController(services);
            Vitality = new Hero6LearningStatController(services);
            Luck = new Hero6LearningStatController(services);
            WeaponUse = new Hero6LearningStatController(services);
            Parry = new Hero6LearningStatController(services);
            Dodge = new Hero6LearningStatController(services);
            Stealth = new Hero6LearningStatController(services);
            LockPicking = new Hero6LearningStatController(services);
            Throwing = new Hero6LearningStatController(services);
            Climbing = new Hero6LearningStatController(services);
            Magic = new Hero6LearningStatController(services);
        }

        public override int Width { get; }

        public override int Height { get; }

        public override IStatController Health { get; }

        public override IStatController Stamina { get; }

        public override IStatController Mana { get; }

        public override IStatController Humans { get; }

        public override IStatController Sidhe { get; }

        public override IStatController Giants { get; }

        public override ILearningStatController Strength { get; }

        public override ILearningStatController Intelligence { get; }

        public override ILearningStatController Agility { get; }

        public override ILearningStatController Vitality { get; }

        public override ILearningStatController Luck { get; }

        public override ILearningStatController WeaponUse { get; }

        public override ILearningStatController Parry { get; }

        public override ILearningStatController Dodge { get; }

        public override ILearningStatController Stealth { get; }

        public override ILearningStatController LockPicking { get; }

        public override ILearningStatController Throwing { get; }

        public override ILearningStatController Climbing { get; }

        public override ILearningStatController Magic { get; }

        public override bool Interact(int x, int y, Interaction interaction)
        {
            throw new System.NotImplementedException();
        }
    }
}
