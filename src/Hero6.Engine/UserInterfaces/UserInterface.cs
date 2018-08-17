// <copyright file="UserInterface.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces
{
    using System;
    using System.Collections.Generic;
    using Controls;
    using Input;

    /// <summary>
    /// The <see cref="UserInterface"/> class.
    /// </summary>
    public abstract class UserInterface
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the directory of the content.
        /// </summary>
        public abstract string Directory { get; }

        /// <summary>
        /// Gets the user interface generator.
        /// </summary>
        public abstract IUserInterfaceGenerator UserInterfaceGenerator { get; }

        /// <summary>
        /// Gets the windows.
        /// </summary>
        public virtual IDictionary<Type, Window> Windows { get; } = new Dictionary<Type, Window>();

        /// <summary>
        /// Gets the dialogs.
        /// </summary>
        public virtual IDictionary<Type, Dialog> Dialogs { get; } = new Dictionary<Type, Dialog>();

        /// <summary>
        /// Shows the text box.
        /// </summary>
        /// <param name="text">The text to show.</param>
        public abstract void ShowTextBox(string text);

        /// <summary>
        /// Get window specified by generic.
        /// </summary>
        /// <typeparam name="T">The window to get.</typeparam>
        /// <returns>The window specified.</returns>
        public T GetWindow<T>() where T : Window => (T)Windows[typeof(T)];

        /// <summary>
        /// Get dialog specified by generic.
        /// </summary>
        /// <typeparam name="T">The dialog to get.</typeparam>
        /// <returns>The dialog specified.</returns>
        public T GetDialog<T>() where T : Dialog => (T)Dialogs[typeof(T)];

        public virtual void Initialize()
        {
        }

        /// <summary>
        /// A compiled list of all the windows in this module for the engine to make.
        /// </summary>
        /// <returns>A compiled list of all the windows in this module.</returns>
        public abstract IEnumerable<Type> GenerateWindows();

        /// <summary>
        /// A compiled list of all the dialogs in this module for the engine to make.
        /// </summary>
        /// <returns>A compiled list of all the dialogs in this module.</returns>
        public abstract IEnumerable<Type> GenerateDialogs();

        /// <summary>
        /// A compiled list of all the cursors in this module for the engine to make.
        /// </summary>
        /// <returns>A compiled list of all the cursors in this module.</returns>
        public abstract IEnumerable<ICursor> GenerateCursors();
    }
}
