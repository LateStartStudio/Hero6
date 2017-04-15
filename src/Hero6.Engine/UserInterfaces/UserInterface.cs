// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserInterface.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the UserInterface type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Engine.UserInterfaces
{
    using System;
    using Assets;
    using Assets.Graphics;
    using GameLoop;

    /// <summary>
    /// An abstract class for defining the user interface of an adventure game.
    /// </summary>
    public abstract class UserInterface : IGameLoop
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserInterface"/> class.
        /// </summary>
        /// <param name="width">The native width to render the user interface.</param>
        /// <param name="height">The native height to render the user interface.</param>
        /// <param name="scale">The scale of the heigth and width.</param>
        /// <param name="renderer">The renderer for the user interface.</param>
        /// <param name="assets">The assets manager of this user interface.</param>
        protected UserInterface(int width, int height, Vector2 scale, Renderer renderer, AssetManager assets)
        {
            this.Width = width;
            this.Height = height;
            this.Scale = scale;
            this.Renderer = renderer;
            this.Assets = assets;
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
        /// Occurs when any mouse button is clicked.
        /// </summary>
        public event EventHandler<UserInteractionEventArgs> MouseButtonClick;

        /// <summary>
        /// Gets the <see cref="AssetManager"/> of the <see cref="UserInterface"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="AssetManager"/> of the <see cref="UserInterface"/> instance.
        /// </value>
        public AssetManager Assets { get; }

        /// <summary>
        /// Gets the renderer for the user interface.
        /// </summary>
        /// <value>
        /// The renderer for the user interface.
        /// </value>
        public Renderer Renderer
        {
            get; private set;
        }

        /// <summary>
        /// Gets or sets the internal engine for the user interface.
        /// </summary>
        /// <value>
        /// The internal engine for the user interface.
        /// </value>
        public object UserInterfaceEngine
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the native width for rendering of the user interface.
        /// </summary>
        /// <value>
        /// The native width of the user interface.
        /// </value>
        public int Width
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the native height for rendering of the user interface.
        /// </summary>
        /// <value>
        /// The native height of the user interface.
        /// </value>
        public int Height
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the scaling of the width and height of the user interface.
        /// </summary>
        /// <value>
        /// The scaling of the width and height of the user interface.
        /// </value>
        public Vector2 Scale
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether any dialogs are currently visible.
        /// </summary>
        /// <value>
        /// A value indicating whether any dialogs are currently visible.
        /// </value>
        protected virtual bool IsDialogVisible
        {
            get; set;
        }

        /// <inheritdoc />
        public abstract void Load();

        /// <inheritdoc />
        public abstract void Unload();

        /// <inheritdoc />
        public abstract void Update(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly);

        /// <inheritdoc />
        public abstract void Draw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly);

        /// <summary>
        /// Shows a text box with the input text.
        /// </summary>
        /// <param name="text">The input text within the text box.</param>
        public abstract void ShowTextBox(string text);

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

        /// <summary>
        /// Invokes the post draw event.
        /// </summary>
        /// <param name="sender">The instance that invoked this event.</param>
        /// <param name="args">The event args bundled with the invocation.</param>
        protected void InvokeMouseButtonClick(object sender, UserInteractionEventArgs args)
        {
            this.MouseButtonClick?.Invoke(sender, args);
        }
    }
}
