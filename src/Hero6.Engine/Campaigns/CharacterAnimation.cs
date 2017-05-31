// <copyright file="CharacterAnimation.cs" company="Late Start Studio">
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
    /// A class that represents a character animation.
    /// </summary>
    public abstract class CharacterAnimation : AdventureGameElement
    {
        private Point location;
        private int currentFrame;
        private float elapsedTime;
        private Vector2 facingDirection;

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterAnimation"/> class.
        /// </summary>
        /// <param name="campaign">The campaign this character animation belongs to.</param>
        protected CharacterAnimation(Campaign campaign) : base(campaign)
        {
            this.currentFrame = 0;
            this.elapsedTime = 0;
        }

        /// <summary>
        /// Gets or sets the sprite sheet that is active when the character is facing Center-Down.
        /// </summary>
        /// <value>
        /// The animation that is active when the character is pointing Center-Down.
        /// </value>
        public SpriteSheet CenterDownAnimation
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the sprite sheet that is active when the character is facing Center-Up.
        /// </summary>
        /// <value>
        /// The animation that is active when the character is facing Center-Up.
        /// </value>
        public SpriteSheet CenterUpAnimation
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the sprite sheet that is active when the character is facing Left-Center.
        /// </summary>
        /// <value>
        /// The animation that is active when the character is facing Left-Center.
        /// </value>
        public SpriteSheet LeftCenterAnimation
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the sprite sheet that is active when the character is facing Left-Down.
        /// </summary>
        /// <value>
        /// The animation that is active when the character is facing Left-Down.
        /// </value>
        public SpriteSheet LeftDownAnimation
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the sprite sheet that is active when the character is facing Left-Up.
        /// </summary>
        /// <value>
        /// The animation that is active when the character is facing Left-Up.
        /// </value>
        public SpriteSheet LeftUpAnimation
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the sprite sheet that is active when the character is facing Right-Center.
        /// </summary>
        /// <value>
        /// The animation that is active when the character is facing Right-Center.
        /// </value>
        public SpriteSheet RightCenterAnimation
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the sprite sheet that is active when the character is facing Right-Down.
        /// </summary>
        /// <value>
        /// The animation that is active when the character is facing Right-Down.
        /// </value>
        public SpriteSheet RightDownAnimation
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the sprite sheet that is active when the character is facing Right-Up.
        /// </summary>
        /// <value>
        /// The animation that is active when the character is facing Right-Up.
        /// </value>
        public SpriteSheet RightUpAnimation
        {
            get; set;
        }

        /// <inheritdoc />
        public override Point Location
        {
            get
            {
                return new Point(this.location.X - (this.Width / 2), this.location.Y - this.Height);
            }

            set
            {
                this.location = value;
            }
        }

        /// <inheritdoc />
        public override sealed int Width => this.CurrentSprite.Sheet.Width / this.CurrentSprite.Columns;

        /// <inheritdoc />
        public override sealed int Height => this.CurrentSprite.Sheet.Height / this.CurrentSprite.Rows;

        /// <summary>
        /// Gets or sets a value indicating whether the character holding this animation is moving.
        /// </summary>
        /// <value>
        /// True if the character is moving; false otherwise.
        /// </value>
        public bool IsMoving
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the direction vector of the character holding this animation. The current
        /// animation will change according the direciton.
        /// </summary>
        /// <value>
        /// The direction vector of the character holding this animation.
        /// </value>
        public Vector2 FacingDirection
        {
            get
            {
                return this.facingDirection;
            }

            set
            {
                this.ChangeCurrentSprite(value);
                this.facingDirection = value;
            }
        }

        /// <summary>
        /// Gets or sets the sprite sheet that is currently active.
        /// </summary>
        /// <value>
        /// The sprite sheet that is currently active.
        /// </value>
        protected SpriteSheet CurrentSprite
        {
            get; set;
        }

        /// <inheritdoc />
        public override bool Interact(int x, int y, Interaction interaction)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected sealed override void InternalLoad()
        {
            this.CenterDownAnimation.Load();
            this.CenterUpAnimation.Load();
            this.LeftCenterAnimation.Load();
            this.LeftDownAnimation.Load();
            this.LeftUpAnimation.Load();
            this.RightCenterAnimation.Load();
            this.RightDownAnimation.Load();
            this.RightUpAnimation.Load();
        }

        /// <inheritdoc />
        protected sealed override void InternalUnload()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected sealed override void InternalUpdate(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            if (this.IsMoving)
            {
                this.elapsedTime += (float)elapsed.TotalSeconds;

                if (this.elapsedTime < (float)1 / 16)
                {
                    return;
                }

                this.currentFrame++;
                this.elapsedTime = 0;

                if (this.currentFrame >= this.CurrentSprite.Columns * this.CurrentSprite.Rows)
                {
                    this.currentFrame = 1;
                }
            }
            else
            {
                this.currentFrame = 0;
            }
        }

        /// <inheritdoc />
        protected sealed override void InternalDraw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            Rectangle destRectangle = new Rectangle(
                this.Location.X,
                this.Location.Y,
                this.Width,
                this.Height);

            Rectangle sourceRectangle = new Rectangle(
                this.Width * (this.currentFrame % this.CurrentSprite.Columns),
                this.Height * (this.currentFrame / this.CurrentSprite.Columns),
                this.Width,
                this.Height);

            Campaign.Renderer.Draw(this.CurrentSprite.Sheet, destRectangle, sourceRectangle, Color.White);
        }

        private void ChangeCurrentSprite(Vector2 direction)
        {
            if (this.facingDirection.Equals(direction))
            {
                return;
            }

            if (direction.Equals(new Vector2(-1, -1)))
            {
                this.CurrentSprite = this.LeftUpAnimation;
            }
            else if (direction.Equals(new Vector2(0, -1)))
            {
                this.CurrentSprite = this.CenterUpAnimation;
            }
            else if (direction.Equals(new Vector2(1, -1)))
            {
                this.CurrentSprite = this.RightUpAnimation;
            }
            else if (direction.Equals(new Vector2(-1, 0)))
            {
                this.CurrentSprite = this.LeftCenterAnimation;
            }
            else if (direction.Equals(new Vector2(1, 0)))
            {
                this.CurrentSprite = this.RightCenterAnimation;
            }
            else if (direction.Equals(new Vector2(-1, 1)))
            {
                this.CurrentSprite = this.LeftDownAnimation;
            }
            else if (direction.Equals(new Vector2(0, 1)))
            {
                this.CurrentSprite = this.CenterDownAnimation;
            }
            else if (direction.Equals(new Vector2(1, 1)))
            {
                this.CurrentSprite = this.RightDownAnimation;
            }
        }
    }
}
