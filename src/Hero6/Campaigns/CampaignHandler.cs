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
    using AdventureGame;
    using Engine;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class CampaignHandler : IXnaGameLoop
    {
        private readonly SpriteBatch spriteBatch;
        private readonly ContentManager contentManager;

        public CampaignHandler(SpriteBatch spriteBatch, ContentManager contentManager)
        {
            this.spriteBatch = spriteBatch;
            this.contentManager = contentManager;
        }

        public Campaign CurrentCampaign
        {
            get; set;
        }

        public void Initialize()
        {
        }

        public void Load(ContentManager contentManager)
        {
            this.CurrentCampaign = new RitesOfPassage.RitesOfPassage(new MonoGameEngine(this.spriteBatch, this.contentManager));

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
