// <copyright file="IControllerRepository.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;
using LateStartStudio.Hero6.ModuleController;

namespace LateStartStudio.Hero6.Services.ControllerRepository
{
    /// <summary>
    /// Helper to get controller from modules.
    /// </summary>
    public interface IControllerRepository
    {
        IEnumerable<IController> Controllers { get; }

        IController this[IModule key] { get; set; }
    }
}
