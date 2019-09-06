// <copyright file="MonoGameCharacterController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Characters
{
    using System.Collections.Generic;
    using System.Linq;
    using LateStartStudio.Hero6.Engine.Campaigns.Animations;
    using LateStartStudio.Hero6.Engine.Campaigns.Characters.Stats;
    using LateStartStudio.Hero6.Engine.Campaigns.InventoryItems;
    using LateStartStudio.Hero6.Engine.Campaigns.Rooms;
    using LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions;
    using LateStartStudio.Hero6.Engine.GameLoop;
    using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;
    using Microsoft.Xna.Framework;

    public class MonoGameCharacterController : CharacterController, IXnaGameLoop
    {
        private readonly ICampaigns campaigns;
        private readonly MonoGameStatsController stats;
        private readonly List<MonoGameInventoryItemController> inventory = new List<MonoGameInventoryItemController>();
        private readonly Queue<Point> path = new Queue<Point>();

        private double pixelsToMove;
        private MonoGameCharacterAnimationController currentAnimation;
        private MonoGameCharacterAnimationController idleAnimation;
        private MonoGameCharacterAnimationController moveAnimation;

        public MonoGameCharacterController(CharacterModule module, IServices services)
            : base(module, services)
        {
            campaigns = services.Get<ICampaigns>();
            stats = new MonoGameStatsController(services);
        }

        public override int Width => currentAnimation?.Width ?? 0;

        public override int Height => currentAnimation?.Height ?? 0;

        public override bool IsPlayer => campaigns.Current.Player == Module;

        public override int Speed { get; set; } = 60;

        public override RoomController Room
        {
            get
            {
                return campaigns.AsMonoGame().CurrentController.Rooms.Values.Single(r => r.Characters.Contains(this));
            }
        }

        public override StatsController Stats => stats;

        public override CharacterAnimationController IdleAnimation
        {
            get { return idleAnimation; }
            set { idleAnimation = campaigns.AsMonoGame().CurrentController.CharacterAnimations[value.Module.GetType()]; }
        }

        public override CharacterAnimationController MoveAnimation
        {
            get { return moveAnimation; }
            set { moveAnimation = campaigns.AsMonoGame().CurrentController.CharacterAnimations[value.Module.GetType()]; }
        }

        public override IEnumerable<InventoryItemController> Inventory => inventory;

        public override void AddInventoryItem<T>()
        {
            inventory.Add(campaigns.AsMonoGame().CurrentController.InventoryItems[typeof(T)]);
        }

        public override void RemoveInventoryItem<T>()
        {
            inventory.Remove(campaigns.AsMonoGame().CurrentController.InventoryItems[typeof(T)]);
        }

        public override bool HasInventoryItem<T>()
        {
            return inventory.Contains(campaigns.AsMonoGame().CurrentController.InventoryItems[typeof(T)]);
        }

        public override void Walk(int x, int y)
        {
            var from = new Point(X, Y);
            var to = new Point(x, y);
            var newPath = ((MonoGameWalkAreasController)Room.WalkAreas).GetPath(from, to);

            if (newPath == null)
            {
                return;
            }

            path.Clear();
            newPath.ToList().ForEach(p => path.Enqueue(p));
            path.Dequeue(); // First is where we're already standing so discard
        }

        public override void Face(CharacterDirection direction)
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

        public override void Face(int locationX, int locationY)
        {
            var from = new Point(X, Y);
            var to = new Point(locationX, locationY);
            var direction = to - from;
            Face(direction.ToVector2().ToCharacterDirection());
        }

        public override void ChangeRoom<T>(int x = 0, int y = 0, CharacterDirection direction = CharacterDirection.CenterDown)
        {
            path.Clear();
            X = x;
            Y = y;
            Face(direction);
            Room.AsMonoGame().RemoveCharacter(this);
            var nextRoom = campaigns.AsMonoGame().Current.GetRoom<T>().GetType();
            campaigns.AsMonoGame().CurrentController.Rooms[nextRoom].AsMonoGame().AddCharacter(this);
        }

        public override void SetAsPlayer() => campaigns.Current.Player = Module;

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

        void IXnaGameLoop.Initialize()
        {
        }

        public void Load()
        {
            Initialize();
        }

        public void Unload()
        {
        }

        public void Update(GameTime time)
        {
            Move(time);
            currentAnimation = path.Count > 0 ? moveAnimation : idleAnimation;
            currentAnimation.X = X;
            currentAnimation.Y = Y;
            currentAnimation.Update(time);
        }

        public void Draw(GameTime time)
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
