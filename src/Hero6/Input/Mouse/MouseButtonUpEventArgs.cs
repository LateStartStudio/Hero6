// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MouseButtonUpEventArgs.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the MouseButtonPressedEventArgs type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Input.Mouse
{
    using System;
    using Microsoft.Xna.Framework;

    public class MouseButtonUpEventArgs : EventArgs
    {
        public MouseButtonUpEventArgs(Point position, MouseButton mouseButton)
        {
            this.Position = position;
            this.MouseButton = mouseButton;
        }

        public Point Position
        {
            get; private set;
        }

        public MouseButton MouseButton
        {
            get; private set;
        }
    }
}
