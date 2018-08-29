// <copyright file="ItemModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Items
{
    /// <summary>
    /// API for the item module.
    /// </summary>
    public abstract class ItemModule : GameModule<ItemController>
    {
        /// <summary>
        /// Gets the sprite path.
        /// </summary>
        public abstract string Sprite { get; }
    }
}
