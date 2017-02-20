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

namespace LateStartStudio.AdventureGame.UI
{
    using System;
    using Engine;
    using Engine.Graphics;
    using Game;

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
        /// <param name="adventureGameEngine">
        /// The adventure game engine that will render the user interface.
        /// </param>
        /// <param name="content">The content manager of this user interface.</param>
        protected UserInterface(int width, int height, Vector2 scale, Engine adventureGameEngine, ContentManager content)
        {
            this.Width = width;
            this.Height = height;
            this.Scale = scale;
            this.AdventureGameEngine = adventureGameEngine;
            this.Content = content;
        }

        /// <summary>
        /// Occurs when any mouse button is clicked.
        /// </summary>
        public event EventHandler<UserInteractionEventArgs> MouseButtonClick;

        /// <summary>
        /// Gets the <see cref="ContentManager"/> of the <see cref="UserInterface"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="ContentManager"/> of the <see cref="UserInterface"/> instance.
        /// </value>
        public ContentManager Content { get; }

        /// <summary>
        /// Gets the engine that will render the user interface.
        /// </summary>
        /// <value>
        /// The engine that will render the user interface.
        /// </value>
        public Engine AdventureGameEngine
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
        public abstract void Update(
            TimeSpan totalTime,
            TimeSpan elapsedTime,
            bool isRunningSlowly);

        /// <inheritdoc />
        public abstract void Draw(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly);

        /// <summary>
        /// Shows a text box with the input text.
        /// </summary>
        /// <param name="text">The input text within the text box.</param>
        public abstract void ShowTextBox(string text);

        /// <summary>
        /// Invokes the MouseButtonClick event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="args">The user interaction data of the event.</param>
        protected void InvokeMouseButtonClick(object sender, UserInteractionEventArgs args)
        {
            this.MouseButtonClick?.Invoke(sender, args);
        }
    }
}
