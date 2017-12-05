// <copyright file="RoomMock.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    public class RoomMock : Room
    {
        public RoomMock(Campaign campaign, string backgroundId, string walkAreaId, string hotSpotId)
            : base(campaign, backgroundId, walkAreaId, hotSpotId)
        {
        }

        protected override void InitializeEvents()
        {
        }
    }
}
