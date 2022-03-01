// <copyright file="Game.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Extensions;
using LateStartStudio.Hero6.Services.Campaigns;
using LateStartStudio.Hero6.Services.Settings;
using LateStartStudio.Hero6.Services.UserInterfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LateStartStudio.Hero6.MonoGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        private readonly ILogger logger;
        private readonly IGameSettings gameSettings;
        private readonly MonoGameUserInterfaces ui;
        private readonly MonoGameCampaigns campaigns;

        private Matrix transform = Matrix.Identity;

        public Game(
            ILogger<Game> logger,
            IGameSettings gameSettings,
            IUserSettings userSettings,
            MonoGameUserInterfaces ui,
            MonoGameCampaigns campaigns)
        {
            this.logger = logger;
            this.gameSettings = gameSettings;
            this.ui = ui;
            this.campaigns = campaigns;

            Content.RootDirectory = "Content";
            Window.Title = "Hero6";
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            GraphicsDeviceManager.DeviceCreated += (s, a) =>
            {
                SpriteBatch = new SpriteBatch(GraphicsDevice);

                GraphicsDeviceManager.PreferredBackBufferWidth = userSettings.WindowWidth;
                GraphicsDeviceManager.PreferredBackBufferHeight = userSettings.WindowHeight;
                GraphicsDeviceManager.IsFullScreen = userSettings.IsFullScreen;
                GraphicsDeviceManager.GraphicsProfile = GraphicsProfile.Reach;
#if ANDROID
                GraphicsDeviceManager.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
#endif
                GraphicsDeviceManager.ApplyChanges();

                logger.LogInformation("Graphics Device Created.");
                logger.LogInformation($"Graphics Adapter Width {GraphicsDevice.Adapter.CurrentDisplayMode.Width}");
                logger.LogInformation($"Graphics Adapter Height {GraphicsDevice.Adapter.CurrentDisplayMode.Height}");
                logger.LogInformation($"Graphics Adapter Aspect Ratio {GraphicsDevice.Adapter.CurrentDisplayMode.AspectRatio}");
            };
        }

        public GraphicsDeviceManager GraphicsDeviceManager { get; private set; }

        public SpriteBatch SpriteBatch { get; private set; }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            logger.LogInformation("Initializing Hero6 game instance.");

            UpdateScale();
            ui.Initialize();
            campaigns.Initialize();

            base.Initialize();

            logger.LogInformation("Hero6 game instance initialized.");
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            logger.LogInformation("Loading Hero6 game instance.");

            ui.Load();
            campaigns.Load();
            base.LoadContent();

            logger.LogInformation("Hero6 game instance loaded.");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            logger.LogInformation("Unloading Hero6 game instance.");

            Content.Unload();
            ui.Unload();
            campaigns.Unload();
            base.UnloadContent();

            logger.LogInformation("Hero6 game instance unloaded.");
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="time">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime time)
        {
            ui.Update(time);

            if (!gameSettings.IsPaused)
            {
                campaigns.Update(time);
            }

            base.Update(time);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="time">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime time)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin(SpriteSortMode.Deferred, transformMatrix: transform);
            campaigns.Draw(time);
            ui.Draw(time);
            SpriteBatch.End();

            base.Draw(time);
        }

        private void UpdateScale()
        {
            var horScaling = GraphicsDevice.PresentationParameters.BackBufferWidth / gameSettings.NativeWidth;
            var verScaling = GraphicsDevice.PresentationParameters.BackBufferHeight / gameSettings.NativeHeight;
            transform = Matrix.CreateScale(horScaling, verScaling, 1.0f);
            gameSettings.WindowScale = transform.Scale().ToDotNet();
        }
    }
}
