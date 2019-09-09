// <copyright file="MonoGameCharacterAnimationController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.ModuleController.Campaigns.Characters;
using LateStartStudio.Hero6.MonoGame.GameLoop;
using LateStartStudio.Hero6.Services.Campaigns;
using LateStartStudio.Hero6.Services.DependencyInjection;
using Microsoft.Xna.Framework;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Animations
{
    public class MonoGameCharacterAnimationController : CharacterAnimationController, IXnaGameLoop
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

        protected override AnimationController CenterDown
        {
            get { return centerDown; }
            set { centerDown = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        protected override AnimationController CenterUp
        {
            get { return centerUp; }
            set { centerUp = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        protected override AnimationController LeftCenter
        {
            get { return leftCenter; }
            set { leftCenter = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        protected override AnimationController LeftDown
        {
            get { return leftDown; }
            set { leftDown = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        protected override AnimationController LeftUp
        {
            get { return leftUp; }
            set { leftUp = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        protected override AnimationController RightCenter
        {
            get { return rightCenter; }
            set { rightCenter = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        protected override AnimationController RightDown
        {
            get { return rightDown; }
            set { rightDown = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        protected override AnimationController RightUp
        {
            get { return rightUp; }
            set { rightUp = campaigns.AsMonoGame().CurrentController.Animations[value.Module.GetType()]; }
        }

        public override bool Interact(int x, int y, Interaction interaction) => current.Interact(x, y, interaction);

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
            current.X = X;
            current.Y = Y;
            current.Update(time);
        }

        public void Draw(GameTime time)
        {
            current.Draw(time);
        }
    }
}
