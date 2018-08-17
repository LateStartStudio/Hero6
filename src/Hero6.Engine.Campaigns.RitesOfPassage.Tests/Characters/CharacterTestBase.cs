// <copyright file="CharacterTestBase.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.Campaigns.RitesOfPassage.Characters
{
    using LateStartStudio.Hero6.Engine.Campaigns.Characters;
    using NUnit.Framework;

    public class CharacterTestBase<TModule> : TestBase
        where TModule : CharacterModule
    {
        protected CharacterController Controller { get; private set; }

        protected TModule Module { get; private set; }

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Controller = Services.CampaignController.GetCharacter<TModule>();
            Module = Services.Campaigns.Current.GetCharacter<TModule>();
        }
    }
}
