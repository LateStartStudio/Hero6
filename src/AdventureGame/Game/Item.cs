// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Item.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the Item type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Game
{
    using System;
    using AdventureGame;
    using Engine.Graphics;

    /// <summary>
    /// A class that represents an item in a game.
    /// </summary>
    public abstract class Item : AdventureGameElement
    {
        private readonly string spriteID;

        private Texture2D sprite;

        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="campaign">The campaign this item belongs to.</param>
        /// <param name="spriteID">The ID of the item sprite.</param>
        protected Item(Campaign campaign, string spriteID) : base(campaign)
        {
            this.spriteID = spriteID;
        }

        /// <summary>
        /// Raised when the user interacts with the item.
        /// </summary>
        public event EventHandler<EventArgs> Interaction;

        /// <inheritdoc />
        public override sealed int Width
        {
            get { return this.sprite.Width; }
        }

        /// <inheritdoc />
        public override sealed int Height
        {
            get { return this.sprite.Height; }
        }

        /// <inheritdoc />
        public override sealed bool Interact(int x, int y)
        {
            if (!this.IsVisible)
            {
                return false;
            }

            Rectangle rect = new Rectangle(
                this.Location.X,
                this.Location.Y,
                this.Width,
                this.Height);

            if (!rect.Contains(x, y))
            {
                return false;
            }

            this.InteractionInvoke();
            return true;
        }

        /// <inheritdoc />
        public override sealed void Load()
        {
            this.sprite = this.Content.LoadTexture2D(this.spriteID);
        }

        /// <inheritdoc />
        public override sealed void Unload()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override sealed void Update(
            TimeSpan totalTime,
            TimeSpan elapsedTime,
            bool isRunningSlowly)
        {
        }

        /// <inheritdoc />
        public override sealed void Draw(
            TimeSpan totalTime,
            TimeSpan elapsedTime,
            bool isRunningSlowly)
        {
            if (this.IsVisible)
            {
                Campaign.Engine.Graphics.Draw(this.sprite, this.Location);
            }
        }

        private void InteractionInvoke()
        {
            if (this.Interaction != null)
            {
                this.Interaction.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
