// <copyright file="Dialog.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using Assets;
    using Utilities.DependencyInjection;

    /// <summary>
    /// A standard dialog.
    /// </summary>
    public class Dialog : Window
    {
        private static readonly IRenderer Renderer;

        static Dialog()
        {
            Renderer = ServicesBank.Instance.Get<IRenderer>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dialog"/> class.
        /// </summary>
        /// <param name="assets">The asset manager of this user interface module.</param>
        protected Dialog(IAssets assets)
            : base(assets)
        {
            this.IsVisible = false;
        }

        /// <summary>
        /// Gets a value indicating whether any dialog has been opened in this iteration of the
        /// update/draw loop.
        /// </summary>
        public static bool IsShownInCurrentLoopIteration { get; internal set; }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        public void Show()
        {
            this.X = (UserInterface.Width / 2) - (Width / 2);
            this.Y = (UserInterface.Height / 2) - (Height / 2);
            this.IsVisible = true;
            Renderer.IsPaused = true;
            IsShownInCurrentLoopIteration = true;
        }

        /// <summary>
        /// Hides the dialog.
        /// </summary>
        public void Hide()
        {
            this.IsVisible = false;
            Renderer.IsPaused = false;
        }
    }
}
