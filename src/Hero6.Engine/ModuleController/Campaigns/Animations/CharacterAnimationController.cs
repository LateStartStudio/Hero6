// <copyright file="CharacterAnimationController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.Extensions;
using LateStartStudio.Hero6.ModuleController.Campaigns.Characters;
using LateStartStudio.Hero6.Services.Campaigns;
using LateStartStudio.Hero6.Services.DependencyInjection;
using Microsoft.Xna.Framework;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Animations
{
    /// <summary>
    /// The API for the character animation controller.
    /// </summary>
    public class CharacterAnimationController : GameController<ICharacterAnimationController, ICharacterAnimationModule>, ICharacterAnimationController
    {
        private readonly ICampaigns campaigns;

        private CharacterDirection direction;
        private AnimationController current;
        private AnimationController centerDown;
        private AnimationController centerUp;
        private AnimationController leftCenter;
        private AnimationController leftDown;
        private AnimationController leftUp;
        private AnimationController rightCenter;
        private AnimationController rightDown;
        private AnimationController rightUp;

        /// <summary>
        /// Creates a new instance of the <see cref="CharacterAnimationController"/> class.
        /// </summary>
        /// <param name="module">The module corresponding to this controller.</param>
        public CharacterAnimationController(ICharacterAnimationModule module, IServiceLocator services)
            : base(module, services)
        {
            campaigns = services.Get<ICampaigns>();
        }

        public override int Width => current.Width;

        public override int Height => current.Height;

        public CharacterDirection Direction
        {
            get
            {
                return direction;
            }

            set
            {
                direction = value;

                switch (value)
                {
                    case CharacterDirection.CenterDown:
                        current = centerDown;
                        break;
                    case CharacterDirection.CenterUp:
                        current = centerUp;
                        break;
                    case CharacterDirection.LeftCenter:
                        current = leftCenter;
                        break;
                    case CharacterDirection.LeftDown:
                        current = leftDown;
                        break;
                    case CharacterDirection.LeftUp:
                        current = leftUp;
                        break;
                    case CharacterDirection.RightCenter:
                        current = rightCenter;
                        break;
                    case CharacterDirection.RightDown:
                        current = rightDown;
                        break;
                    case CharacterDirection.RightUp:
                        current = rightUp;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
            }
        }

        public IAnimationController CenterDown
        {
            get { return centerDown; }
            set { centerDown = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        public IAnimationController CenterUp
        {
            get { return centerUp; }
            set { centerUp = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        public IAnimationController LeftCenter
        {
            get { return leftCenter; }
            set { leftCenter = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        public IAnimationController LeftDown
        {
            get { return leftDown; }
            set { leftDown = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        public IAnimationController LeftUp
        {
            get { return leftUp; }
            set { leftUp = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        public IAnimationController RightCenter
        {
            get { return rightCenter; }
            set { rightCenter = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        public IAnimationController RightDown
        {
            get { return rightDown; }
            set { rightDown = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        public IAnimationController RightUp
        {
            get { return rightUp; }
            set { rightUp = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        public override bool Interact(int x, int y, Interaction interaction) => current.Interact(x, y, interaction);

        public override void Load()
        {
        }

        public override void Unload()
        {
        }

        public override void Update(GameTime time)
        {
            current.X = X;
            current.Y = Y;
            current.Update(time);
        }

        public override void Draw(GameTime time)
        {
            current.Draw(time);
        }
    }
}
