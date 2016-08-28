// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InventoryItem.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the InventoryItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Game
{
    using System;
    using AdventureGame;
    using Engine.Graphics;

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
        public override int Width
        {
            get { return this.sprite.Width; }
        }

        /// <inheritdoc />
        public override int Height
        {
            get { return this.sprite.Height; }
        }

        /// <inheritdoc />
        public override bool Interact(int x, int y)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override void Load()
        {
            this.sprite = Campaign.Engine.Assets.LoadTexture2D(this.spriteID);
        }

        /// <inheritdoc />
        public override void Unload()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override void Update(
            TimeSpan totalTime,
            TimeSpan elapsedTime,
            bool isRunningSlowly)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override void Draw(
            TimeSpan totalTime,
            TimeSpan elapsedTime,
            bool isRunningSlowly)
        {
            throw new NotImplementedException();
        }
    }
}
