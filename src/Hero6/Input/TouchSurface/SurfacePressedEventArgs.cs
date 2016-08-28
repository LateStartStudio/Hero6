// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SurfacePressedEventArgs.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the SurfacePressedEventArgs type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.Input.TouchSurface
{
    using System;
    using Microsoft.Xna.Framework;

    public class SurfacePressedEventArgs : EventArgs
    {
        public SurfacePressedEventArgs(Point position)
        {
            this.Position = position;
        }

        public Point Position
        {
            get; private set;
        }
    }
}
