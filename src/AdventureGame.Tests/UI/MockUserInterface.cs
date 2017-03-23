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

namespace LateStartStudio.AdventureGame.Tests.UI
{
    using System;
    using AdventureGame.Engine;
    using AdventureGame.Engine.Graphics;
    using AdventureGame.UI;

    public class MockUserInterface : UserInterface
    {
        public MockUserInterface(Engine adventureGameEngine, ContentManager content)
            : base(0, 0, new Vector2(), adventureGameEngine, content)
        {
        }

        public override void Load()
        {
        }

        public override void Unload()
        {
        }

        public override void Update(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly)
        {
        }

        public override void Draw(TimeSpan totalTime, TimeSpan elapsedTime, bool isRunningSlowly)
        {
        }

        public override void ShowTextBox(string text)
        {
        }
    }
}
