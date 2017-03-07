// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Padding.cs" company="LateStartStudio">
//   Copyright (C) LateStartStudio
//   This file is subject to the terms and conditions of the MIT license specified
//   in the file 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>
// <summary>
//   Defines the Padding struct.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LateStartStudio.Hero6.UserInterface.SierraVga.Entities
{
    public struct Padding
    {
        public float Left;
        public float Top;
        public float Right;
        public float Bottom;

        public Padding(float left, float top, float right, float bottom)
        {
            this.Left = left;
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
        }

        public Padding(float all) : this(all, all, all, all)
        {
        }
    }
}
