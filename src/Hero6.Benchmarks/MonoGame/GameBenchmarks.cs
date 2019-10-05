// <copyright file="GameBenchmarks.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using BenchmarkDotNet.Attributes;
using LateStartStudio.Hero6.Campaigns.RitesOfPassage;
using LateStartStudio.Hero6.UserInterfaces.SierraVga;

namespace LateStartStudio.Hero6.MonoGame
{
    public class GameBenchmarks
    {
        [Benchmark]
        public void LoadGame()
        {
            Game.Start(g =>
            {
                g.GraphicsDeviceCreated += (s, a) =>
                {
                    g.Campaigns.Add<RitesOfPassageModule>();
                    g.UserInterfaces.Add<SierraVgaModule>();
                    g.Logger.WillDeleteLogOnDispose = false; // Process locks log file so benchmark crashes
                };

                g.RunOneFrame();
            });
        }
    }
}
