// <copyright file="Layout.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using System.Collections.Generic;
    using Input;

    /// <summary>
    /// A standard layout.
    /// </summary>
    public abstract class Layout : UserInterfaceElement, IChildren
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Layout"/> class.
        /// </summary>
        /// <param name="mouse">The mouse service.</param>
        /// <param name="parent">The parent.</param>
        protected Layout(IMouse mouse, UserInterfaceElement parent = null)
            : base(mouse, parent)
        {
        }

        /// <summary>
        /// Gets the children.
        /// </summary>
        public IList<UserInterfaceElement> Children { get; } = new List<UserInterfaceElement>();
    }
}
