﻿// <copyright file="LoadEventArgsTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.GameLoop
{
    using Campaigns;
    using NUnit.Framework;

    [TestFixture]
    public class LoadEventArgsTests
    {
        [Test]
        public void IsNotNull()
        {
            Assert.IsNotNull(new LoadEventArgs(MockCampaign.Instance.Assets));
        }

        [Test]
        public void ContentGet()
        {
            Assert.AreEqual(MockCampaign.Instance.Assets, new LoadEventArgs(MockCampaign.Instance.Assets).Assets);
        }
    }
}
