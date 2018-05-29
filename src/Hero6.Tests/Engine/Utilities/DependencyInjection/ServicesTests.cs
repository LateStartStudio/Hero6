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
        public void AddTypeWithConstructorSucceedsWhenArgumentIsInBank()
        {
            services.Add(0);
            services.Add<TestWithConstructor>();
            Assert.That(services.Get<TestWithConstructor>(), Is.Not.Null);
        }

        [Test]
        public void AddTypeWithConstructorFailsWhenArgumentIsNotInBank()
        {
            Assert.Throws<ArgumentException>(() => services.Add<TestWithConstructor>());
        }

        [Test]
        public void GetServiceExistingInBankIsNotNull() => Assert.That(services.Get<ITest>(), Is.Not.Null);

        [Test]
        public void GetServiceNotExistingInBankIsNull() => Assert.That(services.Get<Test>(), Is.Null);

        [Test]
        public void RemoveServiceFromBankSucceeds()
        {
            services.Remove<ITest>();
            Assert.That(services.Get<ITest>(), Is.Null);
        }

        [Test]
        public void MakeSucceeds()
        {
            Assert.That(services.Make<Test>(), Is.Not.Null);
        }

        [Test]
        public void MakeSucceedsIfParameterInBank()
        {
            services.Add(0);
            Assert.That(services.Make<TestWithConstructor>(), Is.Not.Null);
        }

        [Test]
        public void MakeThrowsExecptionIfParamterIsNotInBank()
        {
            Assert.Throws<ArgumentException>(() => services.Add<TestWithConstructor>());
        }

        protected abstract IServices Make();

        private class Test : ITest
        {
        }

        private class TestWithConstructor : ITest
        {
            public TestWithConstructor(int test)
            {
            }
        }
    }
}
