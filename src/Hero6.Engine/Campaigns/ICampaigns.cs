// <copyright file="ICampaigns.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns
{
    using System.Collections.Generic;

    /// <summary>
    /// The campaigns service that holds all the campaign modules.
    /// </summary>
    public interface ICampaigns
    {
        /// <summary>
        /// Gets all the campaign modules.
        /// </summary>
        IEnumerable<Campaign> Campaigns { get; }

        /// <summary>
        /// Gets or sets the currently active campaign module.
        /// </summary>
        Campaign Current { get; set; }
    }
}
