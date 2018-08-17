// <copyright file="MonoGameInventoryItemController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.InventoryItems
{
    using LateStartStudio.Hero6.Engine.GameLoop;
    using Microsoft.Xna.Framework;

    public class MonoGameInventoryItemController : InventoryItemController, IXnaGameLoop
    {
        public MonoGameInventoryItemController(InventoryItemModule module)
            : base(module)
        {
        }

        public override int Width { get; }

        public override int Height { get; }

        public override bool Interact(int x, int y, Interaction interaction)
        {
            throw new System.NotImplementedException();
        }

        void IXnaGameLoop.Initialize()
        {
        }

        public void Load()
        {
            Initialize();
        }

        public void Unload()
        {
        }

        public void Update(GameTime time)
        {
        }

        public void Draw(GameTime time)
        {
        }
    }
}
