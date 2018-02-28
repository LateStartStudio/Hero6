// <copyright file="IAssetsFactory.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets
{
    /// <summary>
    /// Factory for creating <see cref="IAssets"/> instances.
    /// </summary>
    public interface IAssetsFactory
    {
        /// <summary>
        /// Creates a new <see cref="IAssets"/> instance.
        /// </summary>
        /// <returns>A new <see cref="IAssets"/> instance.</returns>
        IAssets Make();
    }
}
