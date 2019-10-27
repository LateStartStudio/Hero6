// <copyright file="ILearningStatController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Characters.Stats
{
    public interface ILearningStatController : IGameController
    {
        event EventHandler<EventArgs> Change;

        ILearningStatModule Module { get; }

        int Current { get; }

        void Train(int factor);
    }
}
