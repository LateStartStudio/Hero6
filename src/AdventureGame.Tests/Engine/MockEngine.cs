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

namespace LateStartStudio.AdventureGame.Engine
{
    using Graphics;

    public class MockEngine : Engine
    {
        public override GraphicsHandler Graphics => null;
    }
}
