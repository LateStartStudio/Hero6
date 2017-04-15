// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockUserInterface.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the MockUserInterface type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Engine.UserInterfaces
{
    using System;
    using Assets;
    using Assets.Graphics;

    public class MockUserInterface : UserInterface
    {
        public MockUserInterface(Renderer renderer, AssetManager assets)
            : base(0, 0, new Vector2(), renderer, assets)
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
