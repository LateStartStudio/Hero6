// <copyright file="MockUserInterface.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces
{
    using System;
    using Assets;
    using Assets.Graphics;

    public class MockUserInterface : UserInterface
    {
        public MockUserInterface(Renderer renderer, AssetManager assets)
            : base(0, 0, default(Vector2), renderer, assets)
        {
        }

        public override void Load()
        {
        }

        public override void Unload()
        {
        }

        public override void Update(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
        }

        public override void Draw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
        }

        public override void ShowTextBox(string text)
        {
        }
    }
}
