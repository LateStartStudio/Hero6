// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Engine.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the Engine type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Engine
{
    using Graphics;

    /// <summary>
    /// An abstract class for an adventure game engine.
    /// </summary>
    public abstract class Engine
    {
        /// <summary>
        /// Gets the graphics handler of the engine.
        /// </summary>
        /// <value>
        /// The graphics handler of the engine.
        /// </value>
        public abstract GraphicsHandler Graphics { get; }

        /// <summary>
        /// Gets the asset handler of the engine.
        /// </summary>
        /// <value>
        /// The asset handler of the engine.
        /// </value>
        public abstract AssetHandler Assets { get; }
    }
}
