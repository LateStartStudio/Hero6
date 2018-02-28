// <copyright file="UserInterfaceElement.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using System;
    using Assets;
    using Assets.Graphics;
    using GameLoop;
    using Input;
    using Utilities.DependencyInjection;

    /// <summary>
    /// An abstract class for common attributes and functionality associated with a user interface
    /// element.
    /// </summary>
    public abstract class UserInterfaceElement : IGameLoop
    {
        private static readonly IRenderer Renderer;

        private bool isMouseIntersectingPrevious;
        private bool isWidthSet;
        private bool isHeightSet;
        private Point location;
        private Texture2D background;
        private Rectangle destination;

        static UserInterfaceElement()
        {
            Renderer = ServicesBank.Instance.Get<IRenderer>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserInterfaceElement"/> class.
        /// </summary>
        /// <param name="assets">The assets manager for this user interface module.</param>
        protected UserInterfaceElement(IAssets assets)
        {
            this.Assets = assets;
            this.IsVisible = true;
        }

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
        /// Occurs when left mouse button is lifted up while the cursor is over this user interface
        /// element.
        /// </summary>
        public event EventHandler<MouseButtonClickEventArgs> MouseButtonUp;

        /// <summary>
        /// Occurs when the mouse cursor enters this user interface element.
        /// </summary>
        public event EventHandler<EventArgs> MouseEnter;

        /// <summary>
        /// Occurs when the mouse cursor leaves this user interface element.
        /// </summary>
        public event EventHandler<EventArgs> MouseLeave;

        /// <summary>
        /// Gets or sets the background color of this user interface element.
        /// </summary>
        public Color Background { get; set; } = new Color(242, 242, 242, 255);

        /// <summary>
        /// Gets or sets the width of the user interface element.
        /// </summary>
        public int Width
        {
            get
            {
                return destination.Width;
            }

            set
            {
                this.destination.Width = value;
                this.isWidthSet = true;
            }
        }

        /// <summary>
        /// Gets or sets the height of the user interface element.
        /// </summary>
        public int Height
        {
            get
            {
                return destination.Height;
            }

            set
            {
                this.destination.Height = value;
                this.isHeightSet = true;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this user interface element is visible.
        /// </summary>
        public bool IsVisible { get; set; }

        /// <summary>
        /// Gets or sets the x coordinate of the user interface element.
        /// </summary>
        internal int X
        {
            get { return destination.X; }
            set { this.destination.X = value; }
        }

        /// <summary>
        /// Gets or sets the y coordinate of the user interface element.
        /// </summary>
        internal int Y
        {
            get { return destination.Y; }
            set { this.destination.Y = value; }
        }

        /// <summary>
        /// Gets or sets the location of the user interface element.
        /// </summary>
        internal Point Location
        {
            get { return location; }
            set { this.location = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this user interface element is loaded.
        /// </summary>
        protected bool IsLoaded { get; set; }

        /// <summary>
        /// Gets the default width if it hasn't been set before load time.
        /// </summary>
        protected abstract int DefaultWidth { get; }

        /// <summary>
        /// Gets the default height if it hasn't been set before load time.
        /// </summary>
        protected abstract int DefaultHeight { get; }

        /// <summary>
        /// Gets the asset manager for this user interface module.
        /// </summary>
        protected IAssets Assets { get; }

        /// <inheritdoc />
        public void Load()
        {
            PreLoad?.Invoke(this, new LoadEventArgs(Assets));

            this.background = this.Assets.CreateTexture2D(1, 1);
            background.SetData(new[] { Background });

            InternalLoad();

            if (!isWidthSet)
            {
                Width = DefaultWidth;
            }

            if (!isHeightSet)
            {
                Height = DefaultHeight;
            }

            this.IsLoaded = true;

            PostLoad?.Invoke(this, new LoadEventArgs(Assets));
        }

        /// <inheritdoc />
        public void Unload()
        {
            PreUnload?.Invoke(this, new UnloadEventArgs());

            InternalUnload();

            PostUnload?.Invoke(this, new UnloadEventArgs());
        }

        /// <inheritdoc />
        public void Update(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            if (!IsVisible)
            {
                return;
            }

            PreUpdate?.Invoke(this, new UpdateEventArgs(total, elapsed, isRunningSlowly));

            if (!IsLoaded)
            {
                Load();
            }

            this.location.X = destination.X;
            this.location.Y = destination.Y;

            if (Intersects(Mouse.X, Mouse.Y))
            {
                if (!isMouseIntersectingPrevious)
                {
                    MouseEnter?.Invoke(this, EventArgs.Empty);
                }

                this.isMouseIntersectingPrevious = true;
            }
            else
            {
                if (isMouseIntersectingPrevious)
                {
                    MouseLeave?.Invoke(this, EventArgs.Empty);
                }

                this.isMouseIntersectingPrevious = false;
            }

            InternalUpdate(total, elapsed, isRunningSlowly);

            PostUpdate?.Invoke(this, new UpdateEventArgs(total, elapsed, isRunningSlowly));
        }

        /// <inheritdoc />
        public void Draw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly)
        {
            if (!IsVisible)
            {
                return;
            }

            PreDraw?.Invoke(this, new DrawEventArgs(total, elapsed, isRunningSlowly));

            Renderer.Draw(background, destination, Background);
            InternalDraw(total, elapsed, isRunningSlowly);

            PostDraw?.Invoke(this, new DrawEventArgs(total, elapsed, isRunningSlowly));
        }

        /// <summary>
        /// Check if a point is intersecting with this user interface element.
        /// </summary>
        /// <param name="x">The x coordinate to check if is intersecting.</param>
        /// <param name="y">The y coordinate to check if is intersecting.</param>
        /// <returns>True if intersecting, false if else.</returns>
        public bool Intersects(int x, int y)
        {
            return x >= X && x < X + Width && y >= Y && y < Y + Height;
        }

        /// <summary>
        /// Invoke event for when any mouse button is lifted up. Will not be invoked if mouse is
        /// outside of bounds for this UI component and aslo if it isn't visible.
        /// </summary>
        /// <param name="sender">The sender of this event.</param>
        /// <param name="e">The event args.</param>
        internal void InvokeMouseButtonUp(object sender, MouseButtonClickEventArgs e)
        {
            if (!Intersects(e.X, e.Y) || !IsVisible)
            {
                return;
            }

            MouseButtonUp?.Invoke(this, e);

            if (this is IChild)
            {
                (this as IChild)?.Child.InvokeMouseButtonUp(sender, e);
            }
            else if (this is IChildren)
            {
                (this as IChildren)?.Children.ForEach(c => c.InvokeMouseButtonUp(sender, e));
            }
        }

        /// <summary>
        /// The actual load function for any instance inheriting from this abstract class.
        /// </summary>
        protected abstract void InternalLoad();

        /// <summary>
        /// The actual unload function for any instance inheriting from this abstract class.
        /// </summary>
        protected abstract void InternalUnload();

        /// <summary>
        /// The actual update function for any instance inheriting from this abstract class.
        /// </summary>
        /// <param name="total">The time total since first update.</param>
        /// <param name="elapsed">The time elapsed since last update.</param>
        /// <param name="isRunningSlowly">
        /// A value indicating whether the game is running slowly or not.
        /// </param>
        protected abstract void InternalUpdate(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly);

        /// <summary>
        /// The actual draw function for any instance inheriting from this abstract class.
        /// </summary>
        /// <param name="total">The time total since first draw.</param>
        /// <param name="elapsed">The time elapsed since last draw.</param>
        /// <param name="isRunningSlowly">
        /// A value indicating whether the game is running slowly or not.
        /// </param>
        protected abstract void InternalDraw(TimeSpan total, TimeSpan elapsed, bool isRunningSlowly);
    }
}
