// <copyright file="InventoryItem.cs" company="Late Start Studio">
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
    /// A class that represents an inventory item a game.
    /// </summary>
    public abstract class InventoryItem : AdventureGameElement
    {
        private readonly string spriteID;

        private Texture2D sprite;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryItem"/> class.
        /// </summary>
        /// <param name="campaign">The campaign this inventory item belongs to.</param>
        /// <param name="spriteID">The ID of the inventory item sprite.</param>
        protected InventoryItem(Campaign campaign, string spriteID) : base(campaign)
        {
            this.spriteID = spriteID;
        }

        /// <inheritdoc />
        public override int Width => this.sprite.Width;

        /// <inheritdoc />
        public override int Height => this.sprite.Height;

        /// <inheritdoc />
        public override bool Interact(int x, int y, Interaction interaction)
        {
            return true;
        }

        /// <inheritdoc />
        protected override void InternalLoad()
        {
            this.sprite = this.Assets.LoadTexture2D(this.spriteID);
        }

        /// <inheritdoc />
        protected override void InternalUnload()
        {
        }

        /// <inheritdoc />
        protected override void InternalUpdate(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
        }

        /// <inheritdoc />
        protected override void InternalDraw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
        }
    }
}
