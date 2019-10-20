// <copyright file="PlatformInfoTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Tests.Categories;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Services.PlatformInfo
{
    [TestFixture]
    [UnitCategory]
    public class PlatformInfoTests : ServiceTestBase<PlatformInfo>
    {
        [Test]
        public void GetsCorrectPlatform()
        {
            Assert.That(Service.Platform, Is.EqualTo(Platform.Desktop));
        }

        protected override PlatformInfo MakeService() => new PlatformInfo();
    }
}
