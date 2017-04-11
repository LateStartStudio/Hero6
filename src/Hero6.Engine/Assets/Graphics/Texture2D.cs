// <copyright file="Texture2D.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets.Graphics
{
    /// <summary>
    /// An abstract class for a 2D texture.
    /// </summary>
    public abstract class Texture2D
    {
        /// <summary>
        /// Gets the width of the texture.
        /// </summary>
        /// <value>
        /// The width of the texture.
        /// </value>
        public abstract int Width { get; }

        /// <summary>
        /// Gets the height of the texture.
        /// </summary>
        /// <value>
        /// The height of the texture.
        /// </value>
        public abstract int Height { get; }

        /// <summary>
        /// Gets the texture.
        /// </summary>
        /// <value>
        /// The texture.
        /// </value>
        public abstract object GetTexture { get; }

        /// <summary>
        /// Gets the data within the texture.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="data">The array of data within the texture.</param>
        public abstract void GetData<T>(T[] data) where T : struct;
    }
}
