// <copyright file="MonoGameStatsController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Characters.Stats
{
    using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;

    public class MonoGameStatsController : StatsController
    {
        public MonoGameStatsController(IServices services)
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

        public override StatController Health { get; }

        public override StatController Stamina { get; }

        public override StatController Mana { get; }

        public override StatController Humans { get; }

        public override StatController Sidhe { get; }

        public override StatController Giants { get; }

        public override LearningStatController Strength { get; }

        public override LearningStatController Intelligence { get; }

        public override LearningStatController Agility { get; }

        public override LearningStatController Vitality { get; }

        public override LearningStatController Luck { get; }

        public override LearningStatController WeaponUse { get; }

        public override LearningStatController Parry { get; }

        public override LearningStatController Dodge { get; }

        public override LearningStatController Stealth { get; }

        public override LearningStatController LockPicking { get; }

        public override LearningStatController Throwing { get; }

        public override LearningStatController Climbing { get; }

        public override LearningStatController Magic { get; }

        public override bool Interact(int x, int y, Interaction interaction)
        {
            throw new System.NotImplementedException();
        }
    }
}
