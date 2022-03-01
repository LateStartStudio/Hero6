// <copyright file="CharacterController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using LateStartStudio.Hero6.Extensions;
using LateStartStudio.Hero6.ModuleController.Campaigns.Animations;
using LateStartStudio.Hero6.ModuleController.Campaigns.Characters.Stats;
using LateStartStudio.Hero6.ModuleController.Campaigns.InventoryItems;
using LateStartStudio.Hero6.ModuleController.Campaigns.Rooms;
using LateStartStudio.Hero6.ModuleController.Campaigns.Rooms.Regions;
using LateStartStudio.Hero6.Services.Campaigns;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Characters
{
    /// <summary>
    /// API for the character controller.
    /// </summary>
    public class CharacterController : GameController<ICharacterController, ICharacterModule>, ICharacterController
    {
        private readonly ICampaigns campaigns;
        private readonly StatsController stats;
        private readonly List<InventoryItemController> inventory = new List<InventoryItemController>();
        private readonly Queue<Point> path = new Queue<Point>();

        private double pixelsToMove;
        private CharacterAnimationController currentAnimation;
        private CharacterAnimationController idleAnimation;
        private CharacterAnimationController moveAnimation;

        /// <summary>
        /// Makes a new instance of the <see cref="CharacterController"/> class.
        /// </summary>
        /// <param name="module">The module corresponding to this character.</param>
        public CharacterController(ICharacterModule module, IServiceProvider services)
            : base(module, services)
        {
            campaigns = services.GetService<ICampaigns>();
            stats = new StatsController(services);
        }

        public override int Width => currentAnimation?.Width ?? 0;

        public override int Height => currentAnimation?.Height ?? 0;

        public bool IsPlayer => campaigns.Current.Player == Module;

        public int Speed { get; set; } = 60;

        public IRoomController Room
        {
            get
            {
                return campaigns.AsMonoGame().CurrentController.Rooms.Values.Single(r => r.Characters.Contains(this));
            }
        }

        public IStatsController Stats => stats;

        public ICharacterAnimationController IdleAnimation
        {
            get { return idleAnimation; }
            set { idleAnimation = campaigns.AsMonoGame().CurrentController.CharacterAnimations[value.Module.GetType()]; }
        }

        public ICharacterAnimationController MoveAnimation
        {
            get { return moveAnimation; }
            set { moveAnimation = campaigns.AsMonoGame().CurrentController.CharacterAnimations[value.Module.GetType()]; }
        }

        public IEnumerable<IInventoryItemController> Inventory => inventory;

        public void AddInventoryItem<T>() where T : IInventoryItemModule
        {
            inventory.Add(campaigns.AsMonoGame().CurrentController.InventoryItems[typeof(T)]);
        }

        public void RemoveInventoryItem<T>() where T : IInventoryItemModule
        {
            inventory.Remove(campaigns.AsMonoGame().CurrentController.InventoryItems[typeof(T)]);
        }

        public bool HasInventoryItem<T>() where T : IInventoryItemModule
        {
            return inventory.Contains(campaigns.AsMonoGame().CurrentController.InventoryItems[typeof(T)]);
        }

        public void Walk(int x, int y)
        {
            var from = new Point(X, Y);
            var to = new Point(x, y);
            var newPath = ((WalkAreasController)Room.WalkAreas).GetPath(from, to);

            if (newPath == null)
            {
                return;
            }

            path.Clear();
            newPath.ForEach(p => path.Enqueue(p));
            path.Dequeue(); // First is where we're already standing so discard
        }

        public void Face(CharacterDirection direction)
        {
            if (idleAnimation != null)
            {
                idleAnimation.Direction = direction;
            }

            if (moveAnimation != null)
            {
                moveAnimation.Direction = direction;
            }
        }

        public void Face(int locationX, int locationY)
        {
            var from = new Point(X, Y);
            var to = new Point(locationX, locationY);
            var direction = to - from;
            Face(direction.ToVector2().ToCharacterDirection());
        }

        public void ChangeRoom<T>(int x = 0, int y = 0, CharacterDirection direction = CharacterDirection.CenterDown) where T : IRoomModule
        {
            path.Clear();
            X = x;
            Y = y;
            Face(direction);
            Room.RemoveCharacter(Module);
            campaigns.AsMonoGame().CurrentController.Rooms[typeof(T)].AddCharacter(this);
        }

        public void SetAsPlayer() => campaigns.Current.Player = Module;

        public override bool Interact(int x, int y, Interaction interaction)
        {
            if (currentAnimation.Interact(x, y, interaction))
            {
                switch (interaction)
                {
                    case Interaction.Eye:
                        Module.Look?.Invoke();
                        break;
                    case Interaction.Mouth:
                        Module.Talk?.Invoke();
                        break;
                    case Interaction.Hand:
                        Module.Grab?.Invoke();
                        break;
                    case Interaction.Move:
                    default:
                        return false;
                }

                return true;
            }

            return false;
        }

        public override void Load()
        {
        }

        public override void Unload()
        {
        }

        public override void Update(GameTime time)
        {
            Move(time);
            currentAnimation = path.Count > 0 ? moveAnimation : idleAnimation;
            currentAnimation.X = X;
            currentAnimation.Y = Y;
            currentAnimation.Update(time);
        }

        public override void Draw(GameTime time)
        {
            currentAnimation.Draw(time);
        }

        private void Move(GameTime time)
        {
            if (path.Count == 0)
            {
                return;
            }

            pixelsToMove += Speed * time.ElapsedGameTime.TotalSeconds;
            var pixelsToMoveFloor = (int)pixelsToMove;
            pixelsToMove -= pixelsToMoveFloor;

            for (var i = 0; i < pixelsToMoveFloor; i++)
            {
                var newLocation = path.Dequeue();
                Face(newLocation.X, newLocation.Y);
                X = newLocation.X;
                Y = newLocation.Y;

                if (path.Count == 0)
                {
                    pixelsToMove = 0.0;
                    break;
                }
            }
        }
    }
}
