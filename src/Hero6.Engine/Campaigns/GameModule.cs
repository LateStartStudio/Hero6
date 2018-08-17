// <copyright file="GameModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using System;
    using LateStartStudio.Hero6.Engine.ModuleController;

    public abstract class GameModule<TController> : Module<TController>
        where TController : class, IController
    {
        public Action Look { get; protected set; }

        public Action Grab { get; protected set; }

        public Action Talk { get; protected set; }
    }
}
