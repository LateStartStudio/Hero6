// <copyright file="Item.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using System;
    using Assets.Graphics;
    using GameLoop;

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
        /// Raised when the player interacts with the item by looking, examining, or other
        /// equivalents.
        /// </summary>
        public event EventHandler<EventArgs> Look;

        /// <summary>
        /// Raised when the player interacts with the item by grabbing, taking, or other
        /// equivalents.
        /// </summary>
        public event EventHandler<EventArgs> Grab;

        /// <summary>
        /// Raised when the player interacts with the item by talking, asking, or other
        /// equivalents.
        /// </summary>
        public event EventHandler<EventArgs> Talk;

        /// <inheritdoc />
        public override sealed int Width => this.sprite.Width;

        /// <inheritdoc />
        public override sealed int Height => this.sprite.Height;

        /// <inheritdoc />
        public override sealed bool Interact(int x, int y, Interaction interaction)
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

            switch (interaction)
            {
                case Interaction.Eye:
                    this.Look?.Invoke(this, EventArgs.Empty);
                    break;
                case Interaction.Hand:
                    this.Grab?.Invoke(this, EventArgs.Empty);
                    break;
                case Interaction.Mouth:
                    this.Talk?.Invoke(this, EventArgs.Empty);
                    break;
                default:
                    throw new NotSupportedException(
                              $"Interaction {interaction} is not supported on items.");
            }

            return true;
        }

        /// <inheritdoc />
        public override sealed void Load()
        {
            this.InvokePreLoad(this, new LoadEventArgs(this.Assets));

            this.sprite = this.Assets.LoadTexture2D(this.spriteID);

            this.InvokePostLoad(this, new LoadEventArgs(this.Assets));
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
            this.InvokePreUpdate(this, new UpdateEventArgs(totalTime, elapsedTime, isRunningSlowly));

            this.InvokePostUpdate(this, new UpdateEventArgs(totalTime, elapsedTime, isRunningSlowly));
        }

        /// <inheritdoc />
        public override sealed void Draw(
            TimeSpan totalTime,
            TimeSpan elapsedTime,
            bool isRunningSlowly)
        {
            this.InvokePreDraw(this, new DrawEventArgs(totalTime, elapsedTime, isRunningSlowly, this.Campaign.Renderer));

            if (this.IsVisible)
            {
                Campaign.Renderer.Draw(this.sprite, this.Location);
            }

            this.InvokePostDraw(this, new DrawEventArgs(totalTime, elapsedTime, isRunningSlowly, this.Campaign.Renderer));
        }
    }
}
