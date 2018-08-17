// <copyright file="CharacterAnimationController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Animations
{
    public abstract class CharacterAnimationController : GameController<CharacterAnimationController, CharacterAnimationModule>
    {
        protected CharacterAnimationController(CharacterAnimationModule module)
            : base(module)
        {
        }

        protected internal abstract AnimationController CenterDown { get; set; }

        protected internal abstract AnimationController CenterUp { get; set; }

        protected internal abstract AnimationController LeftCenter { get; set; }

        protected internal abstract AnimationController LeftDown { get; set; }

        protected internal abstract AnimationController LeftUp { get; set; }

        protected internal abstract AnimationController RightCenter { get; set; }

        protected internal abstract AnimationController RightDown { get; set; }

        protected internal abstract AnimationController RightUp { get; set; }
    }
}
