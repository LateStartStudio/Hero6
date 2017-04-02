// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CampaignHandler.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the CampaignHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Campaigns
{
    using System.Collections.Generic;
    using AdventureGame;
    using AdventureGame.Engine;
    using Engine;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using UserInterfaces;
    using XnaContentManager = Microsoft.Xna.Framework.Content.ContentManager;

    public class CampaignHandler : IXnaGameLoop
    {
        private readonly Engine engine;
        private readonly UserInterfaceHandler userInterface;
        private readonly IList<Campaign> campaigns;

        public CampaignHandler(Engine engine, XnaContentManager content, UserInterfaceHandler userInterface)
        {
            this.engine = engine;
            this.userInterface = userInterface;

            this.campaigns = new List<Campaign>
            {
                new RitesOfPassage.RitesOfPassage(
                    this.engine,
                    new MonoGameContentManager(content),
                    this.userInterface.CurrentUI)
            };
            this.CurrentCampaign = this.campaigns[0];
        }

        public Campaign CurrentCampaign
        {
            get; private set;
        }

        public void Initialize()
        {
        }

        public void Load()
        {
            this.CurrentCampaign.Load();
        }

        public void Unload()
        {
            this.CurrentCampaign.Unload();
        }

        public void Update(GameTime gameTime)
        {
            this.CurrentCampaign.Update(
                gameTime.ElapsedGameTime,
                gameTime.TotalGameTime,
                gameTime.IsRunningSlowly);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            this.CurrentCampaign.Draw(
                gameTime.ElapsedGameTime,
                gameTime.TotalGameTime,
                gameTime.IsRunningSlowly);
        }
    }
}
