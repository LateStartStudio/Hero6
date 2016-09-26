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
    using Game;

    /// <summary>
    /// An abstract class for defining the user interface of an adventure game.
    /// </summary>
    public abstract class UserInterface : IGameLoop
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserInterface"/> class.
        /// </summary>
        /// <param name="adventureGameEngine">
        /// The adventure game engine that will render the user interface.
        /// </param>
        protected UserInterface(Engine adventureGameEngine)
        {
            this.AdventureGameEngine = adventureGameEngine;
        }

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
    }
}
