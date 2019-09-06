// <copyright file="InventoryItemController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.InventoryItems
{
    using LateStartStudio.Hero6.Engine.Utilities.DependencyInjection;

    /// <summary>
    /// API for inventory item controller.
    /// </summary>
    public abstract class InventoryItemController : GameController<InventoryItemController, InventoryItemModule>
    {
        /// <summary>
        /// Makes a new instance of the <see cref="InventoryItemController"/> class.
        /// </summary>
        /// <param name="module">The module for this controller</param>
        protected InventoryItemController(InventoryItemModule module, IServices services) : base(module, services)
        {
        }
    }
}
