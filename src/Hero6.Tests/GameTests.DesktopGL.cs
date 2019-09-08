// <copyright file="GameTests.DesktopGL.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using NUnit.Framework;

#if DESKTOPGL
namespace LateStartStudio.Hero6
{
    public partial class GameTests
    {
        partial void GraphicsApiGetPlatform()
        {
            Assert.That(Game.GraphicsApi, Is.EqualTo("DesktopGL"));
        }
    }
}
#endif
