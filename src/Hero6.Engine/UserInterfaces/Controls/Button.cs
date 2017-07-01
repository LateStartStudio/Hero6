// <copyright file="Button.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using System;

    using LateStartStudio.Hero6.Engine.Assets;

    /// <summary>
    /// A button control.
    /// </summary>
    public class Button : UserInterfaceElement, IChild
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        /// <param name="assets">The asset manager of this user interface.</param>
        /// <param name="child">The user interface inside this button.</param>
        public Button(AssetManager assets, UserInterfaceElement child)
            : base(assets)
        {
            this.Child = child;
        }

        /// <inheritdoc />
        public UserInterfaceElement Child { get; set; }

        /// <inheritdoc cref="UserInterfaceElement"/>
        protected override int DefaultWidth => Child.Width;

        /// <inheritdoc cref="UserInterfaceElement"/>
        protected override int DefaultHeight => Child.Height;

        /// <inheritdoc />
        protected override void InternalLoad()
        {
            Child.Load();
        }

        /// <inheritdoc />
        protected override void InternalUnload()
        {
        }

        /// <inheritdoc />
        protected override void InternalUpdate(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            this.Child.X = X;
            this.Child.Y = Y;
            Child.Update(total, elapsed, isRunningSlowly);
        }

        /// <inheritdoc />
        protected override void InternalDraw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            Child.Draw(total, elapsed, isRunningSlowly);
        }
    }
}
