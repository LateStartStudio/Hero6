// <copyright file="MonoGameServicesTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using Microsoft.Xna.Framework;
using NUnit.Framework;

namespace LateStartStudio.Hero6.Engine.Utilities.DependencyInjection
{
    [TestFixture]
    public class MonoGameServicesTests : ServicesTests
    {
        protected override IServices Make() => new MonoGameServices(new GameServiceContainer());
    }
}
