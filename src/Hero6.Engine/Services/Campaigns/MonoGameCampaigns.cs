// <copyright file="MonoGameCampaigns.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using LateStartStudio.Hero6.ModuleController.Campaigns;
using LateStartStudio.Hero6.MonoGame.GameLoop;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;

namespace LateStartStudio.Hero6.Services.Campaigns
{
    public class MonoGameCampaigns : ICampaigns, IXnaGameLoop
    {
        private readonly IServiceProvider services;
        private readonly IList<CampaignController> campaigns = new List<CampaignController>();

        public MonoGameCampaigns(IServiceProvider services)
        {
            this.services = services;
        }

        public IEnumerable<ICampaignModule> Campaigns => campaigns.Select(c => c.Module);

        public ICampaignModule Current
        {
            get { return CurrentController.Module; }
            set { CurrentController = campaigns.First(c => c.Module == value); }
        }

        public CampaignController CurrentController { get; set; }

        public void Add(ICampaignModule module) => campaigns.Add(ActivatorUtilities.CreateInstance<CampaignController>(services, module));

        public bool Interact(int x, int y, Interaction interaction) => CurrentController.Interact(x, y, interaction);

        public void Initialize()
        {
            CurrentController = campaigns[0];
            CurrentController.Initialize();
        }

        public void Load() => CurrentController.Load();

        public void Unload() => CurrentController.Unload();

        public void Update(GameTime time) => CurrentController.Update(time);

        public void Draw(GameTime time) => CurrentController.Draw(time);
    }
}
