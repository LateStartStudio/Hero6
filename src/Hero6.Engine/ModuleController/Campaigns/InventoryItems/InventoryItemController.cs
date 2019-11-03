// <copyright file="InventoryItemController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Services.DependencyInjection;
using Microsoft.Xna.Framework;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.InventoryItems
{
    /// <summary>
    /// API for inventory item controller.
    /// </summary>
    public class InventoryItemController : GameController<IInventoryItemController, IInventoryItemModule>, IInventoryItemController
    {
        /// <summary>
        /// Makes a new instance of the <see cref="InventoryItemController"/> class.
        /// </summary>
        /// <param name="module">The module for this controller.</param>
        public InventoryItemController(IInventoryItemModule module, IServiceLocator services) : base(module, services)
        {
        }

        public override int Width { get; }

        public override int Height { get; }

        public override bool Interact(int x, int y, Interaction interaction)
        {
            throw new System.NotImplementedException();
        }

        public override void Load()
        {
        }

        public override void Unload()
        {
        }

        public override void Update(GameTime time)
        {
        }

        public override void Draw(GameTime time)
        {
        }
    }
}
