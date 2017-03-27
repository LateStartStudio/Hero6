// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadEventArgsTests.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the LoadEventArgsTests unit tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.AdventureGame.GameLoop
{
    using NUnit.Framework;

    [TestFixture]
    public class LoadEventArgsTests
    {
        [Test]
        public void IsNotNull()
        {
            Assert.IsNotNull(new LoadEventArgs(MockCampaign.Instance.Content));
        }

        [Test]
        public void ContentGet()
        {
            Assert.AreEqual(MockCampaign.Instance.Content, new LoadEventArgs(MockCampaign.Instance.Content).Content);
        }
    }
}
