// <copyright file="IChildren.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for user interfaces with multiple children.
    /// </summary>
    public interface IChildren
    {
        /// <summary>
        /// Gets the children.
        /// </summary>
        IList<UserInterfaceElement> Children { get; }
    }
}
