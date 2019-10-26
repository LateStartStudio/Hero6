// <copyright file="ICursorModule.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.ModuleController.UserInterfaces.Input.Mouse
{
    /// <summary>
    /// The <see cref="ICursorModule"/> interface.
    /// </summary>
    public interface ICursorModule : IModule
    {
        /// <summary>
        /// Gets the cursor source.
        /// </summary>
        string Source { get; }

        /// <summary>
        /// Checks types if it is the same cursor.
        /// </summary>
        /// <typeparam name="T">The cursor type to check.</typeparam>
        /// <returns>True if same type, false if not.</returns>
        bool Equals<T>() where T : ICursorModule;
    }
}
