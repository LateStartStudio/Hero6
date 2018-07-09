// <copyright file="Image.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using Input;

    /// <summary>
    /// A image user interface element.
    /// </summary>
    public class Image : UserInterfaceElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        /// <param name="source">The source for the image.</param>
        /// <param name="mouse">The mouse service.</param>
        /// <param name="parent">The parent.</param>
        protected Image(string source, IMouse mouse, UserInterfaceElement parent)
            : base(mouse, parent)
        {
            Source = source;
        }

        /// <summary>
        /// Gets the source path for the texture.
        /// </summary>
        public string Source { get; }
    }
}
