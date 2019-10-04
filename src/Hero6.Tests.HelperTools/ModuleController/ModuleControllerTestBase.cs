// <copyright file="ModuleControllerTestBase.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Tests.Categories;
using NUnit.Framework;

namespace LateStartStudio.Hero6.ModuleController
{
    public abstract class ModuleControllerTestBase<TModule, TController> : TestBase
        where TController : IController
        where TModule : IModule
    {
        protected TModule Module { get; private set; }

        protected TController Controller { get; private set; }

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Module = MakeModule();
            Controller = MakeController();
            PreInitialize();
            Initialize();
        }

        protected abstract TModule MakeModule();

        protected abstract TController MakeController();

        protected override void PreInitialize() => Controller.PreInitialize();

        protected override void Initialize() => Controller.Initialize();
    }
}
