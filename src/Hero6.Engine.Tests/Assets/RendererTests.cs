// <copyright file="RendererTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Assets
{
    using NUnit.Framework;

    [TestFixture]
    public class RendererTests
    {
        [SetUp]
        public void SetUp()
        {
            RendererMock.IsPaused = false;
            RendererMock.IsDrawInvoked = false;
            RendererMock.IsDrawStringInvoked = false;
        }

        [Test]
        public void GetSetIsPaused()
        {
            Assume.That(Renderer.IsPaused, Is.False);
            Renderer.IsPaused = true;
            Assert.That(Renderer.IsPaused, Is.True);
        }
    }
}
