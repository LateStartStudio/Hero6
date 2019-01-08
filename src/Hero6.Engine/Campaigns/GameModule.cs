﻿// <copyright file="GameModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using System;
    using LateStartStudio.Hero6.Engine.ModuleController;

    /// <summary>
    /// API for game controller.
    /// </summary>
    /// <typeparam name="TController">The Controlle type.</typeparam>
    public abstract class GameModule<TController> : Module<TController>
        where TController : class, IController
    {
        /// <summary>
        /// Gets or sets the look event.
        /// </summary>
        public Action Look { get; protected set; }

        /// <summary>
        /// Gets or sets the grab event.
        /// </summary>
        public Action Grab { get; protected set; }

        /// <summary>
        /// Gets or sets the talk event.
        /// </summary>
        public Action Talk { get; protected set; }
    }
}
