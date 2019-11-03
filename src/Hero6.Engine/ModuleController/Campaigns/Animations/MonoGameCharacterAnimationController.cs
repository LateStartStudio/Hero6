// <copyright file="MonoGameCharacterAnimationController.cs" company="Late Start Studio">
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
    public class MonoGameCharacterAnimationController : CharacterAnimationController
    {
        private readonly ICampaigns campaigns;

        private CharacterDirection direction;
        private MonoGameAnimationController current;
        private MonoGameAnimationController centerDown;
        private MonoGameAnimationController centerUp;
        private MonoGameAnimationController leftCenter;
        private MonoGameAnimationController leftDown;
        private MonoGameAnimationController leftUp;
        private MonoGameAnimationController rightCenter;
        private MonoGameAnimationController rightDown;
        private MonoGameAnimationController rightUp;

        public MonoGameCharacterAnimationController(CharacterAnimationModule module, IServiceLocator services)
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

        public override IAnimationController CenterDown
        {
            get { return centerDown; }
            set { centerDown = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        public override IAnimationController CenterUp
        {
            get { return centerUp; }
            set { centerUp = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        public override IAnimationController LeftCenter
        {
            get { return leftCenter; }
            set { leftCenter = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        public override IAnimationController LeftDown
        {
            get { return leftDown; }
            set { leftDown = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        public override IAnimationController LeftUp
        {
            get { return leftUp; }
            set { leftUp = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        public override IAnimationController RightCenter
        {
            get { return rightCenter; }
            set { rightCenter = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        public override IAnimationController RightDown
        {
            get { return rightDown; }
            set { rightDown = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        public override IAnimationController RightUp
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
