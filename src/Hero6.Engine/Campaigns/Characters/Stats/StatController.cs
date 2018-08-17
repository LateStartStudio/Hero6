// <copyright file="LearningStatController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Characters.Stats
{
    using System;

    public abstract class StatController : GameController<StatController, StatModule>
    {
        protected StatController()
            : base(new StatModule())
        {
        }

        public abstract event EventHandler<EventArgs> Change;

        public abstract int Current { get; set; }

        public abstract int Max { get; }
    }
}
