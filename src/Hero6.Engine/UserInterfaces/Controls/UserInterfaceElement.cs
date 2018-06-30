// <copyright file="UserInterfaceElement.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Assets.Graphics;
    using Input;

    /// <summary>
    /// The <see cref="UserInterfaceElement"/> class.
    /// </summary>
    public abstract class UserInterfaceElement
    {
        private bool mousePreviouslyIntersected;
        private bool isVisible;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserInterfaceElement"/> class.
        /// </summary>
        /// <param name="mouse">The mouse service.</param>
        /// <param name="parent">The parent.</param>
        protected UserInterfaceElement(IMouse mouse, UserInterfaceElement parent = null)
        {
            Parent = parent;
            isVisible = true;
            mouse.Move += OnMouseMove;
            mouse.ButtonLift += OnMouseButtonLift;
        }

        /// <summary>
        /// Occurs when left mouse button is lifted up while the cursor is over this user interface
        /// element.
        /// </summary>
        public event EventHandler<MouseButtonInteraction> MouseButtonUp;

        /// <summary>
        /// Occurs when the mouse cursor enters this user interface element.
        /// </summary>
        public event EventHandler<MouseMove> MouseEnter;

        /// <summary>
        /// Occurs when the mouse cursor leaves this user interface element.
        /// </summary>
        public event EventHandler<MouseMove> MouseLeave;

        /// <summary>
        /// Gets or sets the <see cref="UserInterfaceElement"/> parent.
        /// </summary>
        public UserInterfaceElement Parent { get; set; }

        /// <summary>
        /// Gets or sets the Background <see cref="Color"/>.
        /// </summary>
        public Color Background { get; set; } = new Color(242, 242, 242, 255);

        /// <summary>
        /// Gets or sets the x position.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the y position.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets the width of the user interface element.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the user interface element.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this user interface element is visible.
        /// </summary>
        public bool IsVisible
        {
            get { return isVisible && (Parent == null || AllParents.Any(p => p.IsVisible)); }
            set { isVisible = value; }
        }

        private IEnumerable<UserInterfaceElement> AllParents
        {
            get
            {
                var parent = Parent;

                while (parent != null)
                {
                    yield return parent;
                    parent = parent.Parent;
                }
            }
        }

        /// <summary>
        /// See if input coordinates intersects with the <see cref="UserInterfaceElement"/> instance.
        /// </summary>
        /// <param name="x">The x position to check.</param>
        /// <param name="y">The y position to check.</param>
        /// <returns>True if input coordinates intersects; false if not.</returns>
        public bool Intersects(int x, int y) => x >= X && x < X + Width && y >= Y && y < Y + Height;

        private void OnMouseMove(object s, MouseMove e)
        {
            var intersecting = Intersects(e.X, e.Y);

            if (intersecting && !mousePreviouslyIntersected)
            {
                MouseEnter?.Invoke(s, e);
            }
            else if (!intersecting && mousePreviouslyIntersected)
            {
                MouseLeave?.Invoke(s, e);
            }

            mousePreviouslyIntersected = intersecting;
        }

        private void OnMouseButtonLift(object s, MouseButtonInteraction e)
        {
            if (IsVisible && Intersects(e.X, e.Y))
            {
                MouseButtonUp?.Invoke(s, e);
            }
        }
    }
}
