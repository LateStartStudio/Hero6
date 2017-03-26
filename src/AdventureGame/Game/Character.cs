// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Character.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the Character type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Game
{
    using System;
    using System.Collections.Generic;
    using AdventureGame;
    using Engine.Graphics;

    /// <summary>
    /// A class that represents a character in a game.
    /// </summary>
    public abstract class Character : AdventureGameElement
    {
        private Point location;

        /// <summary>
        /// Initializes a new instance of the <see cref="Character"/> class.
        /// </summary>
        /// <param name="campaign">The campaign this character belongs to.</param>
        protected Character(Campaign campaign) : base(campaign)
        {
            this.MovementPath = new Queue<Vector2>();
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
        public Queue<Vector2> MovementPath
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
        public override sealed int Width
        {
            get { return this.Animation.Width; }
        }

        /// <inheritdoc />
        public override sealed int Height
        {
            get { return this.Animation.Height; }
        }

        /// <summary>
        /// Gets a value indicating whether this character is the player or not.
        /// </summary>
        /// <value>
        /// True if this character is the player; false otherwise.
        /// </value>
        public bool IsPlayer
        {
            get { return this.Equals(this.Campaign.Player); }
        }

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
        public override sealed void Load()
        {
            this.Animation.Load();
        }

        /// <inheritdoc />
        public override void Unload()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override sealed void Update(
            TimeSpan totalTime,
            TimeSpan elapsedTime,
            bool isRunningSlowly)
        {
            this.Animation.IsMoving = this.MovementPath.Count > 0;

            this.MoveCharacter();
            this.Animation.Update(totalTime, elapsedTime, isRunningSlowly);
        }

        /// <inheritdoc />
        public override sealed void Draw(
            TimeSpan totalTime,
            TimeSpan elapsedTime,
            bool isRunningSlowly)
        {
            if (this.IsVisible)
            {
                this.Animation.Draw(totalTime, elapsedTime, isRunningSlowly);
            }
        }

        private void MoveCharacter()
        {
            if (this.MovementPath == null || this.MovementPath.Count == 0)
            {
                return;
            }

            Vector2 newLocation = this.MovementPath.Dequeue();
            this.Animation.FacingDirection = newLocation - new Vector2(this.Location);
            this.Location = new Point(newLocation);
        }
    }
}
