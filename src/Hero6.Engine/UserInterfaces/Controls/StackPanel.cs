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
        public StackPanel(IAssets assets)
            : base(assets)
        {
        }

        /// <summary>
        /// Gets or sets the orientation of the children.
        /// </summary>
        public Orientation Orientation { get; set; }

        /// <inheritdoc cref="UserInterfaceElement"/>
        protected override int DefaultWidth
        {
            get
            {
                int width = 0;

                foreach (UserInterfaceElement userInterfaceElement in Children)
                {
                    if (Orientation == Orientation.Horizontal)
                    {
                        width += userInterfaceElement.Width;
                    }
                    else
                    {
                        if (userInterfaceElement.Width > width)
                        {
                            width = userInterfaceElement.Width;
                        }
                    }
                }

                return width;
            }
        }

        /// <inheritdoc cref="UserInterfaceElement"/>
        protected override int DefaultHeight
        {
            get
            {
                int height = 0;

                foreach (UserInterfaceElement userInterfaceElement in Children)
                {
                    if (Orientation == Orientation.Horizontal)
                    {
                        if (userInterfaceElement.Height > height)
                        {
                            height = userInterfaceElement.Height;
                        }
                    }
                    else
                    {
                        height += userInterfaceElement.Height;
                    }
                }

                return height;
            }
        }

        /// <inheritdoc />
        protected override void InternalLoad()
        {
            foreach (UserInterfaceElement userInterfaceElement in Children)
            {
                userInterfaceElement.Load();
            }
        }

        /// <inheritdoc />
        protected override void InternalUpdate(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            int x = X;
            int y = Y;

            foreach (UserInterfaceElement userInterfaceElement in Children)
            {
                userInterfaceElement.X = x;
                userInterfaceElement.Y = y;
                userInterfaceElement.Update(total, elapsed, isRunningSlowly);

                if (Orientation == Orientation.Horizontal)
                {
                    x += userInterfaceElement.Width;
                }
                else
                {
                    y += userInterfaceElement.Height;
                }
            }
        }
    }
}
