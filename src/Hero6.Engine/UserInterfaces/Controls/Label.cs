// <copyright file="Label.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using Assets.Graphics;
    using Input;

    /// <summary>
    /// The <see cref="Label"/> class.
    /// </summary>
    public abstract class Label : UserInterfaceElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Label"/> class.
        /// </summary>
        /// <param name="mouse">The mouse servicve.</param>
        /// <param name="parent">The parent.</param>
        protected Label(IMouse mouse, UserInterfaceElement parent = null)
            : base(mouse, parent)
        {
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        public SpriteFont Font { get; set; }

        /// <summary>
        /// Gets or sets the foreground color.
        /// </summary>
        public Color Foreground { get; set; } = Color.Black;

        /// <summary>
        /// Gets or sets the text wrapping.
        /// </summary>
        public TextWrapping TextWrapping { get; set; }
    }
}
