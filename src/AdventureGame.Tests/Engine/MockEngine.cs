// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockEngine.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the MockEngine type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.Tests.Engine
{
    using AdventureGame.Engine;
    using AdventureGame.Engine.Graphics;

    public class MockEngine : Engine
    {
        public override GraphicsHandler Graphics => null;
    }
}
