// <copyright file="Layout.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using System;
    using System.Collections.Generic;

    using LateStartStudio.Hero6.Engine.Assets;

    /// <summary>
    /// A standard layout.
    /// </summary>
    public abstract class Layout : UserInterfaceElement, IChildren
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Layout"/> class.
        /// </summary>
        /// <param name="assets">The asset manager for this user interface module.</param>
        protected Layout(AssetManager assets)
            : base(assets)
        {
        }

        /// <summary>
        /// Gets the children.
        /// </summary>
        public List<UserInterfaceElement> Children { get; } = new List<UserInterfaceElement>();

        /// <inheritdoc />
        protected override void InternalUnload()
        {
            foreach (UserInterfaceElement userInterfaceElement in Children)
            {
                userInterfaceElement.Unload();
            }
        }

        /// <inheritdoc />
        protected override void InternalDraw(
            TimeSpan totalTime,
            TimeSpan elapsedTime,
            bool isRunningSlowly)
        {
            foreach (UserInterfaceElement userInterfaceElement in Children)
            {
                userInterfaceElement.Draw(totalTime, elapsedTime, isRunningSlowly);
            }
        }
    }
}
