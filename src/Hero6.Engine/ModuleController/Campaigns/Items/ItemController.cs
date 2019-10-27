// <copyright file="ItemController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Services.DependencyInjection;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Items
{
    /// <summary>
    /// API for item controller.
    /// </summary>
    public abstract class ItemController : GameController<ItemController, IItemModule>
    {
        /// <summary>
        /// Makes a new instance of the <see cref="ItemController"/> class.
        /// </summary>
        /// <param name="module">The module for this controller.</param>
        protected ItemController(IItemModule module, IServiceLocator services) : base(module, services)
        {
        }
    }
}
