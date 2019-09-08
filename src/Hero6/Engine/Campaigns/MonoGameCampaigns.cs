// <copyright file="MonoGameCampaigns.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using System.Collections.Generic;
    using System.Linq;
    using GameLoop;
    using LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage;
    using Microsoft.Xna.Framework;
    using Utilities.DependencyInjection;

    public class MonoGameCampaigns : ICampaigns, IXnaGameLoop
    {
        private readonly IServices services;
        private readonly IList<MonoGameCampaignController> campaigns = new List<MonoGameCampaignController>();

        public MonoGameCampaigns(IServices services)
        {
            this.services = services;
        }

        public IEnumerable<CampaignModule> Campaigns => campaigns.Select(c => c.Module);

        public ICampaignModule Current
        {
            get { return CurrentController.Module; }
            set { CurrentController = campaigns.First(c => c.Module == value); }
        }

        public MonoGameCampaignController CurrentController { get; set; }

        public bool Interact(int x, int y, Interaction interaction) => CurrentController.Interact(x, y, interaction);

        public void Initialize()
        {
            campaigns.Add(new MonoGameCampaignController(services.Make<RitesOfPassageModule>(), services));
            CurrentController = campaigns[0];
            ((IXnaGameLoop)CurrentController).Initialize();
        }

        public void Load() => CurrentController.Load();

        public void Unload() => CurrentController.Unload();

        public void Update(GameTime time) => CurrentController.Update(time);

        public void Draw(GameTime time) => CurrentController.Draw(time);
    }
}
