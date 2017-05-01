// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserInterface.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces
{
    using System;

    using LateStartStudio.Hero6.Engine.Assets;
    using LateStartStudio.Hero6.Engine.GameLoop;
    using LateStartStudio.Hero6.Engine.UserInterfaces.Input;

    /// <summary>
    /// An abstract class for defining the user interface of an adventure game.
    /// </summary>
    public abstract class UserInterface : IGameLoop
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserInterface"/> class.
        /// </summary>
        /// <param name="assets">The assets manager of this user interface.</param>
        /// <param name="mouse">The mouse core mechanics.</param>
        protected UserInterface(AssetManager assets, IMouse mouse)
        {
            this.Assets = assets;
            this.Mouse = new Mouse(assets, mouse);
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
        public event EventHandler<GameInteractionEventArgs> GameInteraction;

        /// <summary>
        /// Gets or sets the renderer for the user interface.
        /// </summary>
        /// <value>
        /// The renderer for the user interface.
        /// </value>
        public static Renderer Renderer { get; set; }

        /// <summary>
        /// Gets or sets the native width for rendering of the user interface.
        /// </summary>
        /// <value>
        /// The native width of the user interface.
        /// </value>
        public static int Width { get; set; }

        /// <summary>
        /// Gets or sets the native height for rendering of the user interface.
        /// </summary>
        /// <value>
        /// The native height of the user interface.
        /// </value>
        public static int Height { get; set; }

        /// <summary>
        /// Gets the <see cref="AssetManager"/> of the <see cref="UserInterface"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="AssetManager"/> of the <see cref="UserInterface"/> instance.
        /// </value>
        public AssetManager Assets { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public virtual string Name => "User Interface";

        /// <summary>
        /// Gets the mouse core mechanics.
        /// </summary>
        public Mouse Mouse { get; }

        /// <summary>
        /// Gets or sets a value indicating whether any dialogs are currently visible.
        /// </summary>
        /// <value>
        /// A value indicating whether any dialogs are currently visible.
        /// </value>
        protected virtual bool IsDialogVisible { get; set; }

        /// <inheritdoc />
        public void Load()
        {
            PreLoad?.Invoke(this, new LoadEventArgs(Assets));

            Mouse.Load();

            PostLoad?.Invoke(this, new LoadEventArgs(Assets));
        }

        /// <inheritdoc />
        public void Unload()
        {
            PreUnload?.Invoke(this, new UnloadEventArgs());

            Mouse.Unload();

            PostUnload?.Invoke(this, new UnloadEventArgs());
        }

        /// <inheritdoc />
        public void Update(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            PreUpdate?.Invoke(this, new UpdateEventArgs(total, elapsed, isRunningSlowly));

            Mouse.Update(total, elapsed, isRunningSlowly);

            PostUpdate?.Invoke(this, new UpdateEventArgs(total, elapsed, isRunningSlowly));
        }

        /// <inheritdoc />
        public void Draw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            PreDraw?.Invoke(this, new DrawEventArgs(total, elapsed, isRunningSlowly, Renderer));

            Mouse.Draw(total, elapsed, isRunningSlowly);

            PostDraw?.Invoke(this, new DrawEventArgs(total, elapsed, isRunningSlowly, Renderer));
        }

        /// <summary>
        /// Shows a text box with the input text.
        /// </summary>
        /// <param name="text">The input text within the text box.</param>
        public abstract void ShowTextBox(string text);

        /// <summary>
        /// Invokes the post draw event.
        /// </summary>
        /// <param name="sender">The instance that invoked this event.</param>
        /// <param name="args">The event args bundled with the invocation.</param>
        protected void InvokeGameInteraction(object sender, GameInteractionEventArgs args)
        {
            GameInteraction?.Invoke(sender, args);
        }
    }
}
