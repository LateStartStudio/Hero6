// <copyright file="IUserInterfaces.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;
using LateStartStudio.Hero6.ModuleController.UserInterfaces;

namespace LateStartStudio.Hero6.Services.UserInterfaces
{
    /// <summary>
    /// The User Interfaces service the holds all user interfaces.
    /// </summary>
    public interface IUserInterfaces
    {
        /// <summary>
        /// Gets all the user interfaces.
        /// </summary>
        IEnumerable<UserInterfaceModule> UserInterfaces { get; }

        /// <summary>
        /// Gets or sets the current user interface.
        /// </summary>
        IUserInterfaceModule Current { get; set; }
    }
}
