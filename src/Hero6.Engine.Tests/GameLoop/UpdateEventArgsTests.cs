﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateEventArgsTests.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the UpdateEventArgsTests unit tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Engine.GameLoop
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class UpdateEventArgsTests
    {
        [Test]
        public void IsNotNull()
        {
            Assert.IsNotNull(new UpdateEventArgs(TimeSpan.Zero, TimeSpan.Zero, false));
        }

        [Test]
        public void TotalTimeGet()
        {
            TimeSpan expected = TimeSpan.FromHours(4);
            Assert.AreEqual(expected, new UpdateEventArgs(expected, TimeSpan.Zero, false).TotalTime);
        }

        [Test]
        public void ElapsedTimeGet()
        {
            TimeSpan expected = TimeSpan.FromHours(4);
            Assert.AreEqual(expected, new UpdateEventArgs(TimeSpan.Zero, expected, false).ElapsedTime);
        }

        [Test]
        public void IsRunningSlowlyGet()
        {
            const bool Expected = false;
            Assert.AreEqual(Expected, new UpdateEventArgs(TimeSpan.Zero, TimeSpan.Zero, Expected).IsRunningSlowly);
        }
    }
}
