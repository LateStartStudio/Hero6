// <copyright file="AdventureGameElementMock.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using System;

    public class AdventureGameElementMock : AdventureGameElement
    {
        public AdventureGameElementMock(Campaign campaign)
            : base(campaign)
        {
            this.Width = 0;
            this.Height = 0;
        }

        public bool IsUpdateInvoked { get; private set; }

        public bool IsDrawInvoked { get; private set; }

        public override int Width { get; }

        public override int Height { get; }

        public override bool Interact(int x, int y, Interaction interaction)
        {
            return true;
        }

        protected override void InternalLoad()
        {
        }

        protected override void InternalUnload()
        {
        }

        protected override void InternalUpdate(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            this.IsUpdateInvoked = true;
        }

        protected override void InternalDraw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            this.IsDrawInvoked = true;
        }
    }
}
