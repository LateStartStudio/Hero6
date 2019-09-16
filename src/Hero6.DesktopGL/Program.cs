// <copyright file="Program.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

using System;
using LateStartStudio.Hero6.Campaigns.RitesOfPassage;
using LateStartStudio.Hero6.MonoGame;
using LateStartStudio.Hero6.UserInterfaces.SierraVga;

namespace LateStartStudio.Hero6
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Game.Start(g =>
            {
                g.GraphicsDeviceCreated += (s, a) =>
                {
                    g.Campaigns.Add<RitesOfPassageModule>();
                    g.UserInterfaces.Add<SierraVgaModule>();
                };

                g.Run();
            });
        }
    }
}
