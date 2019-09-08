// <copyright file="IGameModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;

namespace LateStartStudio.Hero6.ModuleController.Campaigns
{
    public interface IGameModule : IModule
    {
        Action Look { get; }

        Action Grab { get; }

        Action Talk { get; }
    }
}
