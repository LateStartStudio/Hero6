// <copyright file="IControllerRepository.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Components
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using LateStartStudio.Hero6.Engine.ModuleController;

    /// <summary>
    /// Helper to get controller from modules
    /// </summary>
    public interface IControllerRepository
    {
        IEnumerable<IController> Controllers { get; }

        IController this[IModule key] { get; set; }
    }
}
