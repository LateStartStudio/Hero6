// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Game.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the Game type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6
{
    using System;
    using Campaigns;
    using Engine;
    using Input;
    using Input.Mouse;
    using Input.TouchSurface;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using UserInterface;
    using Utilities;
    using AdventureGameEngine = AdventureGame.Engine.Engine;

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        private static readonly Vector2 NativeGameResolution = new Vector2(320, 240);

        private AdventureGameEngine engine;
        private UserInterfaceHandler ui;
        private CampaignHandler campaign;
        private InputHandler input;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Matrix scale;

        public Game()
        {
            Logger.Info("Creating Hero6 Game Instance.");

            this.graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = (int)NativeGameResolution.X * 3,
                PreferredBackBufferHeight = (int)NativeGameResolution.Y * 3,
                GraphicsProfile = GraphicsProfile.Reach,
#if ANDROID
                IsFullScreen = true,
                SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight
#endif
            };
            this.graphics.DeviceCreated += this.GraphicsOnDeviceCreated;

            Content.RootDirectory = "Content";

            Logger.Info("Hero6 Game Instance Created.");
        }

        public static ILogger Logger { get; } = new LogFourNet();

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

        private Matrix Scale
        {
            get
            {
                return this.scale;
            }

            set
            {
                this.scale = value;

                if (this.input != null)
                {
                    this.input.Scale = new Vector2(value.M11, value.M22);
                }

                if (this.ui != null)
                {
                    this.ui.Scale = new AdventureGame.Engine.Graphics.Vector2(value.M11, value.M22);
                }
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
            Logger.Info("Initializing Hero6 game instance.");

            Window.Title = "Hero6";

            this.SetScale();

            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            this.engine = new MonoGameEngine(this.spriteBatch);

            this.ui = new UserInterfaceHandler(
                this.engine,
                this.GraphicsDevice,
                this.Content,
                (int)NativeGameResolution.X,
                (int)NativeGameResolution.Y,
                this.Scale);

            this.campaign = new CampaignHandler(this.engine, this.Content, this.ui);

            this.input = new InputHandler(this.Scale, this.Content);
            this.input.Mouse.MouseButtonUp += this.MouseButtonUp;
            this.input.Touch.SurfacePressed += this.SurfacePressed;

            this.input.Initialize();
            this.ui.Initialize();
            this.campaign.Initialize();

            Logger.Info("Hero6 game instance initialized.");

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Logger.Info("Loading Hero6 game instance.");

            this.ui.Load();
            this.input.Load();
            this.campaign.Load();

            Logger.Info("Hero6 game instance loaded.");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Logger.Info("Unloading Hero6 game instance.");

            Content.Unload();

            this.ui.Unload();
            this.input.Unload();
            this.campaign.Unload();

            Logger.Info("Hero6 game instance unloaded.");

            base.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            this.ui.Update(gameTime);
            this.input.Update(gameTime);
            this.campaign.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Transparent);

            this.spriteBatch.Begin(
                SpriteSortMode.Deferred,
                null,
                null,
                null,
                null,
                null,
                this.Scale);

            this.campaign.Draw(gameTime, this.spriteBatch);
            this.input.Draw(gameTime, this.spriteBatch);

            this.spriteBatch.End();

            // Independent draw
            this.ui.Draw(gameTime, this.spriteBatch);

            base.Draw(gameTime);
        }

        private void SetScale()
        {
            float horScaling = GraphicsDevice.PresentationParameters.BackBufferWidth / NativeGameResolution.X;
            float verScaling = GraphicsDevice.PresentationParameters.BackBufferHeight / NativeGameResolution.Y;
            Vector3 screenScalingFactor = new Vector3(horScaling, verScaling, 1);

            this.Scale = Matrix.CreateScale(screenScalingFactor);
        }

        private void MouseButtonUp(object sender, MouseButtonUpEventArgs e)
        {
            switch (e.MouseButton)
            {
                case MouseButton.Left:
                    this.campaign.CurrentCampaign.CurrentRoom.Interact(e.Position.X, e.Position.Y);
                    break;
                case MouseButton.Middle:
                case MouseButton.Right:
                    break;
                default:
                    throw new NotSupportedException("Switch case reached somewhere unexpected.");
            }
        }

        private void SurfacePressed(object sender, SurfacePressedEventArgs e)
        {
            this.campaign.CurrentCampaign.CurrentRoom.Interact(e.Position.X, e.Position.Y);
        }

        private void GraphicsOnDeviceCreated(object sender, EventArgs eventArgs)
        {
            Logger.Info("Graphics Device Created.");
            Logger.Info($"Graphics Adapter Width {GraphicsDevice.Adapter.CurrentDisplayMode.Width}");
            Logger.Info($"Graphics Adapter Height {GraphicsDevice.Adapter.CurrentDisplayMode.Height}");
            Logger.Info($"Graphics Adapter Aspect Ratio {GraphicsDevice.Adapter.CurrentDisplayMode.AspectRatio}");
        }
    }
}
