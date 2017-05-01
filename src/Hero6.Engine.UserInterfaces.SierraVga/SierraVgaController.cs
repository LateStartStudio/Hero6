// <copyright file="SierraVgaController.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.SierraVga
{
    using System;

    using LateStartStudio.Hero6.Engine.Assets;
    using LateStartStudio.Hero6.Engine.Assets.Graphics;
    using LateStartStudio.Hero6.Engine.GameLoop;

    public class SierraVgaController : UserInterface
    {
        public SierraVgaController(
            int width,
            int height,
            Vector2 scale,
            Renderer renderer,
            AssetManager assets)
            : base(width, height, scale, renderer, assets)
        {
            this.Assets.RootDirectory = "Content/Gui/Sierra Vga";
        }

        public override void Load()
        {
            this.InvokePreLoad(this, new LoadEventArgs(this.Assets));

            this.InvokePostLoad(this, new LoadEventArgs(this.Assets));
        }

        public override void Unload()
        {
            this.InvokePreUnload(this, new UnloadEventArgs());

            this.InvokePostUnload(this, new UnloadEventArgs());
        }

        public override void Update(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            this.InvokePreUpdate(this, new UpdateEventArgs(total, elapsed, isRunningSlowly));

            this.InvokePostUpdate(this, new UpdateEventArgs(total, elapsed, isRunningSlowly));
        }

        public override void Draw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            this.InvokePreDraw(this, new DrawEventArgs(total, elapsed, isRunningSlowly, Renderer));

            this.InvokePostDraw(this, new DrawEventArgs(total, elapsed, isRunningSlowly, Renderer));
        }

        public override void ShowTextBox(string text)
        {
        }
    }
}
