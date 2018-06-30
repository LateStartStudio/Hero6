// <copyright file="Button.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using Input;

    /// <summary>
    /// A button control.
    /// </summary>
    public abstract class Button : UserInterfaceElement, IChild
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        /// <param name="mouse">The mouse service.</param>
        /// <param name="parent">The parent.</param>
        protected Button(IMouse mouse, UserInterfaceElement parent)
            : base(mouse, parent)
        {
        }

        /// <inheritdoc />
        public UserInterfaceElement Child { get; set; }
    }
}
