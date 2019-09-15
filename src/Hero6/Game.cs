// <copyright file="Game.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.Services.Campaigns;
using LateStartStudio.Hero6.Services.ControllerRepository;
using LateStartStudio.Hero6.Services.DependencyInjection;
using LateStartStudio.Hero6.Services.DotNetWrappers;
using LateStartStudio.Hero6.Services.Logger;
using LateStartStudio.Hero6.Services.PlatformInfo;
using LateStartStudio.Hero6.Services.Settings;
using LateStartStudio.Hero6.Services.UserInterfaces;
using LateStartStudio.Hero6.Services.UserInterfaces.Input.Mouse;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LateStartStudio.Hero6
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        private static Logger logger;

        private readonly GameSettings gameSettings;
        private readonly MonoGameUserInterfaces ui;
        private readonly MonoGameCampaigns campaign;

        private SpriteBatch spriteBatch;
        private Matrix transform = Matrix.Identity;

        private Game()
        {
            Content.RootDirectory = "Content";
            Window.Title = "Hero6";
            var services = new MonoGameServiceLocator(Services);
            services.Add<IPlatformInfo, PlatformInfo>();
            services.Add<IServiceLocator>(services);
            services.Add<IFileWrapper, FileWrapper>();
            services.Add<IDirectoryWrapper, DirectoryWrapper>();
            ui = services.Make<MonoGameUserInterfaces>();
            services.Add<IUserInterfaces>(ui);
            gameSettings = new GameSettings(ui);
            services.Add<IGameSettings>(gameSettings);
            var userSettings = services.Make<UserSettings>(typeof(UserSettings));
            services.Add<IUserSettings>(userSettings);
            services.Add<ILoggerCore, LoggerCore>();
            logger = services.Make<Logger>(typeof(Logger));
            services.Add<IMouseCore, MouseCore>();
            services.Add<ILogger>(logger);
            services.Add<IControllerRepository, ControllerRepositoryProvider>();
            services.Add(Content);
            campaign = services.Make<MonoGameCampaigns>();
            services.Add<ICampaigns>(campaign);
            services.Add<IMouse, Mouse>();

            var graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = userSettings.WindowWidth,
                PreferredBackBufferHeight = userSettings.WindowHeight,
                IsFullScreen = userSettings.IsFullScreen,
                GraphicsProfile = GraphicsProfile.Reach,
#if ANDROID
                SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight
#endif
            };
            graphics.DeviceCreated += (s, a) =>
            {
                spriteBatch = new SpriteBatch(GraphicsDevice);
                services.Add(graphics);
                services.Add(spriteBatch);

                logger.Info("Graphics Device Created.");
                logger.Info($"Graphics Adapter Width {GraphicsDevice.Adapter.CurrentDisplayMode.Width}");
                logger.Info($"Graphics Adapter Height {GraphicsDevice.Adapter.CurrentDisplayMode.Height}");
                logger.Info($"Graphics Adapter Aspect Ratio {GraphicsDevice.Adapter.CurrentDisplayMode.AspectRatio}");
            };

            logger.Info("Hero6 Game Instance Created.");
        }

        public static void Start()
        {
            try
            {
                using (var game = new Game())
                {
                    game.Run();
                }
            }
#if !DEBUG
            catch (Exception e)
            {
                logger.Error("Hero6 has crashed, logging stack trace.");
                logger.Exception(e);
                logger.WillDeleteLogOnDispose = false;
                var p = new System.Diagnostics.Process { StartInfo = { UseShellExecute = true, FileName = logger.Filename } };
                p.Start();
            }
#endif
            finally
            {
            }
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            logger.Initialize();
            logger.Info("Initializing Hero6 game instance.");

            UpdateScale();
            ui.Initialize();
            campaign.Initialize();

            base.Initialize();

            logger.Info("Hero6 game instance initialized.");
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            logger.Info("Loading Hero6 game instance.");

            ui.Load();
            campaign.Load();
            base.LoadContent();

            logger.Info("Hero6 game instance loaded.");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            logger.Info("Unloading Hero6 game instance.");

            Content.Unload();
            ui.Unload();
            campaign.Unload();
            base.UnloadContent();

            logger.Info("Hero6 game instance unloaded.");
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
                campaign.Update(time);
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

            spriteBatch.Begin(SpriteSortMode.Deferred, transformMatrix: transform);
            campaign.Draw(time);
            ui.Draw(time);
            spriteBatch.End();

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
