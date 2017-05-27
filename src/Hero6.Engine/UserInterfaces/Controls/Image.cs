// <copyright file="Image.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using System;

    using LateStartStudio.Hero6.Engine.Assets;
    using LateStartStudio.Hero6.Engine.Assets.Graphics;

    /// <summary>
    /// A image user interface element.
    /// </summary>
    public class Image : UserInterfaceElement
    {
        private Texture2D image;

        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        /// <param name="assets">The asset manager for this user interface module.</param>
        /// <param name="source">the source path for the texture.</param>
        public Image(AssetManager assets, string source)
            : base(assets)
        {
            this.Source = source;
        }

        /// <summary>
        /// Gets the source path for the texture.
        /// </summary>
        public string Source { get; }

        /// <inheritdoc cref="UserInterfaceElement"/>
        protected override int DefaultWidth => image.Width;

        /// <inheritdoc cref="UserInterfaceElement"/>
        protected override int DefaultHeight => image.Height;

        /// <inheritdoc />
        protected override void InternalLoad()
        {
            this.image = Assets.LoadTexture2D(Source);
        }

        /// <inheritdoc />
        protected override void InternalUnload()
        {
        }

        /// <inheritdoc />
        protected override void InternalUpdate(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
        }

        /// <inheritdoc />
        protected override void InternalDraw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            UserInterface.Renderer.Draw(image, Location);
        }
    }
}
