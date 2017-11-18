// <copyright file="Character.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using System;
    using System.Collections.Generic;
    using Assets.Graphics;
    using GameLoop;

    /// <summary>
    /// A class that represents a character in a game.
    /// </summary>
    public abstract class Character : AdventureGameElement
    {
        private Point location;
        private double pixelsToMove;

        /// <summary>
        /// Initializes a new instance of the <see cref="Character"/> class.
        /// </summary>
        /// <param name="campaign">The campaign this character belongs to.</param>
        protected Character(Campaign campaign) : base(campaign)
        {
            this.MovementPath = new Queue<Point>();
            this.Inventory = new List<InventoryItem>();
        }

        /// <summary>
        /// Raised when the player interacts with the character by looking, examining, or other
        /// equivalents.
        /// </summary>
        public event EventHandler<EventArgs> Look;

        /// <summary>
        /// Raised when the player interacts with the character by grabbing, taking, or other
        /// equivalents.
        /// </summary>
        public event EventHandler<EventArgs> Grab;

        /// <summary>
        /// Raised when the player interacts with the character by talking, asking, or other
        /// equivalents.
        /// </summary>
        public event EventHandler<EventArgs> Talk;

        /// <summary>
        /// Gets or sets the character's animation.
        /// </summary>
        /// <value>
        /// The character's animation.
        /// </value>
        public CharacterAnimation Animation
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the character's movement path.
        /// </summary>
        /// <value>
        /// The character's movement path.
        /// </value>
        public Queue<Point> MovementPath
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the character's inventory.
        /// </summary>
        /// <value>
        /// The character's inventory.
        /// </value>
        public IList<InventoryItem> Inventory
        {
            get; set;
        }

        /// <inheritdoc />
        public override Point Location
        {
            get
            {
                return this.location;
            }

            set
            {
                this.location = value;
                this.Animation.Location = value;
            }
        }

        /// <inheritdoc />
        public sealed override int Width => Animation.Width;

        /// <inheritdoc />
        public sealed override int Height => Animation.Height;

        /// <summary>
        /// Gets a value indicating whether this character is the player or not.
        /// </summary>
        /// <value>
        /// True if this character is the player; false otherwise.
        /// </value>
        public bool IsPlayer => Equals(Campaign.Player);

        /// <summary>
        /// Gets or sets the movement speed of this <see cref="Character"/> instance. Speed is
        /// measured in pixels per second, there's no difference between horizontal, vertical or
        /// diagonally placed pixels. By default the speed is set to 60 pixels/second.
        /// </summary>
        public int Speed { get; set; } = 60;

        /// <summary>
        /// Adds an inventory item to this character's inventory.
        /// </summary>
        /// <param name="inventoryItem">
        /// The inventory item to add to the character's inventory.
        /// </param>
        public void AddInventory(InventoryItem inventoryItem)
        {
            this.Inventory.Add(inventoryItem);
        }

        /// <summary>
        /// Removes an inventory item from this character's inventory.
        /// </summary>
        /// <param name="inventoryItem">
        /// The inventory item to remove from the character's inventory.
        /// </param>
        public void RemoveInventory(InventoryItem inventoryItem)
        {
            this.Inventory.Remove(inventoryItem);
        }

        /// <summary>
        /// Gets a value indicating whether or not the character as the inventory item in their
        /// inventory.
        /// </summary>
        /// <param name="inventoryItem">
        /// The inventory item to check if is in the character's inventory.
        /// </param>
        /// <returns>
        /// True if the inventory item is in the character's inventory; false otherwise.
        /// </returns>
        public bool HasInventory(InventoryItem inventoryItem)
        {
            return this.Inventory.Contains(inventoryItem);
        }

        /// <summary>
        /// Moves the character to another room at the input coordinates.
        /// </summary>
        /// <param name="room">The room to move the character to.</param>
        /// <param name="x">
        /// The x coordinate for the character. Is 0 if input is not provided.
        /// </param>
        /// <param name="y">
        /// The y coordinate for the character. Is 0 if input is not provided.
        /// </param>
        public void ChangeRoom(string room, int x = 0, int y = 0)
        {
            this.MovementPath.Clear();

            this.Location = new Point(x, y);

            this.Campaign.ChangeRoom(this, room);
        }

        /// <inheritdoc />
        public override sealed bool Interact(int x, int y, Interaction interaction)
        {
            Rectangle rect = new Rectangle(
                this.Animation.Location.X,
                this.Animation.Location.Y,
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
                              $"Interaction {interaction} is not supported on characters.");
            }

            return true;
        }

        /// <inheritdoc />
        protected sealed override void InternalLoad()
        {
            this.Animation.Load();
        }

        /// <inheritdoc />
        protected sealed override void InternalUnload()
        {
        }

        /// <inheritdoc />
        protected sealed override void InternalUpdate(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            this.Animation.IsMoving = this.MovementPath.Count > 0;

            this.MoveCharacter(elapsed);
            this.Animation.Update(total, elapsed, isRunningSlowly);
        }

        /// <inheritdoc />
        protected sealed override void InternalDraw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            if (this.IsVisible)
            {
                this.Animation.Draw(total, elapsed, isRunningSlowly);
            }
        }

        /// <summary>
        /// Move this <see cref="Character"/> instance along the <see cref="MovementPath"/>.
        /// Movement occurs independently of fps by estimating how many pixels we should move for
        /// each time this function is called. Estimation is done by a standard formula,
        /// speed(velocity) multiplied with time passed since previous update call(delta time).
        /// </summary>
        /// <param name="elapsed">The time since previous update call.</param>
        private void MoveCharacter(TimeSpan elapsed)
        {
            if (this.MovementPath == null || this.MovementPath.Count == 0)
            {
                return;
            }

            this.pixelsToMove += Speed * elapsed.TotalSeconds;
            int pixelsToMoveFloor = (int)pixelsToMove;
            this.pixelsToMove -= pixelsToMoveFloor;

            for (int i = 0; i < pixelsToMoveFloor; i++)
            {
                Vector2 newLocation = MovementPath.Dequeue();
                this.Animation.FacingDirection = newLocation - Location;
                this.Location = (Point)newLocation;

                if (MovementPath.Count == 0)
                {
                    this.pixelsToMove = 0.0;
                    break;
                }
            }
        }
    }
}
