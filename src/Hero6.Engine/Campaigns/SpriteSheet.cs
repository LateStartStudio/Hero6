// <copyright file="SpriteSheet.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using System;
    using Assets;
    using Assets.Graphics;
    using GameLoop;

    /// <summary>
    /// A class representing a sprite sheet.
    /// </summary>
    public class SpriteSheet : IGameLoop
    {
        private readonly AssetManager assets;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpriteSheet"/> class.
        /// </summary>
        /// <param name="campaign">The campaign associated with this sprite sheet.</param>
        /// <param name="sheetID">The ID of the sprite sheet.</param>
        /// <param name="rows">The amount of rows in the sprite sheet.</param>
        /// <param name="columns">The amount of columns in the sprite sheet.</param>
        public SpriteSheet(Campaign campaign, string sheetID, int rows, int columns)
        {
            this.assets = campaign.Assets;
            this.SheetID = sheetID;
            this.Rows = rows;
            this.Columns = columns;
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
            this.PreLoad?.Invoke(this, new LoadEventArgs(this.assets));

            if (this.Sheet == null)
            {
                this.Sheet = this.assets.LoadTexture2D(this.SheetID);
            }

            this.PostLoad?.Invoke(this, new LoadEventArgs(this.assets));
        }

        /// <inheritdoc />
        public void Unload()
        {
            PreUnload?.Invoke(this, new UnloadEventArgs());

            PostUnload?.Invoke(this, new UnloadEventArgs());
        }

        /// <inheritdoc />
        public void Update(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            PreUpdate?.Invoke(this, new UpdateEventArgs(total, elapsed, isRunningSlowly));

            PostUpdate?.Invoke(this, new UpdateEventArgs(total, elapsed, isRunningSlowly));
        }

        /// <inheritdoc />
        public void Draw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            PreDraw?.Invoke(this, new DrawEventArgs(total, elapsed, isRunningSlowly, Campaign.Renderer));

            PostDraw?.Invoke(this, new DrawEventArgs(total, elapsed, isRunningSlowly, Campaign.Renderer));
        }
    }
}
