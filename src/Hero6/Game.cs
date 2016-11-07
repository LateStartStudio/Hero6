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

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Window.Title = "Hero6";

            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            this.engine = new MonoGameEngine(this.spriteBatch, this.Content);

            this.ui = new UserInterfaceHandler(this.engine, this.GraphicsDevice);

            this.campaign = new CampaignHandler(this.engine, this.ui);

            this.input = new InputHandler();
            this.input.Mouse.MouseButtonUp += this.MouseButtonUp;
            this.input.Touch.SurfacePressed += this.SurfacePressed;

            this.input.Initialize();
            this.ui.Initialize();
            this.campaign.Initialize();

            this.SetScale();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            this.ui.Load(this.Content);
            this.input.Load(this.Content);
            this.campaign.Load(this.Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();

            this.ui.Unload();
            this.input.Unload();
            this.campaign.Unload();

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
                this.scale);

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

            this.scale = Matrix.CreateScale(screenScalingFactor);

            this.input.Scale = new Vector2(this.scale.M11, this.scale.M22);
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
    }
}
