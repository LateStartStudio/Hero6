// <copyright file="StatChangedEventArgsTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Stats
{
    using NUnit.Framework;

    [TestFixture]
    public class StatChangedEventArgsTests
    {
        [TestCase(Stat.Strength)]
        [TestCase(Stat.Climbing)]
        [TestCase(Stat.Stealth)]
        public void GetStatistic(Stat n)
        {
            Assert.AreEqual(n, new StatChangedEventArgs(n, 0).Stat);
        }

        [TestCase((uint)0)]
        [TestCase((uint)25)]
        [TestCase((uint)36)]
        public void GetValue(uint n)
        {
            Assert.AreEqual(n, new StatChangedEventArgs(Stat.Agility, n).Value);
        }
    }
}
