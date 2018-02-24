// <copyright file="DrawEventArgsTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.GameLoop
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class DrawEventArgsTests
    {
        [Test]
        public void IsNotNull()
        {
            Assert.IsNotNull(new DrawEventArgs(TimeSpan.Zero, TimeSpan.Zero, false));
        }

        [Test]
        public void TotalTimeGet()
        {
            TimeSpan expected = TimeSpan.FromHours(4);
            Assert.AreEqual(expected, new DrawEventArgs(expected, TimeSpan.Zero, false).TotalTime);
        }

        [Test]
        public void ElapsedTimeGet()
        {
            TimeSpan expected = TimeSpan.FromHours(4);
            Assert.AreEqual(expected, new DrawEventArgs(TimeSpan.Zero, expected, false).ElapsedTime);
        }

        [Test]
        public void IsRunningSlowlyGet()
        {
            const bool Expected = false;
            Assert.AreEqual(Expected, new DrawEventArgs(TimeSpan.Zero, TimeSpan.Zero, Expected).IsRunningSlowly);
        }
    }
}
