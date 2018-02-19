// <copyright file="HotspotWalkingEventArgsTests.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.Regions
{
    using NUnit.Framework;

    [TestFixture]
    public class HotspotWalkingEventArgsTests : TestBase
    {
        private CharacterMock character;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            character = (CharacterMock)Campaign.GetCharacter(CampaignMock.Character1);
        }

        [Test]
        public void MakeDefault()
        {
            Assert.That(character, Is.EqualTo(new HotspotWalkingEventArgs(character).Character));
        }
    }
}
