﻿// <copyright file="Game.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using Engine.Campaigns;
    using Engine.UserInterfaces;
    using Engine.UserInterfaces.Input;
    using Engine.UserInterfaces.SierraVga.Windows;
    using Engine.Utilities.DependencyInjection;
    using Engine.Utilities.Logger;
    using Engine.Utilities.Settings;
    using log4net;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        private static ILogger logger;

        private readonly GameSettings gameSettings;

        private MonoGameUserInterfaces ui;
        private MonoGameCampaigns campaign;
        private SpriteBatch spriteBatch;

        private Game()
        {
            Content.RootDirectory = "Content";
            var services = new MonoGameServices(Services);
            gameSettings = new GameSettings();
            services.Add<IGameSettings>(gameSettings);
            var userSettings = services.Make<UserSettings>(typeof(UserSettings));
            services.Add<IUserSettings>(userSettings);
            logger = services.Make<LogFourNet>(typeof(LogFourNet));
            services.Add<IMouse, MonoGameMouse>();
            services.Add(logger);
            services.Add(Content);

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
                this.spriteBatch = new SpriteBatch(GraphicsDevice);
                services.Add(graphics);
                services.Add(spriteBatch);
                services.Add<IUserInterfaceGenerator, MonoGameUserInterfaceGenerator>();
                this.campaign = new MonoGameCampaigns(services);
                services.Add<ICampaigns>(campaign);
                this.ui = new MonoGameUserInterfaces(services);
                services.Add<IUserInterfaces>(ui);

                logger.Info("Graphics Device Created.");
                logger.Info($"Graphics Adapter Width {GraphicsDevice.Adapter.CurrentDisplayMode.Width}");
                logger.Info($"Graphics Adapter Height {GraphicsDevice.Adapter.CurrentDisplayMode.Height}");
                logger.Info($"Graphics Adapter Aspect Ratio {GraphicsDevice.Adapter.CurrentDisplayMode.AspectRatio}");
            };

            logger.Info("Hero6 Game Instance Created.");
        }

        public static string UserFilesDir => string.Format(
            "{0}{1}Hero6{1}",
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            Path.DirectorySeparatorChar);

        public static string GraphicsApi
        {
            get
            {
#if DESKTOPGL
                return "DesktopGL";
#elif ANDROID
                return "Android";
#else
                return "Invalid project config";
#endif
            }
        }

        public static Matrix Transform { get; set; } = Matrix.Identity;

        public static void Start()
        {
            try
            {
                using (var game = new Game())
                {
                    game.Run();
                    throw new Exception();
                }
            }
#if !DEBUG
            catch (Exception e)
            {
                logger.Error("Hero6 has crashed, logging stack strace.", e);
                logger.WillDeleteLogOnDispose = false;
                var p = new Process { StartInfo = { UseShellExecute = true, FileName = logger.Filename } };
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
            logger.Info("Initializing Hero6 game instance.");

            Window.Title = "Hero6";
            SetScale();
            ui.Initialize();
            campaign.Initialize();
            ui.Current.GetWindow<StatusBar>().IsVisible = true;

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
            campaign.Update(time);

            base.Update(time);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="time">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime time)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, transformMatrix: Transform);
            campaign.Draw(time);
            ui.Draw(time);
            spriteBatch.End();

            base.Draw(time);
        }

        private void SetScale()
        {
            var horScaling = GraphicsDevice.PresentationParameters.BackBufferWidth / gameSettings.NativeWidth;
            var verScaling = GraphicsDevice.PresentationParameters.BackBufferHeight / gameSettings.NativeHeight;
            Transform = Matrix.CreateScale(horScaling, verScaling, 1.0f);
        }
    }
}
