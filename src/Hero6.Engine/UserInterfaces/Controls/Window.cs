// <copyright file="Window.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using Input;

    /// <summary>
    /// The Window class.
    /// </summary>
    public abstract class Window : UserInterfaceElement, IChild
    {
        /// <summary>
        /// Intializes a new instance of the <see cref="Window"/> class.
        /// </summary>
        /// <param name="mouse">The mouse service.</param>
        protected Window(IMouse mouse)
            : base(mouse)
        {
            IsVisible = false;
        }

        /// <summary>
        /// Gets or sets the child element.
        /// </summary>
        public virtual UserInterfaceElement Child { get; set; }
    }
}
