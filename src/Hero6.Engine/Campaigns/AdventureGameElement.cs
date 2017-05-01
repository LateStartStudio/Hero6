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
        public abstract void Load();

        /// <inheritdoc />
        public abstract void Unload();

        /// <inheritdoc />
        public abstract void Update(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly);

        /// <inheritdoc />
        public abstract void Draw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly);

        /// <summary>
        /// Shows a box with the input text.
        /// </summary>
        /// <param name="text">The text to display within the box.</param>
        public void Display(string text)
        {
            this.Campaign.UserInterface.ShowTextBox(text);
        }

        /// <summary>
        /// Invokes the pre load event.
        /// </summary>
        /// <param name="sender">The instance that invoked this event.</param>
        /// <param name="args">The event args bundled with the invocation.</param>
        protected void InvokePreLoad(object sender, LoadEventArgs args)
        {
            this.PreLoad?.Invoke(this, args);
        }

        /// <summary>
        /// Invokes the post load event.
        /// </summary>
        /// <param name="sender">The instance that invoked this event.</param>
        /// <param name="args">The event args bundled with the invocation.</param>
        protected void InvokePostLoad(object sender, LoadEventArgs args)
        {
            this.PostLoad?.Invoke(this, args);
        }

        /// <summary>
        /// Invokes the pre unload event.
        /// </summary>
        /// <param name="sender">The instance that invoked this event.</param>
        /// <param name="args">The event args bundled with the invocation.</param>
        protected void InvokePreUnload(object sender, UnloadEventArgs args)
        {
            this.PreUnload?.Invoke(this, args);
        }

        /// <summary>
        /// Invokes the post unload event.
        /// </summary>
        /// <param name="sender">The instance that invoked this event.</param>
        /// <param name="args">The event args bundled with the invocation.</param>
        protected void InvokePostUnload(object sender, UnloadEventArgs args)
        {
            this.PostUnload?.Invoke(this, args);
        }

        /// <summary>
        /// Invokes the pre update event.
        /// </summary>
        /// <param name="sender">The instance that invoked this event.</param>
        /// <param name="args">The event args bundled with the invocation.</param>
        protected void InvokePreUpdate(object sender, UpdateEventArgs args)
        {
            this.PreUpdate?.Invoke(this, args);
        }

        /// <summary>
        /// Invokes the post update event.
        /// </summary>
        /// <param name="sender">The instance that invoked this event.</param>
        /// <param name="args">The event args bundled with the invocation.</param>
        protected void InvokePostUpdate(object sender, UpdateEventArgs args)
        {
            this.PostUpdate?.Invoke(this, args);
        }

        /// <summary>
        /// Invokes the pre draw event.
        /// </summary>
        /// <param name="sender">The instance that invoked this event.</param>
        /// <param name="args">The event args bundled with the invocation.</param>
        protected void InvokePreDraw(object sender, DrawEventArgs args)
        {
            this.PreDraw?.Invoke(this, args);
        }

        /// <summary>
        /// Invokes the post draw event.
        /// </summary>
        /// <param name="sender">The instance that invoked this event.</param>
        /// <param name="args">The event args bundled with the invocation.</param>
        protected void InvokePostDraw(object sender, DrawEventArgs args)
        {
            this.PostDraw?.Invoke(this, args);
        }
    }
}
