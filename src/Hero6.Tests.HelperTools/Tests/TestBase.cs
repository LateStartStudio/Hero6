// <copyright file="TestBase.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.Services;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Tests.Categories
{
    public abstract class TestBase
    {
        protected IServicesRepository Services { get; private set; }

        [SetUp]
        public virtual void SetUp()
        {
            Services = MakeServices();
        }

        protected IServicesRepository MakeServices()
        {
            var type = GetType();

            if (type.GetCustomAttributes(typeof(UnitAttribute), true).Length > 0)
            {
                return new FakeServices();
            }
            else if (type.GetCustomAttributes(typeof(ComponentAttribute), true).Length > 0)
            {
                Assert.Fail("Services for component tests hasn't been setup yet");
            }
            else if (type.GetCustomAttributes(typeof(IntegrationAttribute), true).Length > 0)
            {
                Assert.Fail("Services for integration tests hasn't been setup yet");
            }
            else
            {
                Assert.Fail("Could not find category attribute on test class. Did you remember to set it?");
            }

            return null;
        }
    }
}
