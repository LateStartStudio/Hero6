﻿// <copyright file="CampaignExtensions.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using LateStartStudio.Hero6.Engine.Campaigns;

public static class CampaignExtensions
{
    public static MonoGameCampaigns AsMonoGame(this ICampaigns campaigns) => (MonoGameCampaigns)campaigns;
}
