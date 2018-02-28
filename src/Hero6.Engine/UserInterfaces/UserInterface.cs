// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserInterface.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Assets;
    using Controls;
    using GameLoop;
    using Input;
    using Utilities.DependencyInjection;

    /// <summary>
    /// An abstract class for defining the user interface of an adventure game.
    /// </summary>
    public abstract class UserInterface : IGameLoop
    {
        private static readonly IAssetsFactory AssetsFactory;

        static UserInterface()
        {
            AssetsFactory = ServicesBank.Instance.Get<IAssetsFactory>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserInterface"/> class.
        /// </summary>
        /// <param name="mouse">The mouse core mechanics.</param>
        protected UserInterface(IMouse mouse)
        {
            this.Assets = AssetsFactory.Make();
            this.Mouse = new Mouse(Assets, mouse);
            this.Mouse.ButtonUp += MouseOnButtonUp;
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
        /// Gets the <see cref="IAssets"/> of the <see cref="UserInterface"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="IAssets"/> of the <see cref="UserInterface"/> instance.
        /// </value>
        public IAssets Assets { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public virtual string Name => "User Interface";

        /// <summary>
        /// Gets the mouse core mechanics.
        /// </summary>
        public Mouse Mouse { get; }

        /// <summary>
        /// Gets all the windows.
        /// </summary>
        protected List<Window> Windows { get; } = new List<Window>();

        /// <summary>
        /// Gets all the dialogs.
        /// </summary>
        protected List<Dialog> Dialogs { get; } = new List<Dialog>();

        /// <summary>
        /// Gets a value indicating whether any dialogs are currently visible.
        /// </summary>
        /// <value>
        /// A value indicating whether any dialogs are currently visible.
        /// </value>
        protected bool IsDialogVisisble => Dialogs.Any(d => d.IsVisible);

        /// <inheritdoc />
        public void Load()
        {
            PreLoad?.Invoke(this, new LoadEventArgs(Assets));

            foreach (Dialog dialog in Dialogs)
            {
                dialog.Load();
            }

            foreach (Window window in Windows)
            {
                window.Load();
            }

            Mouse.Load();

            PostLoad?.Invoke(this, new LoadEventArgs(Assets));
        }

        /// <inheritdoc />
        public void Unload()
        {
            PreUnload?.Invoke(this, new UnloadEventArgs());

            foreach (Dialog dialog in Dialogs)
            {
                dialog.Unload();
            }

            foreach (Window window in Windows)
            {
                window.Unload();
            }

            Mouse.Unload();

            PostUnload?.Invoke(this, new UnloadEventArgs());
        }

        /// <inheritdoc />
        public void Update(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            PreUpdate?.Invoke(this, new UpdateEventArgs(total, elapsed, isRunningSlowly));

            Mouse.Update(total, elapsed, isRunningSlowly);

            foreach (Dialog dialog in Dialogs)
            {
                dialog.Update(total, elapsed, isRunningSlowly);
            }

            foreach (Window window in Windows)
            {
                window.Update(total, elapsed, isRunningSlowly);
            }

            Dialog.IsShownInCurrentLoopIteration = false;

            PostUpdate?.Invoke(this, new UpdateEventArgs(total, elapsed, isRunningSlowly));
        }

        /// <inheritdoc />
        public void Draw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            PreDraw?.Invoke(this, new DrawEventArgs(total, elapsed, isRunningSlowly));

            foreach (Dialog dialog in Dialogs)
            {
                dialog.Draw(total, elapsed, isRunningSlowly);
            }

            foreach (Window window in Windows)
            {
                window.Draw(total, elapsed, isRunningSlowly);
            }

            Mouse.Draw(total, elapsed, isRunningSlowly);

            PostDraw?.Invoke(this, new DrawEventArgs(total, elapsed, isRunningSlowly));
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

        private void MouseOnButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            Dialogs.ForEach(d => d.InvokeMouseButtonUp(this, e));
            Windows.ForEach(w => w.InvokeMouseButtonUp(this, e));
        }
    }
}
