// <copyright file="CharacterTestBase.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using NSubstitute;

namespace LateStartStudio.Hero6.ModuleController.Campaigns.Characters
{
    public abstract class CharacterTestBase<TModule> : ModuleControllerTestBase<TModule, CharacterController>
        where TModule : CharacterModule
    {
        protected override CharacterController MakeController() => Substitute.For<CharacterController>(Module, Services.Services);
    }
}
