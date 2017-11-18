// <copyright file="HotspotTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Regions
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class HotspotTests
    {
        private bool isInvoked;
        private Hotspot hotspot;

        [SetUp]
        public void SetUp()
        {
            this.isInvoked = false;
            this.hotspot = new Hotspot();
        }

        [Test]
        public void InvokeLook()
        {
            this.hotspot.Look += (s, a) => isInvoked = true;
            hotspot.InvokeLook(EventArgs.Empty);
            Assert.That(isInvoked, Is.True);
        }

        [Test]
        public void InvokeGrab()
        {
            this.hotspot.Grab += (s, a) => isInvoked = true;
            hotspot.InvokeGrab(EventArgs.Empty);
            Assert.That(isInvoked, Is.True);
        }

        [Test]
        public void InvokeTalk()
        {
            this.hotspot.Talk += (s, a) => isInvoked = true;
            hotspot.InvokeTalk(EventArgs.Empty);
            Assert.That(isInvoked, Is.True);
        }

        [Test]
        public void InvokeWhileStandingIn()
        {
            this.hotspot.WhileStandingIn += (s, a) => isInvoked = true;
            hotspot.InvokeWhileStandingIn(new HotspotWalkingEventArgs(new CharacterMock(CampaignMock.Make())));
            Assert.That(isInvoked, Is.True);
        }
    }
}
