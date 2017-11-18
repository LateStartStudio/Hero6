// <copyright file="RoomMock.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    public class RoomMock : Room
    {
        public RoomMock(Campaign campaign)
            : base(campaign, "Background", "Walk Area", "Hot Spots")
        {
        }

        protected override void InitializeEvents()
        {
        }
    }
}
