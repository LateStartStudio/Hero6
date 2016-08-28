// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpriteSheet.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the SpriteSheet type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Game
{
    using System;
    using AdventureGame;
    using Engine.Graphics;

    /// <summary>
    /// A class representing a sprite sheet.
    /// </summary>
    public class SpriteSheet : IGameLoop
    {
        private readonly Campaign campaign;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpriteSheet"/> class.
        /// </summary>
        /// <param name="campaign">The campaign this sprite sheet belongs to.</param>
        /// <param name="sheetID">The ID of the sprite sheet.</param>
        /// <param name="rows">The amount of rows in the sprite sheet.</param>
        /// <param name="columns">The amount of columns in the sprite sheet.</param>
        public SpriteSheet(Campaign campaign, string sheetID, int rows, int columns)
        {
            this.campaign = campaign;
            this.SheetID = sheetID;
            this.Rows = rows;
            this.Columns = columns;
        }

        /// <summary>
        /// Gets or sets the sprite sheet ID.
        /// </summary>
        /// <value>
        /// The sprite sheet ID.
        /// </value>
        public string SheetID
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the sprite sheet.
        /// </summary>
        /// <value>
        /// The sprite sheet.
        /// </value>
        public Texture2D Sheet
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the amount of rows in the sprite sheet.
        /// </summary>
        /// <value>
        /// The amount of rows in the sprite sheet.
        /// </value>
        public int Rows
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the amount of columns in the sprite sheet.
        /// </summary>
        /// <value>
        /// The amount of columns in the spite sheet.
        /// </value>
        public int Columns
        {
            get; set;
        }

        /// <inheritdoc />
        public void Load()
        {
            if (this.Sheet == null)
            {
                this.Sheet = this.campaign.Engine.Assets.LoadTexture2D(this.SheetID);
            }
        }

        /// <inheritdoc />
        public void Unload()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Update(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Draw(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly)
        {
            throw new NotImplementedException();
        }
    }
}
