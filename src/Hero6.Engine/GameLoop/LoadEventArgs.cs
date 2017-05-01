// <copyright file="LoadEventArgs.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.GameLoop
{
    using System;
    using Assets;

    /// <summary>
    /// Event Args for load time of game loop.
    /// </summary>
    public class LoadEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoadEventArgs"/> class.
        /// </summary>
        /// <param name="assets">The asset manager.</param>
        public LoadEventArgs(AssetManager assets)
        {
            this.Assets = assets;
        }

        /// <summary>
        /// Gets the asset manager.
        /// </summary>
        /// <value>
        /// The asset manager.
        /// </value>
        public AssetManager Assets { get; private set; }
    }
}
