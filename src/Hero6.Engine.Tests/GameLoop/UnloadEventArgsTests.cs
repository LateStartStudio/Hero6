// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnloadEventArgsTests.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the UnloadEventArgsTests unit tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Engine.GameLoop
{
    using NUnit.Framework;

    [TestFixture]
    public class UnloadEventArgsTests
    {
        [Test]
        public void IsNotNull()
        {
            Assert.IsNotNull(new UnloadEventArgs());
        }
    }
}
