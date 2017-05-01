// <copyright file="StackPanel.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using System;

    using LateStartStudio.Hero6.Engine.Assets;

    /// <summary>
    /// Stack panel to order user interface components horizontally, or vertically.
    /// </summary>
    public class StackPanel : Layout
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StackPanel"/> class.
        /// </summary>
        /// <param name="assets">The asset manager of this user interface module.</param>
        public StackPanel(AssetManager assets)
            : base(assets)
        {
        }

        /// <summary>
        /// Gets or sets the orientation of the children.
        /// </summary>
        public Orientation Orientation { get; set; }

        /// <inheritdoc />
        protected override void InternalLoad()
        {
            int width = 0;
            int height = 0;

            foreach (UserInterfaceElement userInterfaceElement in Children)
            {
                userInterfaceElement.Load();

                if (Orientation == Orientation.Horizontal)
                {
                    width += userInterfaceElement.Width;

                    if (userInterfaceElement.Height > height)
                    {
                        height = userInterfaceElement.Height;
                    }
                }
                else
                {
                    height += userInterfaceElement.Height;

                    if (userInterfaceElement.Width > width)
                    {
                        width = userInterfaceElement.Width;
                    }
                }
            }

            if (Width == -1)
            {
                this.Width = width;
            }

            if (Height == -1)
            {
                this.Height = height;
            }
        }

        /// <inheritdoc />
        protected override void InternalUpdate(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            int sum = 0;

            foreach (UserInterfaceElement userInterfaceElement in Children)
            {
                if (Orientation == Orientation.Horizontal)
                {
                    userInterfaceElement.X = sum;
                    sum += userInterfaceElement.Width;
                }
                else
                {
                    userInterfaceElement.Y = sum;
                    sum += userInterfaceElement.Height;
                }

                userInterfaceElement.Update(total, elapsed, isRunningSlowly);
            }
        }
    }
}
