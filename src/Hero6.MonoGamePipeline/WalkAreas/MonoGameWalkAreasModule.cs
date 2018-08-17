// <copyright file="MonoGameWalkAreasModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.MonoGamePipeline.WalkAreas
{
    using System.Collections.Generic;
    using LateStartStudio.Hero6.Engine.Campaigns.Rooms.Regions;

    public class MonoGameWalkAreasModule : WalkAreasModule
    {
        public MonoGameWalkAreasModule(IEnumerable<WalkArea> areas)
        {
            Areas = new List<WalkArea>(areas);
        }

        public override string Name { get; }

        public IEnumerable<WalkArea> Areas { get; }
    }
}
