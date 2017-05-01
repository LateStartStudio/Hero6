// <copyright file="IChild.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    /// <summary>
    /// Interface for user interfaces with a single child.
    /// </summary>
    public interface IChild
    {
        /// <summary>
        /// Gets or sets the child.
        /// </summary>
        UserInterfaceElement Child { get; set; }
    }
}
