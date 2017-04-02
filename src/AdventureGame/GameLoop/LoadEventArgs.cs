// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadEventArgs.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the LoadEventArgs event args.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.GameLoop
{
    using System;
    using Engine;

    /// <summary>
    /// Event Args for load time of game loop.
    /// </summary>
    public class LoadEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoadEventArgs"/> class.
        /// </summary>
        /// <param name="content">The content manager.</param>
        public LoadEventArgs(ContentManager content)
        {
            this.Content = content;
        }

        /// <summary>
        /// Gets the content manager.
        /// </summary>
        /// <value>
        /// The content manager.
        /// </value>
        public ContentManager Content { get; private set; }
    }
}
