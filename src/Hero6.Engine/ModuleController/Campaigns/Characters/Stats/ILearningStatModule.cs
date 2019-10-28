// <copyright file="ILearningStatModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Characters.Stats
{
    public interface ILearningStatModule : IGameModule
    {
        event EventHandler<EventArgs> Change;

        int Current { get; }
    }
}
