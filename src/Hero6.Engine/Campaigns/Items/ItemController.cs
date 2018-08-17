// <copyright file="ItemController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Items
{
    public abstract class ItemController : GameController<ItemController, ItemModule>
    {
        protected ItemController(ItemModule module) : base(module)
        {
        }
    }
}
