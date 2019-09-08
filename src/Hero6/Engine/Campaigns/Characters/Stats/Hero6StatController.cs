// <copyright file="Hero6StatController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;

namespace LateStartStudio.Hero6.Engine.Campaigns.Characters.Stats
{
    public class Hero6StatController : StatController
    {
        private readonly ICampaigns campaigns;
        private readonly Func<int> max;

        private int current;

        public Hero6StatController(IServices services, Func<int> max) : base(services)
        {
            campaigns = services.Get<ICampaigns>();
            this.max = max;
        }

        public override event EventHandler<EventArgs> Change;

        public override int Width { get; }

        public override int Height { get; }

        public override int Current
        {
            get
            {
                return current;
            }

            set
            {
                current = value > campaigns.Current.StatCap ? campaigns.Current.StatCap : value;
                Change?.Invoke(this, EventArgs.Empty);
            }
        }

        public override int Max => max();

        public override bool Interact(int x, int y, Interaction interaction)
        {
            throw new System.NotImplementedException();
        }
    }
}
