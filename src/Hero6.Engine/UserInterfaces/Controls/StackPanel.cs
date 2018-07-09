// <copyright file="StackPanel.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using Input;

    /// <summary>
    /// Stack panel to order user interface components horizontally, or vertically.
    /// </summary>
    public class StackPanel : Layout
    {
        /// <summary>
        /// Initializes a new instandce of the <see cref="StackPanel"/> class.
        /// </summary>
        /// <param name="mouse">The mouse service.</param>
        /// <param name="parent">The parent.</param>
        protected StackPanel(IMouse mouse, UserInterfaceElement parent = null)
            : base(mouse, parent)
        {
        }

        /// <summary>
        /// Gets or sets the orientation to render the <see cref="UserInterfaceElement"/> children.
        /// </summary>
        public Orientation Orientation { get; set; }
    }
}
