// <copyright file="ServicesBankTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Utilities.DependencyInjection
{
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class ServicesBankTests
    {
        [SetUp]
        public void SetUp() => ServicesBank.Instance = null;

        [Test]
        public void GetServiceBank()
        {
            var instance = Substitute.For<IServices>();
            ServicesBank.Instance = instance;
            Assert.That(ServicesBank.Instance, Is.EqualTo(instance));
        }
    }
}
