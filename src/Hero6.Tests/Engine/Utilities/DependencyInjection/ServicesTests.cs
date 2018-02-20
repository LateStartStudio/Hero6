// <copyright file="ServicesTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Utilities.DependencyInjection
{
    using System;
    using NUnit.Framework;

    public abstract class ServicesTests
    {
        private IServices services;

        private interface ITest
        {
        }

        [SetUp]
        public void SetUp()
        {
            services = Make();
            services.Add<ITest, Test>();
        }

        [Test]
        public void AddDuplicateThrowsException() => Assert.Throws<ArgumentException>(() => services.Add<ITest, Test>());

        [Test]
        public void Get() => Assert.That(services.Get<ITest>(), Is.Not.Null);

        [Test]
        public void Remove()
        {
            services.Remove<ITest>();
            Assert.That(services.Get<ITest>(), Is.Null);
        }

        protected abstract IServices Make();

        private class Test : ITest
        {
        }
    }
}
