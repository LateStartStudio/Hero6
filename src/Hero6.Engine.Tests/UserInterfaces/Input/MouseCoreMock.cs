// <copyright file="MouseCoreMock.cs" company="Late Start Studio">
// Copyright (C) Late Start Studio
// This file is subject to the terms and conditions of the MIT license specified in the file
// 'LICENSE.CODE.md', which is a part of this source code package.
// </copyright>

namespace LateStartStudio.Hero6.Engine.UserInterfaces.Input
{
    using LateStartStudio.Hero6.Engine.Assets.Graphics;

    public class MouseCoreMock : IMouse
    {
        public MouseCoreMock()
        {
            this.Left = MouseButtonState.Released;
            this.Middle = MouseButtonState.Released;
            this.Right = MouseButtonState.Released;
            this.X1 = MouseButtonState.Released;
            this.X2 = MouseButtonState.Released;
            this.ScrollWheel = 0;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public Point Location { get; set; }

        public MouseButtonState Left { get; }

        public MouseButtonState Middle { get; }

        public MouseButtonState Right { get; }

        public MouseButtonState X1 { get; }

        public MouseButtonState X2 { get; }

        public int ScrollWheel { get; }
    }
}
