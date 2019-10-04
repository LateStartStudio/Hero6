// <copyright file="ServiceLocatorTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.Services.DependencyInjection;
using LateStartStudio.Hero6.Tests.Categories;
using Microsoft.Xna.Framework;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Services
{
    [TestFixture]
    [UnitCategory]
    public class ServiceLocatorTests : ServiceTestBase<IServiceLocator>
    {
        private interface ITest
        {
        }

        [Test]
        public void AddDuplicateThrowsException() => Assert.Throws<ArgumentException>(() => Service.Add<ITest, Test>());

        [Test]
        public void AddTypeWithConstructorSucceedsWhenArgumentIsInBank()
        {
            Service.Add(0);
            Service.Add<TestWithConstructor>();
            Assert.That(Service.Get<TestWithConstructor>(), Is.Not.Null);
        }

        [Test]
        public void AddTypeWithConstructorFailsWhenArgumentIsNotInBank()
        {
            Assert.Throws<ArgumentException>(() => Service.Add<TestWithConstructor>());
        }

        [Test]
        public void GetServiceExistingInBankIsNotNull()
        {
            Assert.That(Service.Get<ITest>(), Is.Not.Null);
        }

        [Test]
        public void GetServiceNotExistingInBankIsNull() => Assert.That(Service.Get<Test>(), Is.Null);

        [Test]
        public void RemoveServiceFromBankSucceeds()
        {
            Service.Remove<ITest>();
            Assert.That(Service.Get<ITest>(), Is.Null);
        }

        [Test]
        public void MakeSucceeds()
        {
            Assert.That(Service.Make<Test>(typeof(Test)), Is.Not.Null);
        }

        [Test]
        public void MakeSucceedsIfParameterInBank()
        {
            Service.Add(0);
            Assert.That(Service.Make<TestWithConstructor>(typeof(TestWithConstructor)), Is.Not.Null);
        }

        [Test]
        public void MakeThrowsExecptionIfParamterIsNotInBank()
        {
            Assert.Throws<ArgumentException>(() => Service.Add<TestWithConstructor>());
        }

        protected override IServiceLocator MakeService() => new MonoGameServiceLocator(new GameServiceContainer());

        protected override void Initialize()
        {
            base.Initialize();
            Service.Add<ITest, Test>();
        }

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
