// <copyright file="ServiceTestBase.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.MonoGame.GameLoop;
using LateStartStudio.Hero6.Tests.Categories;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Services
{
    public abstract class ServiceTestBase<TService> : TestBase
    {
        protected TService Service { get; set; }

        protected IXnaGameLoop IXnaGameLoop => Service as IXnaGameLoop;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Service = MakeService();
            IXnaGameLoop?.Initialize();
            IXnaGameLoop?.Load();
        }

        [TearDown]
        public virtual void TearDown() => IXnaGameLoop?.Unload();

        protected abstract TService MakeService();
    }
}
