﻿// <copyright file="TestBase.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

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

        protected virtual IServicesRepository MakeServices() => new FakeServices();
    }
}
