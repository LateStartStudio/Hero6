// <copyright file="ICampaigns.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System.Collections.Generic;
using LateStartStudio.Hero6.ModuleController.Campaigns;

namespace LateStartStudio.Hero6.Services.Campaigns
{
    /// <summary>
    /// The campaigns service that holds all the campaign modules.
    /// </summary>
    public interface ICampaigns
    {
        /// <summary>
        /// Gets all the campaign modules.
        /// </summary>
        IEnumerable<ICampaignModule> Campaigns { get; }

        /// <summary>
        /// Gets or sets the currently active campaign module.
        /// </summary>
        ICampaignModule Current { get; set; }

        void Add(ICampaignModule module);

        /// <summary>
        /// Interact event, looks for modules that the user have tried interacting with.
        /// </summary>
        /// <param name="x">The x coordinate the user interacted with.</param>
        /// <param name="y">The y coordinate the user interacted with.</param>
        /// <param name="interaction">The type of interaciton from user.</param>
        /// <returns>
        /// True if x and y intersects with a module and interaction is valid for said module. False if not.
        /// </returns>
        bool Interact(int x, int y, Interaction interaction);
    }
}
