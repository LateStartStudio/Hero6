// <copyright file="Game.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6
{
    using System;
    using System.IO;
    using System.Reflection;
    using Engine.Assets;
    using Engine.Campaigns;
    using Engine.UserInterfaces;
    using Engine.Utilities;
    using Engine.Utilities.Logger;
    using Engine.Utilities.Settings;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        private Renderer renderer;
        private UserInterfaceHandler ui;
        private CampaignHandler campaign;
        private SpriteBatch spriteBatch;

        static Game()
        {
            Util.Logger = new LogFourNet(LogFileName);
            Util.Logger.Info($"Hero6 {GraphicsApi} v{Assembly.GetExecutingAssembly().GetName().Version} Log");
            Util.Logger.Info("Forums: http://www.hero6.org/forum/");
            Util.Logger.Info("Bug Tracker: https://github.com/LateStartStudio/Hero6/issues");
            Util.Logger.Info("E-mail: hero6lives@gmail.com");

            Util.UserSettings = new UserSettings();
        }

        public Game()
        {
            Util.Logger.Info("Creating Hero6 Game Instance.");

            Graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = Util.UserSettings.WindowWidth,
                PreferredBackBufferHeight = Util.UserSettings.WindowHeight,
                IsFullScreen = Util.UserSettings.IsFullScreen,
                GraphicsProfile = GraphicsProfile.Reach,
#if ANDROID
                SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight
#endif
            };
            Graphics.DeviceCreated += this.GraphicsOnDeviceCreated;

            Content.RootDirectory = "Content";

            Util.Logger.Info("Hero6 Game Instance Created.");
        }

        public static string UserFilesDir => string.Format(
            "{0}{1}Hero6{1}",
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            Path.DirectorySeparatorChar);

        public static string LogFilesDir => $"{UserFilesDir}Logs{Path.DirectorySeparatorChar}";

        public static string LogFileName
        {
            get
            {
                DateTime date = DateTime.Now;
                string filename = $"Hero6-Log-{date.Day}-{date.Month}-{date.Year}-{date.Hour}-{date.Minute}-{date.Second}.txt";

                return $"{LogFilesDir}{filename}";
            }
        }

        public static string GraphicsApi
        {
            get
            {
#if WINDOWSDX
                return "WindowsDX";
#elif DESKTOPGL
                return "DesktopGL";
#elif ANDROID
                return "Android";
#else
                return "Invalid project config";
#endif
            }
        }

        public static Vector2 NativeGameResolution { get; } = new Vector2(320, 240);

        public static GraphicsDeviceManager Graphics { get; private set; }

        public static Matrix Transform { get; set; } = Matrix.Identity;

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Util.Logger.Info("Initializing Hero6 game instance.");

            Window.Title = "Hero6";

            this.SetScale();

            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            this.renderer = new MonoGameRenderer(this.spriteBatch);

            this.ui = new UserInterfaceHandler(this.renderer, this.GraphicsDevice, this.Content);

            this.campaign = new CampaignHandler(this.renderer, this.Content, this.ui);

            this.ui.Initialize();
            this.campaign.Initialize();

            Util.Logger.Info("Hero6 game instance initialized.");

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Util.Logger.Info("Loading Hero6 game instance.");

            this.ui.Load();
            this.campaign.Load();

            Util.Logger.Info("Hero6 game instance loaded.");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Util.Logger.Info("Unloading Hero6 game instance.");

            Content.Unload();

            this.ui.Unload();
            this.campaign.Unload();

            Util.Logger.Info("Hero6 game instance unloaded.");

            base.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="time">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime time)
        {
            this.ui.Update(time);
            this.campaign.Update(time);

            base.Update(time);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="time">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime time)
        {
            GraphicsDevice.Clear(Color.Transparent);

            this.spriteBatch.Begin(
                SpriteSortMode.Deferred,
                null,
                null,
                null,
                null,
                null,
                Transform);

            this.campaign.Draw(time, this.spriteBatch);

            this.spriteBatch.End();

            // Independent draw
            this.ui.Draw(time, this.spriteBatch);

            base.Draw(time);
        }

        private void SetScale()
        {
            float horScaling = GraphicsDevice.PresentationParameters.BackBufferWidth / NativeGameResolution.X;
            float verScaling = GraphicsDevice.PresentationParameters.BackBufferHeight / NativeGameResolution.Y;
            Vector3 screenScalingFactor = new Vector3(horScaling, verScaling, 1);

            Transform = Matrix.CreateScale(screenScalingFactor);
        }

        private void GraphicsOnDeviceCreated(object sender, EventArgs eventArgs)
        {
            Util.Logger.Info("Graphics Device Created.");
            Util.Logger.Info($"Graphics Adapter Width {GraphicsDevice.Adapter.CurrentDisplayMode.Width}");
            Util.Logger.Info($"Graphics Adapter Height {GraphicsDevice.Adapter.CurrentDisplayMode.Height}");
            Util.Logger.Info($"Graphics Adapter Aspect Ratio {GraphicsDevice.Adapter.CurrentDisplayMode.AspectRatio}");
        }
    }
}
