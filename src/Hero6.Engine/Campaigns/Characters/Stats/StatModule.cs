// <copyright file="LearningStatModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Characters.Stats
{
    using System;

    public class StatModule : GameModule<StatController>
    {
        public event EventHandler<EventArgs> Change
        {
            add { Controller.Change += value; }
            remove { Controller.Change -= value; }
        }

        public override string Name { get; }

        public int Current
        {
            get { return Controller.Current; }
            set { Controller.Current = value; }
        }

        public int Max => Controller.Max;
    }
}
