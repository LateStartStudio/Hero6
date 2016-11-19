// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdventureGameElement.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the AdventureGameElement type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Game
{
    using System;
    using AdventureGame;
    using Engine;
    using Engine.Graphics;

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
        /// Gets the <see cref="ContentManager"/> associated with this
        /// <see cref="AdventureGameElement"/> instance.
        /// </summary>
        /// <value>
        /// The <see cref="ContentManager"/> associated with this
        /// <see cref="AdventureGameElement"/> instance.
        /// </value>
        protected ContentManager Content
        {
            get { return this.Campaign.Content; }
        }

        /// <summary>
        /// Called on user interaction with the game at input coordinates.
        /// </summary>
        /// <param name="x">The user input x coordinate.</param>
        /// <param name="y">The user input y coordinate.</param>
        /// <returns>True if the user interacted with this element; false otherwise.</returns>
        public abstract bool Interact(int x, int y);

        /// <inheritdoc />
        public abstract void Load();

        /// <inheritdoc />
        public abstract void Unload();

        /// <inheritdoc />
        public abstract void Update(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly);

        /// <inheritdoc />
        public abstract void Draw(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly);

        /// <summary>
        /// Shows a box with the input text.
        /// </summary>
        /// <param name="text">The text to display within the box.</param>
        public void Display(string text)
        {
            this.Campaign.UserInterface.ShowTextBox(text);
        }
    }
}
