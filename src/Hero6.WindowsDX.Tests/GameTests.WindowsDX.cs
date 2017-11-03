// <copyright file="GameTests.WindowsDX.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

#if WINDOWSDX
namespace LateStartStudio.Hero6
{
    using NUnit.Framework;

    public partial class GameTests
    {
        partial void GraphicsApiGetPlatform()
        {
            Assert.That(Game.GraphicsApi, Is.EqualTo("WindowsDX"));
        }
    }
}
#endif
