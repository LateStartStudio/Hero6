// <copyright file="ItemController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Items
{
    using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;

    /// <summary>
    /// API for item controller.
    /// </summary>
    public abstract class ItemController : GameController<ItemController, ItemModule>
    {
        /// <summary>
        /// Makes a new instance of the <see cref="ItemController"/> class.
        /// </summary>
        /// <param name="module">The module for this controller.</param>
        protected ItemController(ItemModule module, IServices services) : base(module, services)
        {
        }
    }
}
