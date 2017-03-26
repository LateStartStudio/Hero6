// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6
{
    using System;
    using AdventureGame.Utilities;
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
            using (Game game = new Game())
            {
                game.Run();
            }
#else
            try
            {
                using (Game game = new Game())
                {
                    game.Run();
                }
            }
            catch (Exception e)
            {
                Util.Logger.Fatal("Hero6 has crashed, logging stack strace.", e);
                Util.Logger.WillDeleteLogOnDispose = false;

                new Application(Platform.Detect).Run(new CrashDialog(e));
            }
#endif
        }
    }
}
