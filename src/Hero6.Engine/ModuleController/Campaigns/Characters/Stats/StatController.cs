// <copyright file="StatController.cs" company="Late Start Studio">
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
    /// API for get-set stat controller.
    /// </summary>
    public class StatController : GameController<IStatController, IStatModule>, IStatController
    {
        private readonly ICampaigns campaigns;
        private readonly Func<int> max;

        private int current;

        /// <summary>
        /// Makes a new instance of the <see cref="StatController"/>.
        /// </summary>
        public StatController(IServiceProvider services, Func<int> max)
            : base(new StatModule(), services)
        {
            campaigns = services.GetService<ICampaigns>();
            this.max = max;
        }

        public event EventHandler<EventArgs> Change;

        public override int Width { get; }

        public override int Height { get; }

        public int Current
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

        public int Max => max();

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
