// <copyright file="Dialog.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using Input;
    using Utilities.Settings;

    /// <summary>
    /// The <see cref="Dialog"/> class.
    /// </summary>
    public abstract class Dialog : Window
    {
        private readonly IGameSettings gameSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dialog"/> class.
        /// </summary>
        /// <param name="mouse">The mouse service.</param>
        /// <param name="gameSettings">The game settings service.</param>
        protected Dialog(IMouse mouse, IGameSettings gameSettings)
            : base(mouse)
        {
            this.gameSettings = gameSettings;
        }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        public virtual void Show()
        {
            X = (gameSettings.NativeWidth / 2) - (Width / 2);
            Y = (gameSettings.NativeHeight / 2) - (Height / 2);
            IsVisible = true;
            gameSettings.IsPaused = true;
        }

        /// <summary>
        /// Hides the dialog.
        /// </summary>
        public virtual void Hide()
        {
            IsVisible = false;
            gameSettings.IsPaused = false;
        }
    }
}
