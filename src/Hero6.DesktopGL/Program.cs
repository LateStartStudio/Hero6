// <copyright file="Program.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6
{
    using System;
    using Engine.Utilities.DependencyInjection;
    using Engine.Utilities.Logger;
    using Eto;
    using Eto.Forms;

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
#if DEBUG
            using (var game = new Game())
            {
                game.Run();
            }
#else
            try
            {
                Game.Start();
            }
            catch (Exception e)
            {
                var logger = ServicesBank.Instance.Get<ILogger>();
                logger.Fatal("Hero6 has crashed, logging stack strace.", e);
                logger.WillDeleteLogOnDispose = false;

                new Application(Platform.Detect).Run(new CrashDialog(e));
            }
#endif
        }
    }
}
