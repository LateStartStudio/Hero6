// <copyright file="StatModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;

namespace LateStartStudio.Hero6.Engine.Campaigns.Characters.Stats
{
    public class LearningStatModule : GameModule<LearningStatController>
    {
        public event EventHandler<EventArgs> Change
        {
            add { Controller.Change += value; }
            remove { Controller.Change -= value; }
        }

        public override string Name => "StatModule";

        public int Current => Controller.Current;
    }
}
