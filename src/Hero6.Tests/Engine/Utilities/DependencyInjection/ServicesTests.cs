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
        private const string Test = "Test";

        private IServices services;

        [SetUp]
        public void SetUp()
        {
            services = Make();
            services.Add(Test);
        }

        [Test]
        public void AddDuplicateThrowsException() => Assert.Throws<ArgumentException>(() => services.Add(Test));

        [Test]
        public void Get() => Assert.That(services.Get<string>(), Is.EqualTo(Test));

        [Test]
        public void Remove()
        {
            services.Remove(typeof(string));
            Assert.That(services.Get<string>(), Is.Null);
        }

        protected abstract IServices Make();
    }
}
