﻿// <copyright file="Image.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using System;
    using Assets;
    using Assets.Graphics;
    using Utilities.DependencyInjection;

    /// <summary>
    /// A image user interface element.
    /// </summary>
    public class Image : UserInterfaceElement
    {
        private static readonly IRenderer Renderer;

        private Texture2D image;

        static Image()
        {
            Renderer = ServicesBank.Instance.Get<IRenderer>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        /// <param name="assets">The asset manager for this user interface module.</param>
        /// <param name="source">the source path for the texture.</param>
        public Image(IAssets assets, string source)
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
            Renderer.Draw(image, Location);
        }
    }
}
