// <copyright file="MonoGameServicesTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Utilities.DependencyInjection
{
    using Microsoft.Xna.Framework;
    using NUnit.Framework;

    [TestFixture]
    public class MonoGameServicesTests : ServicesTests
    {
        protected override IServices Make() => new MonoGameServices(new GameServiceContainer());
    }
}
