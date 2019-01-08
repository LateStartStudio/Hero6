// <copyright file="Dummy.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine
{
    using NUnit.Framework;

    [TestFixture]
    public class Dummy
    {
        [Test]
        public void DoDummy()
        {
            // Dummy test to pass CI runs because of error on on assemblies with zero tests.
            // Delete this file when assmebly has more tests
            Assert.Pass();
        }
    }
}
