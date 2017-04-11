// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Util.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the Util type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Engine.Utilities
{
    using Logger;
    using Settings;

    /// <summary>
    /// A collection of utility tools.
    /// </summary>
    public class Util
    {
        /// <summary>
        /// Gets or sets the logger utility.
        /// </summary>
        /// <value>
        /// The logger utility.
        /// </value>
        public static ILogger Logger { get; set; }

        /// <summary>
        /// Gets or sets the user settings utility.
        /// </summary>
        /// <value>
        /// The user settings utility.
        /// </value>
        public static IUserSettings UserSettings { get; set; }
    }
}
