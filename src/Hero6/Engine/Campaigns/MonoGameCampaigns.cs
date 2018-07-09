// <copyright file="MonoGameCampaigns.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using System.Collections.Generic;
    using GameLoop;
    using Microsoft.Xna.Framework;
    using Utilities.DependencyInjection;

    public class MonoGameCampaigns : ICampaigns, IXnaGameLoop
    {
        private readonly IServices services;
        private readonly IList<Campaign> campaigns;

        public MonoGameCampaigns(IServices services)
        {
            this.services = services;
            this.campaigns = new List<Campaign>();
        }

        public IEnumerable<Campaign> Campaigns => campaigns;

        public Campaign Current { get; set; }

        public void Initialize()
        {
            campaigns.Add(services.Make<Campaign>(typeof(RitesOfPassage.RitesOfPassage)));
            this.Current = campaigns[0];
        }

        public void Load()
        {
            Current.Load();
        }

        public void Unload()
        {
            Current.Unload();
        }

        public void Update(GameTime time)
        {
            Current.Update(time.TotalGameTime, time.ElapsedGameTime, time.IsRunningSlowly);
        }

        public void Draw(GameTime time)
        {
            Current.Draw(time.TotalGameTime, time.ElapsedGameTime, time.IsRunningSlowly);
        }
    }
}
