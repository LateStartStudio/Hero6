// <copyright file="RoomControllerExtensions.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Engine.Campaigns.Rooms;

public static class RoomControllerExtensions
{
    public static MonoGameRoomController AsMonoGame(this RoomController room)
    {
        return (MonoGameRoomController)room;
    }
}
