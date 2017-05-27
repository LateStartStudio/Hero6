// <copyright file="AdventureGameElement.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using System;
    using Assets;
    using Assets.Graphics;
    using GameLoop;

    /// <summary>
    /// An abstract class with all common functionality for any game element.
    /// </summary>
    public abstract class AdventureGameElement : IGameLoop
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdventureGameElement"/> class.
        /// </summary>
        /// <param name="campaign">The campaign this element belongs to.</param>
        protected AdventureGameElement(Campaign campaign)
        {
            this.Campaign = campaign;
            this.IsVisible = true;
        }

        /// <inheritdoc />
        public event EventHandler<LoadEventArgs> PreLoad;

        /// <inheritdoc />
        public event EventHandler<LoadEventArgs> PostLoad;

        /// <inheritdoc />
        public event EventHandler<UnloadEventArgs> PreUnload;

        /// <inheritdoc />
        public event EventHandler<UnloadEventArgs> PostUnload;

        /// <inheritdoc />
        public event EventHandler<UpdateEventArgs> PreUpdate;

        /// <inheritdoc />
        public event EventHandler<UpdateEventArgs> PostUpdate;

        /// <inheritdoc />
        public event EventHandler<DrawEventArgs> PreDraw;

        /// <inheritdoc />
        public event EventHandler<DrawEventArgs> PostDraw;

        /// <summary>
        /// Gets or sets the location of the element.
        /// </summary>
        /// <value>
        /// The location of the element.
        /// </value>
        public virtual Point Location
        {
            get; set;
        }

        /// <summary>
        /// Gets the width of the element.
        /// </summary>
        /// <value>
        /// The width of the element.
        /// </value>
        public abstract int Width
        {
            get;
        }

        /// <summary>
        /// Gets the height of the element.
        /// </summary>
        /// <value>
        /// The height of the element.
        /// </value>
        public abstract int Height
        {
            get;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the element is currently visible.
        /// </summary>
        /// <value>
        /// True if visible; false otherwise.
        /// </value>
        public bool IsVisible
        {
            get; set;
        }

        /// <summary>
        /// Gets the campaign this element belongs to.
        /// </summary>
        /// <value>
        /// The campaign this element belongs to.
        /// </value>
        protected Campaign Campaign
        {
            get; private set;
        }

        /// <summary>
        /// Gets the <see cref="AssetManager"/> associated with this
        /// <see cref="AdventureGameElement"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="AssetManager"/> associated with this
        /// <see cref="AdventureGameElement"/> instance.
        /// </value>
        protected AssetManager Assets => this.Campaign.Assets;

        /// <summary>
        /// Called on user interaction with the game at input coordinates.
        /// </summary>
        /// <param name="x">The user input x coordinate.</param>
        /// <param name="y">The user input y coordinate.</param>
        /// <param name="interaction">The interaction to perform.</param>
        /// <returns>True if the user interacted with this element; false otherwise.</returns>
        public abstract bool Interact(int x, int y, Interaction interaction);

        /// <inheritdoc />
        public void Load()
        {
            PreLoad?.Invoke(this, new LoadEventArgs(Assets));

            InternalLoad();

            PostLoad?.Invoke(this, new LoadEventArgs(Assets));
        }

        /// <inheritdoc />
        public void Unload()
        {
            PreUnload?.Invoke(this, new UnloadEventArgs());

            InternalUnload();

            PostUnload?.Invoke(this, new UnloadEventArgs());
        }

        /// <inheritdoc />
        public void Update(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            PreUpdate?.Invoke(this, new UpdateEventArgs(total, elapsed, isRunningSlowly));

            InternalUpdate(total, elapsed, isRunningSlowly);

            PostUpdate?.Invoke(this, new UpdateEventArgs(total, elapsed, isRunningSlowly));
        }

        /// <inheritdoc />
        public void Draw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            PreDraw?.Invoke(this, new DrawEventArgs(total, elapsed, isRunningSlowly, Campaign.Renderer));

            InternalDraw(total, elapsed, isRunningSlowly);

            PostDraw?.Invoke(this, new DrawEventArgs(total, elapsed, isRunningSlowly, Campaign.Renderer));
        }

        /// <summary>
        /// Shows a box with the input text.
        /// </summary>
        /// <param name="text">The text to display within the box.</param>
        public void Display(string text)
        {
            this.Campaign.UserInterface.ShowTextBox(text);
        }

        /// <summary>
        /// Loads all assets.
        /// </summary>
        protected abstract void InternalLoad();

        /// <summary>
        /// Unloads all assets.
        /// </summary>
        protected abstract void InternalUnload();

        /// <summary>
        /// Updates game logic.
        /// </summary>
        /// <param name="total">Total time since game was started.</param>
        /// <param name="elapsed">Time since previous frame.</param>
        /// <param name="isRunningSlowly">
        /// A value representing whether the game is running slowly or not.
        /// </param>
        protected abstract void InternalUpdate(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly);

        /// <summary>
        /// Draw frame to screen.
        /// </summary>
        /// <param name="total">Total time since game was started.</param>
        /// <param name="elapsed">Time since previous frame.</param>
        /// <param name="isRunningSlowly">
        /// A value representing whether the game is running slowly or not.
        /// </param>
        protected abstract void InternalDraw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly);
    }
}
