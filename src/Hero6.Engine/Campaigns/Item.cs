// <copyright file="Item.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using System;
    using Assets;
    using Assets.Graphics;
    using Utilities.DependencyInjection;

    /// <summary>
    /// A class that represents an item in a game.
    /// </summary>
    public abstract class Item : AdventureGameElement
    {
        private static readonly IRenderer Renderer;
        private readonly string spriteID;

        private Texture2D sprite;

        static Item()
        {
            Renderer = ServicesBank.Instance.Get<IRenderer>();
        }

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
        protected sealed override void InternalLoad()
        {
            this.sprite = this.Assets.LoadTexture2D(this.spriteID);
        }

        /// <inheritdoc />
        protected sealed override void InternalUnload()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected sealed override void InternalUpdate(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
        }

        /// <inheritdoc />
        protected sealed override void InternalDraw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            if (this.IsVisible)
            {
                Renderer.Draw(this.sprite, this.Location);
            }
        }
    }
}
