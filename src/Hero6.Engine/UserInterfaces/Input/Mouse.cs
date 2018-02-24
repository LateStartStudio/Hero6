// <copyright file="Mouse.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Input
{
    using System;
    using Assets;
    using Assets.Graphics;
    using GameLoop;
    using Utilities.DependencyInjection;

    /// <summary>
    /// A controller class for the mouse unit.
    /// </summary>
    public sealed class Mouse : IGameLoop
    {
        private static readonly IRenderer Renderer;

        private static Point lastLocation;
        private static Cursor backup;
        private static IMouse core;
        private static MouseButtonState leftPrevious;
        private static MouseButtonState middlePrevious;
        private static MouseButtonState rightPrevious;
        private static MouseButtonState x1Previous;
        private static MouseButtonState x2Previous;

        static Mouse()
        {
            Renderer = ServicesBank.Instance.Get<IRenderer>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mouse"/> class.
        /// </summary>
        /// <param name="assets">The asset manager for this user interface module.</param>
        /// <param name="core">The basic core functionalities of the mouse unit.</param>
        public Mouse(AssetManager assets, IMouse core)
        {
            this.Assets = assets;
            Mouse.core = core;
        }

        /// <summary>
        /// Occurs when a mouse button is lifted up.
        /// </summary>
        public event EventHandler<MouseButtonClickEventArgs> ButtonUp;

        /// <inheritdoc />
        public event EventHandler<LoadEventArgs> PreLoad;

        /// <inheritdoc />
        public event EventHandler<LoadEventArgs> PostLoad;

        /// <inheritdoc />
        public event EventHandler<UnloadEventArgs> PreUnload;

        /// <inheritdoc />
        public event EventHandler<UnloadEventArgs> PostUnload;

        /// <inheritdoc />
        public event EventHandler<UpdateEventArgs> PreUpdate;

        /// <inheritdoc />
        public event EventHandler<UpdateEventArgs> PostUpdate;

        /// <inheritdoc />
        public event EventHandler<DrawEventArgs> PreDraw;

        /// <inheritdoc />
        public event EventHandler<DrawEventArgs> PostDraw;

        /// <summary>
        /// Gets or sets the x coordinate of the mouse.
        /// </summary>
        public static int X
        {
            get { return lastLocation.X; }
            set { core.X = value; }
        }

        /// <summary>
        /// Gets or sets the y coordinate of the mouse.
        /// </summary>
        public static int Y
        {
            get { return lastLocation.Y; }
            set { core.Y = value; }
        }

        /// <summary>
        /// Gets or sets the coordinates of the mouse.
        /// </summary>
        public static Point Location
        {
            get { return lastLocation; }
            set { core.Location = value; }
        }

        /// <summary>
        /// Gets or sets the cursor.
        /// </summary>
        public static Cursor Cursor { get; set; }

        /// <summary>
        /// Gets the state of the left mouse button.
        /// </summary>
        public static MouseButtonState Left => core.Left;

        /// <summary>
        /// Gets the state of the middle mouse button.
        /// </summary>
        public static MouseButtonState Middle => core.Middle;

        /// <summary>
        /// Gets the state of the right mouse button.
        /// </summary>
        public static MouseButtonState Right => core.Right;

        /// <summary>
        /// Gets the state of extra mouse button button 1.
        /// </summary>
        public static MouseButtonState X1 => core.X1;

        /// <summary>
        /// Gets the state of extra mouse button button 2.
        /// </summary>
        public static MouseButtonState X2 => core.X2;

        /// <summary>
        /// Gets the scroll wheel value.
        /// </summary>
        public static int ScrollWheel => core.ScrollWheel;

        /// <summary>
        /// Gets the asset manager for this user interface module.
        /// </summary>
        private AssetManager Assets { get; }

        /// <summary>
        /// Center the mouse cursor to the middle of the main window.
        /// </summary>
        public static void Center()
        {
            X = UserInterface.Width / 2;
            Y = UserInterface.Height / 2;
        }

        /// <summary>
        /// Save cursor to backup.
        /// </summary>
        public static void SaveCursorToBackup()
        {
            backup = Cursor;
        }

        /// <summary>
        /// Restore cursor from backup.
        /// </summary>
        public static void RestoreCursorFromBackup()
        {
            Cursor = backup;
        }

        /// <inheritdoc />
        public void Load()
        {
            PreLoad?.Invoke(this, new LoadEventArgs(this.Assets));

            foreach (Cursor mouseCursor in Cursor.All)
            {
                mouseCursor.Load(Assets);
            }

            PostLoad?.Invoke(this, new LoadEventArgs(this.Assets));
        }

        /// <inheritdoc />
        public void Unload()
        {
            PreUnload?.Invoke(this, new UnloadEventArgs());

            PostUnload?.Invoke(this, new UnloadEventArgs());
        }

        /// <inheritdoc />
        public void Update(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            if (!IsWithinGameWindow(core.Location.X, core.Location.Y))
            {
                return;
            }

            lastLocation = core.Location;

            PreUpdate?.Invoke(this, new UpdateEventArgs(total, elapsed, isRunningSlowly));

            if (Left == MouseButtonState.Released && leftPrevious == MouseButtonState.Pressed)
            {
                ButtonUp?.Invoke(this, new MouseButtonClickEventArgs(X, Y, MouseButton.Left));
            }
            else if (Middle == MouseButtonState.Released && middlePrevious == MouseButtonState.Pressed)
            {
                ButtonUp?.Invoke(this, new MouseButtonClickEventArgs(X, Y, MouseButton.Middle));
            }
            else if (Right == MouseButtonState.Released && rightPrevious == MouseButtonState.Pressed)
            {
                ButtonUp?.Invoke(this, new MouseButtonClickEventArgs(X, Y, MouseButton.Right));
            }
            else if (X1 == MouseButtonState.Released && x1Previous == MouseButtonState.Pressed)
            {
                ButtonUp?.Invoke(this, new MouseButtonClickEventArgs(X, Y, MouseButton.X1));
            }
            else if (X2 == MouseButtonState.Released && x2Previous == MouseButtonState.Pressed)
            {
                ButtonUp?.Invoke(this, new MouseButtonClickEventArgs(X, Y, MouseButton.X2));
            }

            leftPrevious = Left;
            middlePrevious = Middle;
            rightPrevious = Right;
            x1Previous = X1;
            x2Previous = X2;

            PostUpdate?.Invoke(this, new UpdateEventArgs(total, elapsed, isRunningSlowly));
        }

        /// <inheritdoc />
        public void Draw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            PreDraw?.Invoke(this, new DrawEventArgs(total, elapsed, isRunningSlowly));

            if (Cursor != null)
            {
                Renderer.Draw(Cursor.Texture, lastLocation);
            }

            PostDraw?.Invoke(this, new DrawEventArgs(total, elapsed, isRunningSlowly));
        }

        private static bool IsWithinGameWindow(int x, int y)
        {
            return x >= 0 && x < UserInterface.Width && y >= 0 && y < UserInterface.Height;
        }
    }
}
