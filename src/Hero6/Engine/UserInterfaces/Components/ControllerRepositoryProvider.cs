// <copyright file="ControllerRepositoryProvider.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Components
{
    using System.Collections.Generic;
    using LateStartStudio.Hero6.Engine.ModuleController;

    public class ControllerRepositoryProvider : IControllerRepository
    {
        private readonly Dictionary<IModule, IController> labels = new Dictionary<IModule, IController>();

        public IEnumerable<IController> Controllers => labels.Values;

        public IController this[IModule key]
        {
            get { return labels[key]; }
            set { labels[key] = value; }
        }
    }
}
