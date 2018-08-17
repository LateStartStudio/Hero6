// <copyright file="CharactgerAnimationModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Animations
{
    public abstract class CharacterAnimationModule : GameModule<CharacterAnimationController>
    {
        protected AnimationModule CenterDown
        {
            get { return Controller.CenterDown; }
            set { Controller.CenterDown = value.Controller; }
        }

        protected AnimationModule CenterUp
        {
            get { return Controller.CenterUp; }
            set { Controller.CenterUp = value.Controller; }
        }

        protected AnimationModule LeftCenter
        {
            get { return Controller.LeftCenter; }
            set { Controller.LeftCenter = value.Controller; }
        }

        protected AnimationModule LeftDown
        {
            get { return Controller.LeftDown; }
            set { Controller.LeftDown = value.Controller; }
        }

        protected AnimationModule LeftUp
        {
            get { return Controller.LeftUp; }
            set { Controller.LeftUp = value.Controller; }
        }

        protected AnimationModule RightCenter
        {
            get { return Controller.RightCenter; }
            set { Controller.RightCenter = value.Controller; }
        }

        protected AnimationModule RightDown
        {
            get { return Controller.RightDown; }
            set { Controller.RightDown = value.Controller; }
        }

        protected AnimationModule RightUp
        {
            get { return Controller.RightUp; }
            set { Controller.RightUp = value.Controller; }
        }
    }
}
