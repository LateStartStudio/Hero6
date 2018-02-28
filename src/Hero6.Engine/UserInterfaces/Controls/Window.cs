// <copyright file="Window.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using System;

    using LateStartStudio.Hero6.Engine.Assets;

    /// <summary>
    /// A standard window. All windows will render within the main window instance that is hosting
    /// the rendering.
    /// </summary>
    public class Window : UserInterfaceElement, IChild
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class.
        /// </summary>
        /// <param name="assets">The asset manager of this user interface module.</param>
        public Window(IAssets assets)
            : base(assets)
        {
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
            Child?.Load();
        }

        /// <inheritdoc />
        protected override void InternalUnload()
        {
            Child?.Unload();
        }

        /// <inheritdoc />
        protected override void InternalUpdate(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            if (Child == null)
            {
                return;
            }

            this.Child.X = X;
            this.Child.Y = Y;
            Child.Update(total, elapsed, isRunningSlowly);
        }

        /// <inheritdoc />
        protected override void InternalDraw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            Child?.Draw(total, elapsed, isRunningSlowly);
        }
    }
}
