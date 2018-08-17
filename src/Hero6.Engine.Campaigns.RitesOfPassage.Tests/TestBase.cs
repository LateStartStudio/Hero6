// <copyright file="TestBase.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage
{
    using NUnit.Framework;

    public class TestBase
    {
        protected RitesOfPassageServicesProvider Services { get; private set; }

        [SetUp]
        public virtual void SetUp()
        {
            Services = new RitesOfPassageServicesProvider();
        }
    }
}
